using UnityEngine;
using System.Collections;

public class Sfx : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter()
	{
		GameObject cam = GameObject.Find("Main Camera");
		CameraShake shake = (CameraShake)cam.GetComponent (typeof(CameraShake));
		shake.shake = 0.5f;
		AudioManager.Instance.Play ("ColisaoRuim");
		Destroy (this.gameObject);

	}
}
