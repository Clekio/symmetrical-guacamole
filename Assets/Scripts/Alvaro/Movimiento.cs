﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    public float speed;
    public float Vgiro;

    private Vector2 input;
    float angle;

    Quaternion pRotation;
    public Transform obj;

    Animator anim;

    public bool attacking = false;

    private AudioSource source;

    public AudioClip stepSound;

    bool paso = true;

    // Use this for initialization
    void Start () {

        obj = Camera.main.transform;
        source = GetComponent<AudioSource>();
    }

	
	// Update is called once per frame
	void Update () {

        if (attacking == false)
        {
            
            GetInput();

            if (Mathf.Abs(input.x) < 0.2 && Mathf.Abs(input.y) < 0.2) return;

            CalculateDirection();
            Rotate();
            Move();

        }
    }

    void GetInput()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

    }

    void CalculateDirection()
    {

        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += obj.eulerAngles.y;

    }


    void Rotate()
    {
        pRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, pRotation, Vgiro * Time.deltaTime);

    }

    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (paso == true) {
            source.PlayOneShot(stepSound, 0.03f);
            paso = false;

            StartCoroutine(Count0());
        }

    }


    IEnumerator Count0()
    {
        
        yield return new WaitForSeconds(0.38f);

        paso = true;
        yield return null;

    }

}
