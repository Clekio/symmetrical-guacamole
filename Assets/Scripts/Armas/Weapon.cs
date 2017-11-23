using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Weapon : MonoBehaviour {

    public XboxController controller;

    public GameObject mainchar;

    public Movimiento coger;

    public bool Pickable = false;



	// Use this for initialization
	void Start () {
        coger = FindObjectOfType<Movimiento>();
    }
	


	// Update is called once per frame
	void FixedUpdate () {



        if (Pickable == true)
        {
            coger.canWeapon = true;


        } else
        {
            coger.canWeapon = false;

        }

        if (Pickable == true && coger.hasWeapon == false)
        {
            if (XCI.GetButton(XboxButton.B, controller))
            {
                coger.canWeapon = false;
                coger.hasWeapon = true;
                coger.hasDamaged = false;
                Destroy(this.gameObject);

            }
        }
    }

   



    private void OnTriggerStay(Collider Player)
    {

        Pickable = true;

    }

    private void OnTriggerExit(Collider Player)
    {

        Pickable = false;
    }
}
