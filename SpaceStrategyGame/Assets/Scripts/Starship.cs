using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : MonoBehaviour
{
    public Vector3 accel = new Vector3(0, 0, 0);
    public Vector3 velocity = new Vector3(0, 0, 0); 
    public Vector3 waypoint = new Vector3(0, 0, 0);
    public Quaternion desiredRotation = Quaternion.Euler(0, 0, 0);
}
