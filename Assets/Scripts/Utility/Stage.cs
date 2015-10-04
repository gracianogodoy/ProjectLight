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
		faseAtual = num;
		//Flash
		Flash flash = (Flash)canvas.GetComponent (typeof(Flash));
		if (num == 1) {
			flash.ativarFlashInicial ();
		} else {
			flash.ativarFlash ();
		}


		//Alteraçoes graficas (sprites, etc)

		//Alteraçoes mecanicas
		if (faseAtual == 1) {
			alterarObs(1, 0, 0.2f, 3);
			alterarLuz(1, 1, 0.3f, 3);
			alterarTaxasDeRepeticao(30, 150);
			sloMo(false);
		}
		if (faseAtual == 2) {
			alterarObs(2, 1, 0.2f, 3);
			alterarLuz(1, 1, 0.3f, 3);
			alterarTaxasDeRepeticao(30, 150);
			sloMo(false);
		}
		if (faseAtual == 3) {
			alterarObs(3, 0, 0.2f, 3);
			alterarLuz(1, 2, 0.3f, 3);
			alterarTaxasDeRepeticao(30, 150);
			sloMo(false);
		}
		if (faseAtual == 4) {
			alterarObs(1, 0, 0.2f, 3);
			alterarLuz(1, 1, 0.3f, 3);
			alterarTaxasDeRepeticao(30, 150);
			sloMo(true);
		}


		//Fade out trilha sonora atual (GRACIANIN PLZ)

		//Tocar trilha sonora
		AudioManager.Instance.Play ("Trilha" + faseAtual);
	}

	void alterarObs(int qtd, int tipo, float vel, float ang)
	{
		GameObject gerador = GameObject.Find ("ObstacleGenerator");
		ObstacleGeneration script = (ObstacleGeneration)gerador.GetComponent (typeof(ObstacleGeneration));

		script.quantidadeObs = qtd;
		script.tipoObs = tipo;
		script.velocidadeObs = vel;
		script.anguloObs = ang;
	}

	void alterarLuz(int qtd, int tipo, float vel, float ang)
	{
		GameObject gerador = GameObject.Find ("ObstacleGenerator");
		ObstacleGeneration script = (ObstacleGeneration)gerador.GetComponent (typeof(ObstacleGeneration));
		
		script.quantidadeLuz = qtd;
		script.tipoLuz = tipo;
		script.velocidadeLuz = vel;
		script.anguloLuz = ang;
	}

	void alterarTaxasDeRepeticao(int obs, int luz)
	{
		GameObject gerador = GameObject.Find ("ObstacleGenerator");
		ObstacleGeneration script = (ObstacleGeneration)gerador.GetComponent (typeof(ObstacleGeneration));

		script.TaxaDeRepetiçaoObstaculos = obs;
		script.TaxaDeRepetiçaoLuzes = luz;
	}

	void sloMo(bool ativado)
	{
		GameObject gerador = GameObject.Find ("Stage Manager");
		Tempo script = (Tempo)gerador.GetComponent (typeof(Tempo));

		script.slowMoEnding = ativado;
	}
}
