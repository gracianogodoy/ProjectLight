using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	public int faseAtual;
	public Canvas canvas;

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
		Flash flash = (Flash)canvas.GetComponent (typeof(Flash));
		flash.ativarFlash ();

		faseAtual = num;
		//Alteraçoes graficas (sprites, etc)

		//Fade out trilha sonora atual

		//Tocar trilha sonora
		AudioManager.Instance.Play ("Trilha" + faseAtual);
	}
}
