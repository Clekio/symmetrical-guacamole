using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma_rota : MonoBehaviour {

    private AudioSource source;

    public AudioClip broken;

    // Use this for initialization
    void Start () {

        source = GetComponent<AudioSource>();

        source.PlayOneShot(broken, 0.4f);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
