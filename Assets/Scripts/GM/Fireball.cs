using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public Rigidbody rb;

    public Chasing_Ranged direction;

    //Para hacer daño
    public bool damaging;
    public float damage;

    private AudioSource source;

    public AudioClip fire;

    // Use this for initialization
    void Start () {

        source = GetComponent<AudioSource>();

        source.PlayOneShot(fire, 0.1f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
            if (other.tag == "Player")
            {

                    other.SendMessage((damaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);


            }

        
        Destroy(this.gameObject);
    }
}
