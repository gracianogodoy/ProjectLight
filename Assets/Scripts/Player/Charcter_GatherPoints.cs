﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Charcter_GatherPoints : MonoBehaviour {

	public int points = 0;
	public Text CanvasText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnCollisionEnter( Collision col) {
		if (col.gameObject.tag == "Light") {
			Destroy(col.gameObject);
			TextDisplay texto = CanvasText.GetComponent<TextDisplay>();
			texto.AdvanceText();
			points++;		
		}
	}
}
