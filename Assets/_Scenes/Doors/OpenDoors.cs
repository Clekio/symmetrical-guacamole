using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {

    public bool inside = false;

    public DoorsEvent door;

    public float contador;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (contador == 0)
        {
            inside = true;


        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inside = true;

            door.SonidoPuertaAbierta();

        }

    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        inside = false;

    //    }

    //}


}
