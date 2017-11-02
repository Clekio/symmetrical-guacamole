using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class Music : MonoBehaviour {


    

    void Awake()
    {


            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
           

        

    }








}
