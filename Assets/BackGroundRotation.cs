using UnityEngine;
using System.Collections;

public class BackGroundRotation : MonoBehaviour {

	public float RotationAmmount = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.up,RotationAmmount);
	
	}
}
