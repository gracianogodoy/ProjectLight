using UnityEngine;
using System.Collections;

public class ObstacleCleaner : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle" || other.tag == "Light")
        {
            Destroy(other.gameObject);
        }
    }
}
