using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsEventW : MonoBehaviour
{
    public Animator anim;

    public WeaponDoor open;

    private AudioSource source;

    public AudioClip OpenDoor;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent <AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {


        if (open.primeraPuerta == true)
        {
            anim.SetBool("Open", true);
        }

    }

    public void SonidoPuertaAbierta()
    {

        source.PlayOneShot(OpenDoor, 0.2f);

    }

}