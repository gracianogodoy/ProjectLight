﻿using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	public int faseAtual;
	// Use this for initialization
	void Start () {
		setarEstagio (1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setarEstagio(int num)
	{
		//Flash
		faseAtual = num;
		//Alteraçoes graficas (sprites, etc)
		//Fade out trilha sonora atual
		AudioManager.Instance.Play ("Trilha" + faseAtual);
	}
}