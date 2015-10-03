using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{
	public float speed = 1.0f;
	private Vector3 targetPos;

	public Transform playerTransform;
	public Transform cameraTransform;

	public float distance;
	public float distancePosOriginal;
	public float limiteX = 1;
	public float limiteY = 1;
	
	void Start() {
		//targetPos = transform.position;    
	}
	
	void Update () {
		distance = Vector3.Distance (
			new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z), 
			new Vector3(cameraTransform.position.x, cameraTransform.position.y, cameraTransform.position.z));
		if (distance < limiteX)
		{
			cameraTransform.position = new Vector3(
				Mathf.Lerp(cameraTransform.position.x,playerTransform.position.x,Time.deltaTime*speed),
				cameraTransform.position.y);
		}


		Debug.Log ("Distancia entre camera e player: " + distance);
	}
}