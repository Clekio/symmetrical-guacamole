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
		romperArma = Weapon.GetComponentInParent<Movimiento>();
		if (romperArma != null)
			romperArma.hasDamaged = true;

		source.PlayOneShot(blood, 0.3f);
		anim.Play("HitReact", -1, 0f);
		sangre.SetActive (true);

		}

}
