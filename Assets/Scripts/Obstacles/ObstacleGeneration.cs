using UnityEngine;
using System.Collections;

public class ObstacleGeneration : MonoBehaviour {

	int contadorTimerManqueba;
	public GameObject Obstacle;
	public float DistanceToOrigin;
	Vector3 Origin;
	public float dispersionRange;
	public float RotateSpeed;
	bool MovingNear = true;
	public float AproximationSpeed;
	public int TaxaDeRepetiçao;

	// Use this for initialization
	void Start () {
		contadorTimerManqueba = 0;
		Origin = new Vector3(DistanceToOrigin,0,DistanceToOrigin);
	}
	
	// Update is called once per frame
	void Update () {
		contadorTimerManqueba++;
		if (contadorTimerManqueba >= TaxaDeRepetiçao) {
			CreateObstacle(1,0,0.4f,3);
			contadorTimerManqueba=0;
			TaxaDeRepetiçao += Random.Range(-1,2);
		}
		
		ChangeDistance();
		//Rotate ();

	}

	void ChangeDistance(){
		if (MovingNear) {
			DistanceToOrigin -= AproximationSpeed;
			if (DistanceToOrigin <= 10) {
				MovingNear = false;
			}
		} else {
			DistanceToOrigin += AproximationSpeed;
			if (DistanceToOrigin >= 100) {
				MovingNear = true;
			}
		
		}
		Origin = new Vector3(DistanceToOrigin,0,DistanceToOrigin);

	
	}

	void Rotate (){
		//Origin += new Vector3(Origin.x*Mathf.Sin() )


	}
	/// <summary>
	/// Creates the obstacle.
	/// </summary>
	/// <param name="quantity">How many obstacles are generated.</param>
	/// <param name="type">Type of the obstacles generated</param>
	/// <param name="speed">Speed of the obstacles</param>
	/// <param name="angle">How much the obstacle bends towards the screen</param>
	void CreateObstacle(int quantity, int type,float speed,float angle){
		for (int i = 0; i < quantity; i++) {
			
			GameObject g = (GameObject)Instantiate(Obstacle,Origin,Quaternion.identity);
			MoveToScreen m = g.GetComponent<MoveToScreen> ();
			m.Destination = randomDestination();
			m.Speed = speed;
			m.angle = angle;
			
		}
		
	}



	Vector3 randomDestination(){
		return new Vector3 (Random.Range(-dispersionRange,dispersionRange),Random.Range(-dispersionRange,dispersionRange),-25);
	
	
	}


}
