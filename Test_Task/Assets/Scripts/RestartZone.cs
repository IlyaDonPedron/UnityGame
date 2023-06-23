using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartZone : MonoBehaviour
{
    public GameObject playerCar;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            playerCar.transform.position = spawnPoint.position;
            playerCar.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
