using UnityEngine;
using System.Collections;

public class Charcter_GatherPoints : MonoBehaviour {

	public int points = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnCollisionEnter( Collision col) {
		if (col.gameObject.tag == "Light") {
			Destroy(col.gameObject);
			points++;		
		}
	}
}
