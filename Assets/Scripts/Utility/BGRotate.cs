using UnityEngine;
using System.Collections;

public class BGRotate : MonoBehaviour {
    public float RotationSpeed = 0.1f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Vector3.back,-RotationSpeed);
	}
}
