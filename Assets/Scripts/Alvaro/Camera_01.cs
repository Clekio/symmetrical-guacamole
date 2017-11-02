using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_01 : MonoBehaviour {


    public Transform target;

    public float smoothSpeed = 0.1f;

    public Vector3 offset;




    void Update () {




        Vector3 secondPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, secondPosition, smoothSpeed);

        transform.position = smoothedPosition;


        transform.LookAt(target);
        
	}
}
