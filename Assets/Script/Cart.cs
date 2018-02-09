using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour {

	Material tr;

	// Use this for initialization
	void Start () {
		tr = gameObject.GetComponent<MeshCollider>().material;
		tr.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
