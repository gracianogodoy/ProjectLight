using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {
	public float redux = 0.01f;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void mudarCor(int stage, string LuzOuObs)
	{
		GameObject stageManager = GameObject.Find("Stage Manager");
		Stage script = (Stage)stageManager.GetComponent (typeof(Stage));

		Color atual = GetComponent<Renderer> ().material.color;
		if (stage == 1) { //BRANCO -> VERMELHO
			if (LuzOuObs == "Luz")
			{
				GetComponent<Renderer>().material.color = new Color(
					atual.r, atual.g - (redux * script.addLuz), atual.b - (redux * script.addLuz));
				script.progress += script.addLuz; //adiciona progresso
			}
			if (LuzOuObs == "Obs")
			{
				GetComponent<Renderer>().material.color = new Color(
					atual.r, atual.g - (redux * script.addObs), atual.b - (redux * script.addObs));
				script.progress += script.addObs; //remove progresso
			}
		}

		if (stage == 2) { //VERMELHO -> AZUL
			if (LuzOuObs == "Luz")
			{
				GetComponent<Renderer>().material.color = new Color(
					atual.r - (redux * script.addLuz), 0, atual.b + (redux * script.addLuz));
				script.progress += script.addLuz; //adiciona progresso
			}
			if (LuzOuObs == "Obs")
			{
				GetComponent<Renderer>().material.color = new Color(
					atual.r - (redux * script.addObs), 0, atual.b + (redux * script.addObs));
				script.progress += script.addObs; //remove progresso
			}
		}

		if (stage == 3) { //AZUL -> AMARELO
			if (LuzOuObs == "Luz")
			{
				GetComponent<Renderer>().material.color = new Color(
					atual.r + (redux * script.addLuz), atual.g + (redux * script.addLuz), atual.b - (redux * script.addLuz));
				script.progress += script.addLuz; //adiciona progresso
			}
			if (LuzOuObs == "Obs")
			{
				GetComponent<Renderer>().material.color = new Color(
					atual.r + (redux * script.addObs), atual.g + (redux * script.addObs), atual.b - (redux * script.addObs));
				script.progress += script.addObs; //remove progresso
			}
		}

		if (stage == 4) { //AMARELO -> BRANCO
			if (LuzOuObs == "Luz")
			{
				GetComponent<Renderer>().material.color = new Color(
					1, 1, atual.b + (redux * script.addLuz));
				script.progress += script.addLuz; //adiciona progresso
			}
			if (LuzOuObs == "Obs")
			{
				GetComponent<Renderer>().material.color = new Color(
					1, 1, atual.b - (redux * script.addObs));
				script.progress += script.addObs; //remove progresso
			}
		}

		//Tirar rgb com valores maiores q 1 ou menores q 0
		atual = GetComponent<Renderer> ().material.color;
		if (atual.r > 1)
			atual.r = 1;
		if (atual.r < 0)
			atual.r = 0;
		if (atual.g > 1)
			atual.g = 1;
		if (atual.g < 0)
			atual.g = 0;
		if (atual.b > 1)
			atual.b = 1;
		if (atual.b < 0)
			atual.b = 0;
		GetComponent<Renderer> ().material.color = atual;

		Debug.Log("r" + atual.r + " g" + atual.g + " b" + atual.b);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Light")
		{
			GameObject stage = GameObject.Find("Stage Manager");
			Stage script = (Stage)stage.GetComponent (typeof(Stage));
			
			int num = script.faseAtual;
			mudarCor(num, "Luz");
		}
		if (col.gameObject.tag == "Obstacle")
		{
			GameObject stage = GameObject.Find("Stage Manager");
			Stage script = (Stage)stage.GetComponent (typeof(Stage));
			
			int num = script.faseAtual;
			mudarCor(num, "Obs");
		}

	}

}
