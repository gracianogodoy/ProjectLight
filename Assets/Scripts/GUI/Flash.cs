using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {
	public bool fadeAtivado = false;
	public float tempoTotalDeFlash = 2;
	public float alpha = 0;
	public float velocidadeFade = 0.01f;
	public CanvasRenderer canvas;
	// Use this for initialization
	void Start () {
		canvas.SetAlpha (0.0f);

		//ativarFlash ();
	}
	
	// Update is called once per frame
	void Update () {
		canvas.SetColor(new Color(1, 1, 1, alpha));
		if (fadeAtivado)
		{
			alpha += velocidadeFade;
		}
		if (alpha > tempoTotalDeFlash)
		{
			fadeAtivado = false;
		}
		if (!fadeAtivado)
		{
			alpha -= velocidadeFade;
			if (alpha < 0)
			{
				alpha = 0;
			}
		}
	}

	public void ativarFlash()
	{
		fadeAtivado = true;
	}

	public void ativarFlashInicial()
	{
		fadeAtivado = true;
		alpha = 1.5f;
	}
}
