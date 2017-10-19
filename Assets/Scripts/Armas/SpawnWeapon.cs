using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour {

    //public GameObject arma1;
    public GameObject arma1;
    public Transform spawn;

	// Use this for initialization
	void Start () {

        Instantiate(arma1, spawn.position, spawn.rotation);


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
