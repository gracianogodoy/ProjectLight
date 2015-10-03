using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleGeneration : MonoBehaviour {
	
	public GameObject Obstacle;
	public GameObject Light1;
	public GameObject Light2;
	public GameObject Light3;



	int ContadorTimerObstaculos;
	int ContadorTimerLuzes;
	public float DistanceToOrigin;
	Vector3 Origin;
	public float dispersionRange;
	public float RotateSpeed;
	bool MovingNear = true;
	public float AproximationSpeed;
	public int TaxaDeRepetiçaoObstaculos;
	public int TaxaDeRepetiçaoLuzes;

	// Use this for initialization
	void Start () {
		ContadorTimerObstaculos = 0;
		Origin = new Vector3(DistanceToOrigin,0,DistanceToOrigin);
	}
	
	// Update is called once per frame
	void Update () {
		ContadorTimerObstaculos++;
		if (ContadorTimerObstaculos >= TaxaDeRepetiçaoObstaculos) {
			CreateObstacle(4,0,0.4f,3);
			ContadorTimerObstaculos=0;
			TaxaDeRepetiçaoObstaculos += Random.Range(-1,2);
		}

		ContadorTimerLuzes++;
		if (ContadorTimerLuzes >= TaxaDeRepetiçaoLuzes) {
			CreateObstacle(1,1,0.6f,3);
			ContadorTimerLuzes=0;
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
		Queue<Vector3> positions = ObstaclePositions(quantity);
		for (int i = 0; i < quantity; i++) {
			
			GameObject g = null;
			GameObject a =null;
			MoveToScreen m;
			switch (type) {

				case 0:				
				a= Obstacle;
				break;

			case 1:
				a= Light1;
				break;

			case 2:
				a= Light2;

				break;


			case 3:
				a= Light3;
				break;

			}
			
			g = (GameObject)Instantiate(a,Origin,Quaternion.identity);
			m = g.GetComponent<MoveToScreen> ();
			//Debug.Log(positions.Peek());
			m.Destination = positions.Dequeue();
			m.Speed = speed;
			m.angle = angle;
			
		}
		
	}

	Queue<Vector3> ObstaclePositions(int num){
		Queue <Vector3> positions = new Queue <Vector3>();
		for (int i = 0; i < num; i++) {
			Vector3 newPosition;
			bool error;
			do{
				error = false;
				newPosition = new Vector3 ((int)(5*Random.Range(-dispersionRange,dispersionRange)),(int)(5*(int)Random.Range(-dispersionRange,dispersionRange)),-15);
				if (positions.Contains(newPosition)) {
					error =true;
				}					

			}while(error);
			positions.Enqueue(newPosition);
		}
		return positions;

	}





}
