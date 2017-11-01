
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;		// Para poder incluir en mando de Xbox

public class Logica_GM : MonoBehaviour 
{
    Animator anim;

    public float VelocidadMax;
	public XboxController controller;


	private Vector3 newPosition;


    public bool hasWeapon = false;

    public bool canWeapon = false;

    public bool canAttack = true;


    public GameObject weaponE;

    public Rigidbody throwable;

    public GameObject player;

    public GameObject Axe;



    public Transform spawn;


    public float speed;

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



    void Update () 
	{
        // Movimiento del stick izquierdo
        newPosition = transform.position;
		float axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
		float axisY = XCI.GetAxis(XboxAxis.LeftStickY, controller);
		float newPosX = newPosition.x + (axisX * VelocidadMax * Time.deltaTime);
		float newPosZ = newPosition.z + (axisY * VelocidadMax * Time.deltaTime);
		newPosition = new Vector3(newPosX, transform.position.y, newPosZ);
		transform.position = newPosition;


		// Movimiento del stick derecho
		newPosition = transform.position;
		axisX = XCI.GetAxis(XboxAxis.RightStickX, controller);
		axisY = XCI.GetAxis(XboxAxis.RightStickY, controller);
		newPosX = newPosition.x + (axisX * VelocidadMax * 0.3f * Time.deltaTime);
		newPosZ = newPosition.z + (axisY * VelocidadMax * 0.3f * Time.deltaTime);
		newPosition = new Vector3(newPosX, transform.position.y, newPosZ);
		transform.position = newPosition;

        if (hasWeapon == true)
        {
            Axe.GetComponent<SkinnedMeshRenderer>().enabled = true;
            if (XCI.GetButtonDown(XboxButton.X, controller))
            {
                if (canAttack == true)
                {
                    anim.Play("AtaqueHorizontal", -1, 0f);
                    float vol = Random.Range(volLowRange, volHighRange);
                    source.PlayOneShot(AttackSound, vol);
                    canAttack = false;
                    StartCoroutine(Count0());

                }
            }
            if (XCI.GetButton(XboxButton.Y, controller))
            {
                if (canAttack == true)

                {
                    //canAttack = false;
                    hasWeapon = false;

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

        Rigidbody lanzado = Instantiate (throwable, spawn.position, spawn.rotation) as Rigidbody;

        lanzado.velocity = transform.forward * speed;

        


    }

    IEnumerator Count0()
    {


        yield return new WaitForSeconds(0.8f);

        yield return StartCoroutine(Count1());

    }

    IEnumerator Count1()
    {
        weaponE.SetActive(true);
        
        yield return new WaitForSeconds(0.2f);

        yield return StartCoroutine(Count2());

    }

    IEnumerator Count2()
    {
        

        weaponE.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        canAttack = true;

        yield return null;
    }


}
