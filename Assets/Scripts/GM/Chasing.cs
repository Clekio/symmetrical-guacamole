using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour {

//	{} Para copiar
	static Animator anim;
	public Transform player;
	public float EnemySpeed;
	public float EnemyVision;
	public float EnemyAttackRange;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(player.position, this.transform.position) < EnemyVision) {
			
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
		else{
			anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isAttacking", false);

		}
	}
}
