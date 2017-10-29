using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GM: MonoBehaviour {

    Animator anim;

    public GameObject Enemigo;
    public GameObject drop;

    public Logica_GM romperArma;

    //private Rigidbody rBody; Haciendo pruebas para cuando muere

    // Use this for initialization
    void Start () {
        anim = Enemigo.GetComponent<Animator>();
        //rBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		


	}

    
    private void OnTriggerEnter(Collider Weapon)
    {

        drop.SetActive(true);

        romperArma.hasWeapon = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<BoxCollider>().enabled = true;
        //rBody.detectCollisions = false;
        anim.Play("Dying", -1, 0f);

        //Destroy(this.gameObject);

    }
}
