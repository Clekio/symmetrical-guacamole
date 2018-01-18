using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using System;

public class Sense : MonoBehaviour
{

    public float checkRadius;

    public LayerMask checkLayers;

    public XboxController controller;

    public Transform enemy;

    public bool cerca;

    float n;

    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Y, controller) || XCI.GetButtonDown(XboxButton.X, controller) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            // if only one, attack that one

            Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
            Array.Sort(colliders, new DistanceComparer(transform));

            foreach(Collider item in colliders)
            {
                Debug.Log(item.name);
            }

            if (colliders.Length >= 1)
            {
                enemy = colliders[0].transform;
                cerca = true;
            }
            else
            {
                cerca = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);



    }


}
