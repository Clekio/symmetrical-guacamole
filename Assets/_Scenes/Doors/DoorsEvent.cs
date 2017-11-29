using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsEvent : MonoBehaviour
{
    public Animator anim;

    public OpenDoors inside;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inside.inside == true)
        {

            anim.SetBool("Open", true);

        }

    }


}