using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipMovement : MonoBehaviour
{
    Transform transfrom;
    Starship starship;

    public float rotSpeed;

    void Awake()
    {
        transfrom = GetComponent<Transform>();
        starship = GetComponent<Starship>();
    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                starship.waypoint = hit.point;
            }
        }

        if(transform.position != starship.waypoint)
        {
            Quaternion desiredRotation = starship.desiredRotation = Quaternion.LookRotation(starship.waypoint - transform.position);
            if(!EqualsWithinRange(transform.rotation, desiredRotation, 3f))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotSpeed * .1f);
                if(Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("Not within range!");
                    Debug.Log($"{(Mathf.Abs(transform.rotation.x - desiredRotation.x))}  {(Mathf.Abs(transform.rotation.y - desiredRotation.y)) } {(Mathf.Abs(transform.rotation.z - desiredRotation.z))}");
                }
            }
            else
            {
                transform.position += UnitVectorFromRot() * .1f * Time.deltaTime;
                if(Input.GetKey(KeyCode.Space))
                {
                    Debug.Log("Within range!");
                }
            }
        }
    }

    bool EqualsWithinRange(Quaternion q1, Quaternion q2, float range)
    {
        return (Mathf.Abs(q1.x - q2.x) <= range) &&
        (Mathf.Abs(q1.y - q2.y) <= range) &&
        (Mathf.Abs(q1.z - q2.z) <= range);
    }

    Vector3 UnitVectorFromRot()
    {
        float x = Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
        float y = -Mathf.Sin(transform.rotation.eulerAngles.x * Mathf.Deg2Rad);
        float z = Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);

        return new Vector3(x, y, z);
    }
}
