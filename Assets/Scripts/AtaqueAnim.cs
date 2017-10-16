using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;		// Para poder incluir en mando de Xbox

public class AtaqueAnim : MonoBehaviour
{
    Animator anim;

    public float VelocidadMax;
    public XboxController controller;

    private Vector3 newPosition;

    public bool hasWeapon = false;

    public bool canWeapon = false;

    public bool canAttack = true;

    public GameObject weaponE;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
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
            if (XCI.GetButtonDown(XboxButton.X, controller))
            {
                if (canAttack == true)
                {

                    canAttack = false;
                    StartCoroutine(Count1());

                }
            }
            if (XCI.GetButton(XboxButton.Y, controller))
            {
                Debug.Log("pene");
            }

        }
        else
        {
            if (canWeapon == true)
            {
                if (XCI.GetButton(XboxButton.B, controller))
                {
                    hasWeapon = true;



                }
            }
        }


    } //Cierra update



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
