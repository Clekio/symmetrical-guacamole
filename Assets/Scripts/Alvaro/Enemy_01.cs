using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01 : MonoBehaviour {

    Animator anim;

    public GameObject drop;

    public Logica romperArma;
    public GameObject Enemigo;

    private AudioSource source;

    public AudioClip blood;

    // Use this for initialization
    void Start () {

        anim = Enemigo.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		


	}

    
    private void OnTriggerEnter(Collider Weapon)
    {
        source.PlayOneShot(blood, 0.3f);

        drop.SetActive(true);

        romperArma.hasDamaged = true;

        GetComponent<CapsuleCollider>().enabled = false;

        

        anim.Play("Dying", -1, 0f);

    }
}
