using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour {
	public GameObject Ball;
	private float myLocation;

	void Start () {
		myLocation = transform.position.z;
	}
	
	void LateUpdate(){
		
		transform.position =new Vector3(0f , 3.13f, Ball.transform.position.z + myLocation);
	}
}
