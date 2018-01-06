using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoors : MonoBehaviour
{
    public Animator anim;

    public OpenDoors inside;

    public DoorsEvent close;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (inside.inside == true)
    //    {

    //        anim.Play("CloseDoor");


    //    }

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")

        {
          
            close.close = true;
        }
    }


}