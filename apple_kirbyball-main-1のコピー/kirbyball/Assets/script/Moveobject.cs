using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveobject : MonoBehaviour
{

    private Vector3 initialPosition;

    void Start()
    {

        initialPosition = transform.position;

    }

    void Update()
    {

        transform.position = new Vector3(Mathf.Sin(Time.time) * 2.0f + initialPosition.x, initialPosition.y, initialPosition.z);

    }
}
