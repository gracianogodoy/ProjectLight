using UnityEngine;
using System.Collections;

public class ObstacleCleaner : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
