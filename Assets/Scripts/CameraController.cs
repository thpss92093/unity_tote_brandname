using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using OpenCvSharp;
using NWH;

using Rect =  UnityEngine.Rect;

public class CameraController : MonoBehaviour {

    // if true, then randomly sampling the corresponding size
    // otherwise go througth all;
    public bool randomSampling;
    public int sampleSize;
    public bool randomAngle;
    public float angleVariation;
    
    public float minMove;

    // time after taking each picture, deafault t=0
    public float timeForEachPics;

    public CameraVertices camVertices;

    // link corresponding camera and object;
    public GameObject renderCam;
    //public List<GameObject> renderCams;
    public GameObject renderObj;
    ObjectController objectController;
    public Light lt;

    public IniFile ini;
    string dataPath;

    public string objName;
    public int maximumScene;
    public int sceneCnt;
    public int maximumImage;
    public int imageCnt;

    // Use this for initialization
    void Start() {
        dataPath = Application.dataPath;
        dataPath = dataPath.Substring(0, dataPath.Length - 6);

        objectController = renderObj.GetComponent<ObjectController>();
        maximumImage = camVertices.get_total_views();

        if (objName == "")
            objName = renderObj.name;
        StartCoroutine(startDifferentView());
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator startDifferentView()
    {
        while (!camVertices.ifDone)
        {
            yield return new WaitForSeconds(1f);
        }


        if (!randomSampling)
            sampleSize = camVertices.verticesList.Count;

        while (sceneCnt < maximumScene)
        {
            objectController.Place(sceneCnt, renderObj.name);
            
            string sceneName = "Images/" + objName + "/Scene" + sceneCnt + "/";
            System.IO.Directory.CreateDirectory(sceneName);
            //ini.Load_File()
            ini = new IniFile();
            ini.Load_File(dataPath + sceneName + "info.ini");
            Debug.Log(dataPath + sceneName + "info.ini");
            
            // save object information
            ini.Create_Section("Object Information");
            ini.Goto_Section("Object Information");

            ini.Set_Vector3("Position", renderObj.transform.position);
            ini.Set_Vector3("Orientation(Euler)", renderObj.transform.rotation.eulerAngles);

            //ini.Create_Section("View Information");
            ini.Goto_Section("View Information");

            while (imageCnt < sampleSize)
            {
                // get camera position
                Vector3 camPos = Vector3.zero;
                Vector3 lookPos = Vector3.zero;

                if (randomSampling)
                {
                    //camPos = camVertices.get_random_vertice();
                    //Debug.Log("randomSampling =" + randomSampling);
                    camPos = camVertices.get_circle_vertice(renderObj.transform.position, imageCnt, renderObj.name);
                    lookPos = camVertices.get_look_vertice(renderObj.transform.position, imageCnt);
                    //camPos = camVertices.get_random_vertice();
                    //lookPos = camVertices.get_random_look_vertice();
                }

                else
                    camPos = camVertices.getVerticeAt(imageCnt);

                //Debug.Log("camPos =" + camPos);
                renderCam.transform.position = camPos;
                ini.Set_Vector3(imageCnt.ToString(), camPos);

                // set camera look at the object
                //renderCam.transform.LookAt(renderObj.transform);
                renderCam.transform.LookAt(lookPos);
                
                // random variation
                if (randomAngle) {
                    Vector3 euler = renderCam.transform.rotation.eulerAngles;
                    euler += new Vector3(Random.value * angleVariation - Random.value * angleVariation,
                        Random.value * angleVariation - Random.value * angleVariation,
                        Random.value * angleVariation - Random.value * angleVariation);
                    renderCam.transform.eulerAngles = euler;
                    Debug.Log("randomAngle = " + randomAngle + "euler = " + euler);
                }

                // capture the screenshot;
                //ScreenCapture.CaptureScreenshot(sceneName + imageCnt + ".png");
                //renderCam.GetComponent<ScreenShotForCamera>().CaptureCamera(sceneName + imageCnt + ".png");
                yield return new WaitForEndOfFrame();
                yield return StartCoroutine(ScreenShot(sceneName + imageCnt));
                imageCnt++;
                yield return new WaitForSeconds(0.01f);
                lt.color = Color.HSVToRGB(Random.value * 0.7f, Random.value * 0.5f, 1.0f - Random.value * 0.15f, true);
            }
            //ini.SaveTo(dataPath + sceneName + "info.ini");
            objectController.Reset();
            // next scene
            // Object must move certain distance from a scene to another
            Vector3 objPos = renderObj.transform.position;
            Vector3 nextPos = renderObj.transform.position;
            sceneCnt++;
            imageCnt = 0;
        }

        yield return null;
    }


    IEnumerator ScreenShot(string filename)
    {
        yield return new WaitForEndOfFrame();

        Texture2D entireScreen = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        entireScreen.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        entireScreen.Apply();
        // get original image
        Texture2D original = new Texture2D(Screen.width / 2, Screen.height / 2, TextureFormat.RGB24, false);
        Color[] pix = entireScreen.GetPixels(0, Screen.height / 2, Screen.width / 2, Screen.height / 2);
        original.SetPixels(pix);
        original.Apply();
        texToPNG(filename + "_original.png", original);
        Destroy(original);

        // get depth
        Texture2D depth = new Texture2D(Screen.width / 2, Screen.height / 2, TextureFormat.RGB24, false);
        pix = entireScreen.GetPixels(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2);
        depth.SetPixels(pix);
        depth.Apply();
        texToPNG(filename + "_depth.png", depth);
        Destroy(depth);

        //get seg
        Texture2D seg = new Texture2D(Screen.width / 2, Screen.height / 2, TextureFormat.RGB24, false);
        pix = entireScreen.GetPixels(Screen.width / 2, 0, Screen.width / 2, Screen.height / 2);
        seg.SetPixels(pix);
        seg.Apply();
        texToPNG(filename + "_seg.png", seg);
        Destroy(seg);

        //get label
        Texture2D label = new Texture2D(Screen.width / 2, Screen.height / 2, TextureFormat.RGB24, false);
        float ang;
        int temp = 0;
        ang = renderObj.transform.rotation.eulerAngles.y - renderCam.transform.rotation.eulerAngles.y;
        // 3m  cocacola  folgers  heineken  hunts  crayola  kellogg  kleenex  kotex  macadamia  pocky  swiss_miss  libava == 0
        if (renderObj.name == "milo" || renderObj.name == "stax")
            temp = 11;
        else if (renderObj.name == "vanish")
            temp = 24;
        else if (renderObj.name == "viva" || renderObj.name == "ziploc")
            temp = 20;
        else if (renderObj.name == "andes")
            temp = 13;
        else if (renderObj.name == "raisins")
            temp = 17;
        else if (renderObj.name == "mm")
            temp = 8;
        ang = ang - temp;
        pix = entireScreen.GetPixels(0, 0, Screen.width / 2, Screen.height / 2);
        
        for (int i = 0; i < pix.Length; i++)
        {
            if ((!(Mathf.Abs(ang) < 45 || Mathf.Abs(ang) > 315) && pix[i].r >= 0.2f) || (pix[i].r <= 0.5f && pix[i].b <= 0.5f)) //brandname out of range and deep color
                pix[i] = Color.black;
            else if (pix[i].r >= 0.4f && pix[i].b >= 0.4f)
                pix[i] = Color.white;
            else    //blue to gray
                pix[i] = new Color(0.5f, 0.5f, 0.5f);
        }
        label.SetPixels(pix);
		label.Apply ();
        
        texToPNG(filename + "_label.png", label);
        Destroy (label);
        Destroy(entireScreen);
	}

	private void texToPNG(string filename, Texture2D tex)
	{
		byte[] bytes = tex.EncodeToPNG ();
		File.WriteAllBytes (filename, bytes);
	}

}
