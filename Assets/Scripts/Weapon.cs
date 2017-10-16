﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Weapon : MonoBehaviour {

    public XboxController controller;

    public Logica coger;

    public bool Pickable = false;



	// Use this for initialization
	void Start () {
		
	}
	


	// Update is called once per frame
	void Update () {
		
        if (Pickable == true)
        {
            coger.canWeapon = true;


        } else
        {
            coger.canWeapon = false;

        }


	}


    private void OnTriggerEnter(Collider other)
    {

        Pickable = true;


        if (XCI.GetButton(XboxButton.B, controller))
        {

            Destroy(this.gameObject);

        }

    }

    private void OnTriggerExit(Collider other)
    {

        Pickable = false;
            


    }
}
