using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {
	public float redux = 0.1f;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void mudarCor(int stage)
	{
		Color atual = GetComponent<Renderer> ().material.color;
		if (stage == 1) {
			GetComponent<Renderer>().material.color = new Color(
				atual.r, atual.g - redux, atual.b - redux);
		}
		if (stage == 2) {
			
		}
		if (stage == 3) {
			
		}
		if (stage == 4) {
			
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Light")
		{
			GameObject stage = GameObject.Find("Stage Manager");
			Stage script = (Stage)stage.GetComponent (typeof(Stage));
			
			int num = script.faseAtual;
			mudarCor(num);
		}

	}

}
