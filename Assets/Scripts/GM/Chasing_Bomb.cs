﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing_Bomb: MonoBehaviour {

//	{} Para copiar
	private Animator anim;
	public Transform player;
	public float EnemySpeed;
	public float EnemyVision;
	public float EnemyAttackRange;

    public Enemy_01 dep;

    public bool death;
    public bool Attacking;


    //Para hacer daño
    public bool damaging = false;
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
				this.transform.Translate (0, 0, EnemySpeed);
				anim.SetBool("isWalking", true);
				anim.SetBool("isAttacking", false);
			}
			else{
				anim.SetBool("isWalking", false);
				anim.SetBool("isAttacking", true);

			}
		}

        death = dep.dep;

        if (death == true)
        {
            //Stop();
            EndHit();
        }

    }
	//cosas de alvaro
	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Player")
		{
            if (death == false)
            {
                other.SendMessage((damaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
            }
		}

	}

    public void Stop()
    {
        Attacking = true;
    }
    public void NonStop()
    {
        Attacking = false;
    }

    public void Hit()
	{ 
		GetComponent<BoxCollider>().enabled = true;
        

	}
	public void EndHit()
	{ 
		GetComponent<BoxCollider>().enabled = false;
        //Attacking = false;

	}
	private void attacking ()
	{
        damaging = true;
        GetComponent<SphereCollider>().enabled = true;
		GetComponent<Radio>().enabled = false;
	}

    private void stopDamage()
    {
        GetComponent<SphereCollider>().enabled = false;

    }
	private void Radio ()
	{
        
		GetComponent<Radio>().enabled = true;
		GetComponent<Chasing_Bomb>().enabled = false;
	}
}
