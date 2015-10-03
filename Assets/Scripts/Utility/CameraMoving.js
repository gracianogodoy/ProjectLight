#pragma strict

var target : Transform;
var smooth : float = 5;
var difX : float;
var difY : float;
var limiteX : float = 1;
var limiteY : float = 1;
var distance : float;
function Update () {
	//distance = Vector3.Distance(this.transform, target);
	//difX = distance.x;
	difY = target.position.y - transform.position.y;
	if (difX < 0)
	{
		difX = -difX;
	}
	
	if (difY < 0)
	{
		difY = -difY;
	}
	
	
	if (difX < limiteX)
	{
		this.transform.position.x = Mathf.Lerp(transform.position.x,target.position.x,Time.deltaTime*smooth);
	}
	
    if (difY < limiteX)
    {
    	this.transform.position.y = Mathf.Lerp(transform.position.y,target.position.y,Time.deltaTime*smooth);
    }
   
    
    Debug.Log(""+ difX);
}

