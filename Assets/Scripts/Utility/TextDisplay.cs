using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour {


	int TimerTextFade;
	int TextCount;
	public Text Texto;
	List <string> Frases;
	// Use this for initialization
	void Start () {
		Texto.text = "Whats Happening?";
		Frases = new List<string>{"Minha vida?","Até Hoje?","Só Agora?","Jarbas?","Meu Pai?","MEU PAI????"};

	}


	void FixedUpdate () {

			if (TimerTextFade > 80) {
			Texto.text ="";

		} else {
			TimerTextFade++;
		
		}
	
	}

	public void AdvanceText(){
		try{
		Texto.text = Frases[0];
		Frases.RemoveAt (0);
		}	
		catch{
		}
		TimerTextFade = 0;
	
	
	}

}
