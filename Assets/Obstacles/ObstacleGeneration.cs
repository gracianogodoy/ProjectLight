using UnityEngine;
using System.Collections;

public class ObstacleGeneration : MonoBehaviour {

	int contadorTimerManqueba;
	public GameObject Obstacle;
	public Vector3 Origin;
	// Use this for initialization
	void Start () {
		contadorTimerManqueba = 0;
		Origin = new Vector3 (15, 0, 10);
	}
	
	// Update is called once per frame
	void Update () {
		contadorTimerManqueba++;
		if (contadorTimerManqueba >= 60) {
			GameObject g = (GameObject)Instantiate(Obstacle,Origin,Quaternion.identity);
			g.GetComponent<MoveToScreen>().Destination = randomDestination();
			contadorTimerManqueba=0;
		}

	}

	Vector3 randomDestination(){
		return new Vector3 (Random.Range(-5,5),Random.Range(-5,5),-11);
	
	
	}


}
