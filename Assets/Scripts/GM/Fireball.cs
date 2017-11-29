using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	// Use this for initialization
	void Start () {

      
    }
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime;
	}
	IEnumerator waitBox(){
		yield return new WaitForSeconds (1);
		GetComponent<BoxCollider>().enabled = true;

	}
}
