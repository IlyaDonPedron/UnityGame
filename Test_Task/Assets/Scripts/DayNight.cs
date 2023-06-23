using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    private float speed=10f;
    
    void Update()
    {
        transform.Rotate(speed*Time.deltaTime,0,0); 
    }
}
