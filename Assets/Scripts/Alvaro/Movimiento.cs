using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;		// Para poder incluir en mando de Xbox

public class Movimiento : MonoBehaviour {

    Animator anim;
    public float speed;
    public float Vgiro;

    private Vector2 input;
    float angle;

    Quaternion pRotation;
    public Transform obj;

    public bool attacking = false;

    private AudioSource source;

    public AudioClip stepSound;

    bool paso = true;
    public bool doAttack = false;
    bool doAttackMove = false;


    public float VelocidadMax;
    public XboxController controller;


    private Vector3 newPosition;

    public bool hasWeapon = false;
    public bool canWeapon = false;
    public bool canAttack = true;
    public bool hasDamaged = false;

    public List<GameObject> weaponTriggers;

    public Rigidbody throwable;

    public GameObject player;

    public GameObject Axe;
    
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    public AudioClip AttackSound;


    // Use this for initialization
    void Start () {

        obj = Camera.main.transform;
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

	
	// Update is called once per frame
	void Update () {
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
                anim.SetTrigger("Attack");
                canAttack = false;
                hasWeapon = false;
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
        source.PlayOneShot(stepSound, 0.03f);
    }
    public float speedAttackMove = 8;
    public void AttackMove()
    {
        transform.position += transform.forward * speedAttackMove * Time.deltaTime;
    }


    /*
    *
    *Funciones para eventos animacion
    *
    */
    public void ActivateAttackMove()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(AttackSound, vol);
        doAttackMove = true;
    }
    public void EndAttackMove()
    {
        doAttackMove = false;
    }

    public void EndAttack() {
        attacking = false;
        doAttackMove = false;
        canAttack = true;
        if (hasDamaged == true) hasWeapon = false;
    }
    
    void ActivateAttackTrigger(int triggerNumber)
    {
        if (triggerNumber < weaponTriggers.Count)
        {
            weaponTriggers[triggerNumber].SetActive(true);
        }
        if(triggerNumber > 0 && triggerNumber <= weaponTriggers.Count)
        {
            weaponTriggers[triggerNumber-1].SetActive(false);
        }

    }
}
