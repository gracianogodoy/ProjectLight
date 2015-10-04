using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleGeneration : MonoBehaviour {
	
	public GameObject Obstacle;
	public GameObject Light0;
	public GameObject Light1;
	public GameObject Light2;
	public GameObject Light3;
	public GameObject RoamingLight;

	float angle =0;

	int ContadorTimerObstaculos;
	int ContadorTimerLuzes;
	public float DistanceToOrigin =60;
	Vector3 Origin;
	public int dispersionRange;
	public float RotateSpeed;
	bool MovingNear = true;
	public float AproximationSpeed;
	public int TaxaDeRepetiçaoObstaculos;
	public int TaxaDeRepetiçaoLuzes;
	public bool obstaculosAtivados = true;

	public float TunnelDistance =60;

	public int quantidadeObs = 4;
	public int tipoObs = 0;
	public float velocidadeObs = 0.3f;
	public float anguloObs = 3.0f;

	public int quantidadeVagantes = 4;
	public int tipoVagantes = 0;
	public float velocidadeVagantes = 0.3f;
	public float anguloVagantes = 3.0f;


	public int quantidadeLuz = 1;
	public int tipoLuz = 1;
	public float velocidadeLuz = 0.6f;
	public float anguloLuz = 3.0f;

	// Use this for initialization
	void Start () {
		ContadorTimerObstaculos = 0;
		Origin = new Vector3(DistanceToOrigin,0,DistanceToOrigin);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (obstaculosAtivados)
		{
			int taxaAtual = TaxaDeRepetiçaoObstaculos + Random.Range(-1, 2);
			ContadorTimerObstaculos++;
			if (ContadorTimerObstaculos >= taxaAtual) {
				CreateObstacle(quantidadeObs, tipoObs, velocidadeObs, anguloObs);
				CreateRoamingLight(quantidadeVagantes,tipoVagantes,velocidadeVagantes,anguloVagantes);
				ContadorTimerObstaculos=0;

			}

			ContadorTimerLuzes++;
			if (ContadorTimerLuzes >= TaxaDeRepetiçaoLuzes) {
				CreateLight(quantidadeLuz, tipoLuz, velocidadeLuz, anguloLuz);
				ContadorTimerLuzes=0;
			}
			
			ChangeDistance();
			Rotate ();
		}
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
		angle += RotateSpeed;
		Origin = new Vector3 (0 + DistanceToOrigin * Mathf.Cos (angle), 0 + DistanceToOrigin * Mathf.Sin (angle), DistanceToOrigin);


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


			}
			
			g = (GameObject)Instantiate(a,Origin,Quaternion.identity);
			m = g.GetComponent<MoveToScreen> ();
			//Debug.Log(i.ToString() + positions.Peek().ToString());
			m.Destination = positions.Dequeue();
			m.Speed = speed;
			m.angle = angle;
			
		}
		
	}

	void CreateRoamingLight(int quantity, int type,float speed,float angle){
		for (int i = 0; i < quantity; i++) {
			
			GameObject g = null;
			GameObject a =null;
			MoveToScreen m;
			switch (type) {
				
				
			case 0:
				a= RoamingLight;
				break;
				
					
			}
			/*
			g = (GameObject)Instantiate(a,Origin+randomVector(TunnelDistance),Quaternion.identity);
			m = g.GetComponent<MoveToScreen> ();
			float anglePosition = Random.Range(0,2*Mathf.PI);
			m.Destination = new Vector3 (TunnelDistance*2*Mathf.Cos(anglePosition),TunnelDistance*Mathf.Sin(anglePosition),-15);
			m.Speed = speed;
			m.angle = angle;*/

			g = (GameObject)Instantiate(a,Origin,Quaternion.identity);
			m = g.GetComponent<MoveToScreen> ();
			if (Random.Range(0,2)==1) {
				m.Destination = new Vector3 ( Random.Range(-2*TunnelDistance,TunnelDistance),-1*Random.Range(TunnelDistance/4,TunnelDistance/2),-15);
			}else{
				m.Destination = new Vector3 ( Random.Range(-2*TunnelDistance,TunnelDistance),Random.Range(TunnelDistance/4,TunnelDistance/2),-15);
			}

			m.Speed = speed;
			m.angle = angle;


		}
		
	}

	Vector3 randomVector(float a){
		return new Vector3 (Random.Range(-a,a),Random.Range(-a,a),0);
	
	}

	/// <summary>
	/// Creates the obstacle.
	/// </summary>
	/// <param name="quantity">How many obstacles are generated.</param>
	/// <param name="type">Type of the obstacles generated</param>
	/// <param name="speed">Speed of the obstacles</param>
	/// <param name="angle">How much the obstacle bends towards the screen</param>
	void CreateLight(int quantity, int type,float speed,float angle){
		for (int i = 0; i < quantity; i++) {
			
			GameObject g = null;
			GameObject a =null;
			MoveToScreen m;
			switch (type) {

			case 0:
				a= Light0;
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
			//Debug.Log(i.ToString() + positions.Peek().ToString());
			m.Destination = new Vector3 ((int)(4*Random.Range(-dispersionRange,dispersionRange+1)),(int)(4*Random.Range(-dispersionRange,dispersionRange+1)),-15);
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
				newPosition = new Vector3 ((int)(5*Random.Range(-dispersionRange,dispersionRange+1)),(int)(5*Random.Range(-dispersionRange,dispersionRange+1)),-15);
				if (positions.Contains(newPosition)) {
					error =true;
				}					

			}while(error);
			positions.Enqueue(newPosition);
		}
		return positions;

	}





}
