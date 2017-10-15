using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion: MonoBehaviour {

	Animator anim;
	


	void Start ()
	{
		anim = GetComponent<Animator>();
	}


	void Update ()
	{
		float move = Input.GetAxis ("Vertical");
		anim.SetFloat("Walk", move);
       

        float move2 = Input.GetAxis("VerticalNegative");
        anim.SetFloat("Back", move2);

     

    //    AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
	//	if(Input.GetKeyDown(KeyCode.Space) && stateInfo.nameHash == runStateHash)
	//	{
	//		anim.SetTrigger (jumpHash);
	//	}
	}
}
