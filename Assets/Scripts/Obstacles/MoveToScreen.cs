using UnityEngine;
using System.Collections;

public class MoveToScreen : MonoBehaviour {

	public Vector3 Destination;
	public float Speed;
	public float angle;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		moveToDestination ();

	}

	void moveToDestination(){
		Vector3 centralAxis = new Vector3 (0, 0, transform.position.z);
		Vector3 direction = (Destination - transform.position) + angle*(centralAxis - transform.position);
		direction.Normalize ();
		transform.position += direction*Speed;
		
	}



}
