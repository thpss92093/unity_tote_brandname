using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour {

	public GameObject desireModel;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Initialize()
	{
		GetComponent<CameraController> ().renderObj = desireModel;

		DeleteAllComponents (desireModel);

		// process seg;
		GameObject seg = GameObject.Instantiate (desireModel);
		FollowRenderCam segFol = seg.AddComponent<FollowRenderCam> () as FollowRenderCam;
		seg.GetComponent<FollowRenderCam> ().cam = desireModel;
		seg.layer = 8;
		seg.name = desireModel.name + "_seg";

		GameObject.Find ("Seg").GetComponent<SegRender> ().objects [0] = seg;

		// process label;
		GameObject label = GameObject.Instantiate (desireModel);
		FollowRenderCam labFol = label.AddComponent<FollowRenderCam> () as FollowRenderCam;
		label.GetComponent<FollowRenderCam> ().cam = desireModel;
		label.layer = 9;
		label.name = desireModel.name + "_label";

		Rigidbody rb = desireModel.AddComponent<Rigidbody> () as Rigidbody;
		MeshCollider mc = desireModel.AddComponent<MeshCollider> () as MeshCollider;
		mc.convex = true;
		ObjectController oc = desireModel.AddComponent<ObjectController> () as ObjectController;
        oc.pushForce = 1.5f;
        //oc.pushForce = 3f;
    }


	void DeleteAllComponents(GameObject g)
	{

		foreach (var comp in g.GetComponents<Component>()) {
			if ((comp is Rigidbody) || (comp is MeshCollider) || (comp is Collider) || (comp is BoxCollider) || (comp is SphereCollider)) {
				DestroyImmediate (comp);
			}
		}
	}
}
