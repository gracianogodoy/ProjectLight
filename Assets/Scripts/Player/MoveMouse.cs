using UnityEngine;
using System.Collections;

public class MoveMouse : MonoBehaviour
{
    public float speed = 3.0f;
    private Vector3 targetPos;

    public Vector3 minCamera;
    public Vector3 maxCamera;

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        var camera = Camera.main;
        Vector2 mousePos = new Vector2(Mathf.Clamp(Input.mousePosition.x, 0, camera.pixelWidth),
            Mathf.Clamp(Input.mousePosition.y, 0, camera.pixelHeight));
        targetPos = new Vector3(mousePos.x, mousePos.y, distance);
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}