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
	// Use this for initialization
	void Start () {
		contadorTimerManqueba = 0;
		Origin = new Vector3(DistanceToOrigin,0,DistanceToOrigin);
	}
	
	// Update is called once per frame
	void Update () {
		contadorTimerManqueba++;
		if (contadorTimerManqueba >= 60) {
			CreateObstacle();
			contadorTimerManqueba=0;
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
			if (DistanceToOrigin >= 200) {
				MovingNear = true;
			}
		
		}
		Origin = new Vector3(DistanceToOrigin,0,DistanceToOrigin);

	
	}

	void Rotate (){
		//Origin += new Vector3(Origin.x*Mathf.Sin() )


	}

	void CreateObstacle(){
		GameObject g = (GameObject)Instantiate(Obstacle,Origin,Quaternion.identity);
		g.GetComponent<MoveToScreen>().Destination = randomDestination();
		
		
	}



	Vector3 randomDestination(){
		return new Vector3 (Random.Range(-dispersionRange,dispersionRange),Random.Range(-dispersionRange,dispersionRange),-11);
	
	
	}


}
