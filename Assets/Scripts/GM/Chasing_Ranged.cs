using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing_Ranged: MonoBehaviour {

//	{} Para copiar
	private Animator anim;
	public Transform player;
	public float EnemySpeed;
	public float EnemyVision;
	public float EnemyAttackRange;

    public Enemy_01 dep;

    public bool death;
    public bool Attacking;


    public Rigidbody throwable;

    public Transform spawn;

    public float speed;

    //Para hacer daño
    public bool damaging;
	public float damage;

	//para lanzar
	public GameObject fireball;

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
	public void FireBall ()
	{

        Rigidbody lanzado = Instantiate(throwable, spawn.position, spawn.rotation) as Rigidbody;

        lanzado.velocity = transform.forward * speed;

    }
}
