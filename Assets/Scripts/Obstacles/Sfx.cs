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

		if (this.gameObject.name == "Obstacle1(Clone)")
		{
			AudioManager.Instance.Play ("ColisaoRuim");
			shake.shake = 0.5f;
		}

		if (this.gameObject.name == "Foton1(Clone)")
		{
			AudioManager.Instance.Play ("ColisaoBoaVermelha");

		}

		Destroy (this.gameObject);

	}
}
