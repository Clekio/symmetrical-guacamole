using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour {

    public bool inside = false;

    public DoorsEvent door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
