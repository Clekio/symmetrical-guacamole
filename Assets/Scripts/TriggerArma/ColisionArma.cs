using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionArma : MonoBehaviour {

    private AudioSource source;

    public AudioClip blood;

    // Use this for initialization
    void Start () {

        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")

        {
            Debug.Log("pene");
            source.PlayOneShot(blood, 0.3f);

        }
        
    }

}
