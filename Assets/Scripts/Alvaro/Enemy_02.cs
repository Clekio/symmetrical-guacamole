using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	//Cosas VIDA
	public float health = 100;

	public Image HealthBar;

	// Use this for initialization
	void Start () {

		anim = Enemigo.GetComponent<Animator>();
		source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		HealthBar.fillAmount = health / 100f;
		iaTargetDistance = Vector3.Distance (iaTarget.position, transform.position);
		if(iaTargetDistance<iaLookDistance){
			//myRender.material.color = Color.yellow;
			lookAtPlayer();
			print ("Looking Player");
		}
		if(iaTargetDistance<iaAttackDistance && iaTargetDistance > 2){
			//myRender.material.color = Color.red;
			attackReady();
			print ("Attack");

		}
		if(iaTargetDistance <= 2){
			transform.position  += ((transform.forward * 0) * Time.deltaTime);
			anim.Play("Stab", -1, 0f);
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

		anim.Play("HitReact", -1, 0f);
		health = health - 20;

		if (health <= 0){
			GetComponent<CapsuleCollider>().enabled = false;

			anim.Play("Dying", -1, 0f);

			GetComponent<Enemy_02> ().enabled = false;
		}

	}

	void lookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation (iaTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation, Time.deltaTime*damping);
		anim.Play("Walking", -1, 0f);
	}

	void attackReady(){
		transform.position += ((transform.forward * movimiento) * Time.deltaTime);
	}
}
