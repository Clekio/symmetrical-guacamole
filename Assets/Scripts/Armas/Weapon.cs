using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Weapon : MonoBehaviour {

    public XboxController controller;

    public GameObject mainchar;

    public Movimiento coger;

    public DoorsEventW door;

    public bool Pickable = false;

    public bool primeraPuerta = false;




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
            if (XCI.GetButton(XboxButton.B, controller) || Input.GetKeyDown(KeyCode.K))
            {
                coger.SonidoCogerArma();

                coger.canWeapon = false;
                coger.hasWeapon = true;
                coger.hasDamaged = false;
                Destroy(this.gameObject);

            }
        }
    }

   



    private void OnTriggerStay(Collider Player)
    {

        if (Player.gameObject.tag == "Player") {

            Pickable = true;
        }
    }

    private void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            Pickable = false;
        }
    }
}
