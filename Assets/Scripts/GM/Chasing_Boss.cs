﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing_Boss: MonoBehaviour {

//	{} Para copiar
	private Animator anim;
	[Header("----- REFERENCIAS")]
	public Transform player;
	public Enemy_01 dep;

	[Header("----- SONIDOS")]

	[Header("----- OTROS")]
	public float EnemySpeed;
	public float EnemyVision;
	public float EnemyAttackRange;


    public bool death;
    public bool Attacking;


    //Para hacer daño
    public bool damaging;
	public float damage;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

  

		if(Vector3.Distance(player.position, this.transform.position) < EnemyVision && (Attacking == false) && (death == false)) {
			
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation,
				Quaternion.LookRotation (direction), 0.1f);
			anim.SetBool("isIdle", false);

			if(direction.magnitude > EnemyAttackRange){
				anim.SetBool("isRoar", true);
				anim.SetBool("isIdle", false);
			}
		
		}
	}


//Locura
	private void Roar(){
		//EJECUTAR SONIDO AQUI

	}
	private void RoarEnd(){
		anim.SetBool("isRoar", false);
		anim.SetBool("isIdle", true);
		GetComponent<Chasing_Boss2>().enabled = true;
	}
}

