using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAFacil : MonoBehaviour {

	public float iaTargetDistance;
	public float iaLookDistance;
	public float iaAttackDistance;
	public float iaMovSpeed;
	public float damping;
	public float movimiento;

	public Transform iaTarget;

	//Rigidbody theRigidbody;
	//Renderer myRender;

	// Use this for initialization
	void Start () {
		//myRender = GetComponent<Renderer>();
		//theRigidbody = GetComponent<Rigidbody>();
	}
	
	// {}
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
