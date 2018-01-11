using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing_Boss2: MonoBehaviour {

	//	{} Para copiar
	private Animator anim;
	[Header("----- REFERENCIAS")]
	public Transform player;
	public Enemy_Boss dep;
	public GameObject PartPisada;
    public GameObject PartSwipe;

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
		GetComponent<Chasing_Boss> ().enabled = false;
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
				anim.SetBool("isStomp", false);
			}
			else{
				anim.SetBool("isWalking", false);
				anim.SetBool("isStomp", true);

			}
		}

		death = dep.dep;

		if (death == true)
		{
			//Stop();
			//EndHit();
		}

	}
	//cosas de alvaro
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
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

	//public void Hit()
	//{ 
	//	GetComponent<BoxCollider>().enabled = true;


	//}
	//public void EndHit()
	//{ 
	//	GetComponent<BoxCollider>().enabled = false;
	//	//Attacking = false;

	//}
	public void pisoton(){
		PartPisada.SetActive(true);
		GetComponent<SphereCollider> ().enabled = true;
	}
	public void pisotonOff(){
		PartPisada.SetActive(false);
		GetComponent<SphereCollider> ().enabled = false;
	}
    public void swipe()
    {
        PartSwipe.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
    }
    public void swipeOff()
    {
        PartSwipe.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
    }

}
