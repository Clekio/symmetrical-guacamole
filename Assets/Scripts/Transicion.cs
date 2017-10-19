using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class Transicion : MonoBehaviour
{
    Animator anim;
    public XboxController controller;

    private float inputH;
    private float inputV;
    public GameObject MainChar;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

    if (XCI.GetButtonDown(XboxButton.X, controller))
        {
            //anim.Play("AtaqueHorizontal", -1, 0f);
            StartCoroutine(Congelar());
        }
    }

    IEnumerator Congelar()
    {
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        //MainChar.GetComponent<PlayerMovement>().enabled = false;
        MainChar.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(2.2f);
        //MainChar.GetComponent<PlayerMovement>().enabled = true;
        MainChar.GetComponent<CapsuleCollider>().enabled = true;
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
}