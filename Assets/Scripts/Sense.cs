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

    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Y, controller))
        {
            // if only one, attack that one

            Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
            Array.Sort(colliders, new DistanceComparer(transform));

            foreach(Collider item in colliders)
            {
                Debug.Log(item.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);



    }


}
