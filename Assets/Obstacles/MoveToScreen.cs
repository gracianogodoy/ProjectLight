using UnityEngine;
using System.Collections;

public class MoveToScreen : MonoBehaviour {

	public Vector3 Destination;
	public float Speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		moveToDestination ();

	}

	void moveToDestination(){
		Vector3 direction = Destination - transform.position;
		direction.Normalize ();
		transform.position += direction*Speed;
		
	}



}
