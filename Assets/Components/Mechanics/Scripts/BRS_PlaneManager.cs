using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRS_PlaneManager : MonoBehaviour {

    public GameObject Map;
    public float Airspeed;

    void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * Airspeed;
    }
}
