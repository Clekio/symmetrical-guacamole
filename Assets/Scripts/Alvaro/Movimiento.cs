using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;		// Para poder incluir en mando de Xbox

public class Movimiento : MonoBehaviour {

    Animator anim;



    public float speed;
    public float speed2;
    public float Vgiro;

    private Vector2 input;
    float angle;

    Quaternion pRotation;
    public Transform obj;

    public bool attacking = false;

    private AudioSource source;

    public AudioClip stepSound;

	public bool doAttack = false;
    bool doAttackMove = false;

    public GameObject slash;

    public GameObject armaRota;

    public float VelocidadMax;
    public XboxController controller;


    private Vector3 newPosition;

    public bool hasWeapon = false;
    public bool canWeapon = false;
    public bool canAttack = true;
    public bool hasDamaged = false;

    public List<GameObject> weaponTriggers;

    public Rigidbody throwable;

    public Transform spawn;

    public GameObject player;

    public GameObject Axe;

    public GameObject Area1;
    public GameObject Area2;
    public GameObject Area3;

    private float volLowRange = 0.3f;
    private float volHighRange = 0.5f;

    public AudioClip AttackSound;
    public AudioClip ArmaRota;
    public AudioClip CogerArma;


    // Use this for initialization
    void Start () {

        //obj = Camera.main.transform;
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

	
	// Update is called once per frame
	void FixedUpdate () {
        CheckAttack();
        if (attacking == false)
        {
            
            GetInput();
            CalculateDirection();
            Rotate();
            Move();
            anim.SetFloat("input", (input.x * Vector3.right + input.y * Vector3.forward).magnitude);

        }
        else if (doAttackMove == true)
        {
            AttackMove();
            anim.SetFloat("input", 0);
        }

    }




    void CheckAttack() {
        if (hasWeapon == true)
        {
            Axe.GetComponent<SkinnedMeshRenderer>().enabled = true;

            if (canAttack == true && XCI.GetButtonDown(XboxButton.X, controller))
            {
                anim.SetTrigger("Attack");
                canAttack = false;
                attacking = true;
            }
            if (canAttack == true && XCI.GetButton(XboxButton.Y, controller))
            {
                
                anim.SetTrigger("Lanzar");
                canAttack = false;
                attacking = true;
                //hasWeapon = false;
            }
        }else
        {
            Axe.GetComponent<SkinnedMeshRenderer>().enabled = false;
            if (canWeapon == true)
            {
                if (XCI.GetButton(XboxButton.B, controller))
                {
                    hasWeapon = true;
                }
            }
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
        if((input.x * Vector3.right + input.y * Vector3.forward).magnitude > 0.2f && !attacking)
            transform.rotation = Quaternion.Slerp(transform.rotation, pRotation, Vgiro * Time.deltaTime);

    }

    private void Move()
    {
        transform.position += (input.x * Vector3.right + input.y*Vector3.forward) * speed * Time.deltaTime;

    
    }

    public void Paso()
    {
        source.PlayOneShot(stepSound, 0.005f);
    }
    public float speedAttackMove = 8;
    public void AttackMove()
    {
        transform.position += transform.forward * speedAttackMove * Time.deltaTime;
    }

    public void DamagedMove()
    {
        transform.position -= transform.forward * speedAttackMove * Time.deltaTime;
    }

    public void SonidoCogerArma()
    {

        source.PlayOneShot(CogerArma, 0.3f);
    }

    /*
    *
    *Funciones para eventos animacion
    *
    */
    
    public void ParticlesOn()
    {
        slash.SetActive(true);
        Debug.Log("pene");
    }
    public void ParticlesOff()
    {
        slash.SetActive(false);
        Debug.Log("pene");
    }


    public void ActivateSound()
    {
        
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(AttackSound, vol);
    }

    public void ActivateAttackMove()
    {
        slash.SetActive(true);
        doAttackMove = true;
    }
    public void EndAttackMove()
    {
        doAttackMove = false;
    }

    public void ThrowIt()
    {
        Rigidbody lanzado = Instantiate(throwable, spawn.position, spawn.rotation) as Rigidbody;

        lanzado.velocity = transform.forward * speed2;
    }

    public void EndAttack() {

        weaponTriggers[2].SetActive(false);
        slash.SetActive(false);
        attacking = false;
        doAttackMove = false;
        canAttack = true;
        if (hasDamaged == true)

        {
            hasWeapon = false;
            armaRota.SetActive(true);
            StartCoroutine(Count1());
            source.PlayOneShot(ArmaRota, 0.1f);
        }
    }

    public void CleanWeapon()
    {
        //Axe.GetComponent<SkinnedMeshRenderer>().enabled = false;
        hasWeapon = false;

    }

    public void Trigger1()
    {
        Area1.SetActive(true);
    }
    public void Trigger2()
    {
        Area1.SetActive(false);
        Area2.SetActive(true);
    }
    public void Trigger3()
    {
        Area2.SetActive(false);
        Area3.SetActive(true);
    }
    public void Trigger4()
    {
        Area3.SetActive(false);
    }

    IEnumerator Count1()
    {

        yield return new WaitForSeconds(0.5f);
        armaRota.SetActive(false);

        yield return null;
    }

    //    void ActivateAttackTrigger(int triggerNumber)
    //    {
    //        if (triggerNumber < weaponTriggers.Count)
    //        {
    //            weaponTriggers[triggerNumber].SetActive(true);
    //        }
    //        if(triggerNumber > 0 && triggerNumber <= weaponTriggers.Count)
    //        {
    //            weaponTriggers[triggerNumber-1].SetActive(false);
    //        }

    //    }
}
