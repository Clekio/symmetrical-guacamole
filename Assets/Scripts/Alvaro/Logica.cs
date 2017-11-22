
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;		// Para poder incluir en mando de Xbox

public class Logica : MonoBehaviour
{
    Animator anim;

    public float VelocidadMax;
    public XboxController controller;


    private Vector3 newPosition;

    public Movimiento attacking;

    public bool hasWeapon = false;

    public bool canWeapon = false;

    public bool canAttack = true;

    public bool hasDamaged = false;

    public GameObject weaponE;
    public GameObject weaponE2;
    public GameObject weaponE3;

    public Rigidbody throwable;

    public GameObject player;

    public GameObject Axe;



    public Transform spawn;


    public float speed;
    //public float turnSpeed;


    //para los sonidos
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    public AudioClip AttackSound;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }



    void Update()
    {
        if (hasWeapon == true)
        {

            Axe.GetComponent<SkinnedMeshRenderer>().enabled = true;

            if (XCI.GetButtonDown(XboxButton.X, controller))
            {
                if (canAttack == true)
                {


                    anim.Play("AtaqueHorizontal", -1, 0f);

                    attacking.doAttack = true;

                    canAttack = false;
                    StartCoroutine(Count0());
                    StartCoroutine(Count6());

                }
            }
            if (XCI.GetButton(XboxButton.Y, controller))
            {
                if (canAttack == true)

                {
                    canAttack = false;
                    hasWeapon = false;

                    StartCoroutine(Count3());
                    ThrowIt();


                }
            }
        }

        else
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

    } //Cierra update


    void ThrowIt()
    {

        Rigidbody lanzado = Instantiate(throwable, spawn.position, spawn.rotation) as Rigidbody;

        lanzado.velocity = transform.forward * speed;

        Axe.GetComponent<SkinnedMeshRenderer>().enabled = false;



    }

    IEnumerator Count0()
    {


        yield return new WaitForSeconds(0.8f);

        yield return StartCoroutine(Count1());

    }

    IEnumerator Count1()
    {
        weaponE.SetActive(true);

        //Axe.GetComponent<SkinnedMeshRenderer>().enabled = false;

        yield return new WaitForSeconds(0.2f);



        yield return StartCoroutine(Count2());

    }

    IEnumerator Count2()
    {


        // if (hasWeapon == true)


        weaponE.SetActive(false);
        weaponE3.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(Count4());
        if (hasDamaged == true) hasWeapon = false;
        //else
        //{
        //    weaponE.SetActive(false);
        //    yield return new WaitForSeconds(0.1f);
        //    canAttack = true;
        //    yield return null;
        //}

    }

    IEnumerator Count3()
    {

        yield return new WaitForSeconds(0.2f);
        canAttack = true;

        yield return null;
    }
    IEnumerator Count4()
    {

        weaponE2.SetActive(true);
        weaponE3.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        //canAttack = true;



        yield return StartCoroutine(Count5());
    }
    IEnumerator Count5()
    {


        weaponE2.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        canAttack = true;

        attacking.attacking = false;

        yield return null;
    }
    IEnumerator Count6()
    {
        attacking.attacking = true;

        yield return new WaitForSeconds(0.35f);

        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(AttackSound, vol);

        yield return null;
    }
}
