using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02 : MonoBehaviour {

	Animator anim;

	public GameObject drop;
	public GameObject sangre;

	Movimiento romperArma;
	public GameObject Enemigo;

	private AudioSource source;

	public AudioClip blood;

	//Cosas Guille
	public float iaTargetDistance;
	public float iaLookDistance;
	public float iaAttackDistance;
	public float iaMovSpeed;
	public float damping;
	public float movimiento;

	public Transform iaTarget;

	// Use this for initialization
	void Start () {

		anim = Enemigo.GetComponent<Animator>();
		source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		iaTargetDistance = Vector3.Distance (iaTarget.position, transform.position);
		if(iaTargetDistance<iaLookDistance){
			//myRender.material.color = Color.yellow;
			lookAtPlayer();
			print ("Looking Player");

		}
		if(iaTargetDistance<iaAttackDistance){
			//myRender.material.color = Color.red;
			attackReady();
			print ("Attack");

		}
		else{
			//myRender.material.color = Color.blue;

		}


	}


	private void OnTriggerEnter(Collider Weapon)
	{
		romperArma = Weapon.GetComponentInParent<Movimiento>();
		if (romperArma != null)
			romperArma.hasDamaged = true;

		source.PlayOneShot(blood, 0.3f);

		sangre.SetActive (true);

		drop.SetActive(true);

		GetComponent<CapsuleCollider>().enabled = false;



		anim.Play("Dying", -1, 0f);

	}

	void lookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation (iaTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation, Time.deltaTime*damping);
		//theRigidbody.velocity = transform.forward * Time.deltaTime * 0;
	}

	void attackReady(){
		//theRigidbody.velocity = transform.forward * Time.deltaTime * iaMovSpeed;
		transform.position += ((transform.forward * movimiento) * Time.deltaTime);
	}
}
