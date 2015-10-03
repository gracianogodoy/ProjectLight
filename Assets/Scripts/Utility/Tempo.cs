using UnityEngine;
using System.Collections;

public class Tempo : MonoBehaviour {

	public bool slowMoEnding = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (slowMoEnding)
		{
			Time.timeScale = 0.30f;
			//Time.fixedDeltaTime = 0.3f;
		}
	}
}
