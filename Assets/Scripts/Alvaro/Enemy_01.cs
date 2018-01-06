using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01 : MonoBehaviour {

    Animator anim;

    public OpenDoors cont;

    public GameObject drop;
	public GameObject sangre;

    public Rigidbody rb;

    Movimiento romperArma;
    public GameObject Enemigo;

    private AudioSource source;

    public bool dep = false;

    public AudioClip blood;
	//Cosas guille

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {


	}

    
    private void OnTriggerEnter(Collider Weapon)
    {
        if (Weapon.gameObject.tag == "Weapon")
        {

            if (dep == false)
            {
                gameObject.layer = 0;

                dep = true;

                cont.contador = cont.contador - 1;
            }
           

            romperArma = Weapon.GetComponentInParent<Movimiento>();
            if (romperArma != null)
                romperArma.hasDamaged = true;

            source.PlayOneShot(blood, 0.15f);

            sangre.SetActive(true);

            drop.SetActive(true);

            GetComponent<CapsuleCollider>().enabled = false;
            //GetComponent<SphereCollider> ().enabled = true;
            rb.isKinematic = true;


            anim.SetBool("isDead", true);
            //GetComponent<Chasing>().enabled = false;

        } else if (Weapon.gameObject.tag == "Bomba")
        {
            if (dep == false)
            {
                dep = true;

                cont.contador = cont.contador - 1;
            }

            source.PlayOneShot(blood, 0.15f);

            sangre.SetActive(true);

            drop.SetActive(true);

            GetComponent<CapsuleCollider>().enabled = false;
            //GetComponent<SphereCollider> ().enabled = true;
            rb.isKinematic = true;


            anim.SetBool("isDead", true);

        }


    }

}
