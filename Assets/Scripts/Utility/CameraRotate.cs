using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	public float RotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (new Vector3(0,0,1),RotationSpeed);
	
	}
}
