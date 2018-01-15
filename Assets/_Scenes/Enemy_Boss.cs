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

    public AudioClip stepSound;
    public AudioClip stomp1;
    public AudioClip muerto;

    public AudioClip blood;

    public GameObject WIN;
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
        if (vida <= 6)
        {
            anim.SetBool("isFase1", false);

        }
        else
        {
            anim.SetBool("isFase1", true);
        }
        if (vida <= 0)
        {

            WIN.SetActive(true);
        }


    }


    private void OnTriggerEnter(Collider Weapon)
    {
        if (Weapon.gameObject.tag == "Weapon")
        {
            vida = vida - 1;
            StartCoroutine(Sangre());
            if (vida == 0)
            {
                source.PlayOneShot(muerto, 0.15f);
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

    public void Ataque()
    {
        source.PlayOneShot(muerto, 0.3f);
    }

    public void paso()
    {

        source.PlayOneShot(stepSound, 0.4f);

    }

    public void stomp()
    {

        source.PlayOneShot(stomp1, 0.7f);

    }
    IEnumerator Sangre()
    {
        sangre.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sangre.SetActive(false);


        yield return null;
    }



}
