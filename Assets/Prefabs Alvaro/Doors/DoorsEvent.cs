using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsEvent : MonoBehaviour
{
    public Animator anim;

    public OpenDoors inside;

    private AudioSource source;

    public AudioClip OpenDoor;

    public bool close = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if (inside.inside == true)
        {

            anim.SetBool("Open", true);

        }

        if (close == true)
        {

            anim.SetBool("Close", true);

        }


    }

    public void SonidoPuertaAbierta()
    {

        source.PlayOneShot(OpenDoor, 0.3f);

    }


}