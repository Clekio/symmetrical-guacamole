using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Boss : MonoBehaviour
{
	[Header("----- REFERENCIAS")]
	public Image healthBar;

    Animator anim;

    public GameObject drop;
    public GameObject sangre;

    public Rigidbody rb;

    Movimiento romperArma;
    public GameObject Enemigo;

    private AudioSource source;

    public bool dep = false;

    public float vidaMaxima = 12f;
	public float vida =12f;



    public AudioClip blood;
    //Cosas guille

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		healthBar.fillAmount = vida / vidaMaxima;
    }


    private void OnTriggerEnter(Collider Weapon)
    {
        if (Weapon.gameObject.tag == "Weapon")
        {
            vida = vida - 1;

            if (vida == 0)
            {
                dep = true;

                GetComponent<CapsuleCollider>().enabled = false;
                //GetComponent<SphereCollider> ().enabled = true;
                rb.isKinematic = true;


                anim.SetBool("isDead", true);
                //GetComponent<Chasing>().enabled = false;
            }

            romperArma = Weapon.GetComponentInParent<Movimiento>();
            if (romperArma != null)
                romperArma.hasDamaged = true;

            source.PlayOneShot(blood, 0.15f);

            //sangre.SetActive(true);

            //drop.SetActive(true);




        }

    }
}
