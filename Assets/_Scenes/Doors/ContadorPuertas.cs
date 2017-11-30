using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorPuertas : MonoBehaviour {

    public float contador;

    public bool inside = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (contador <= 0)
        {
            inside = true;
        

        }
		
	}
}
