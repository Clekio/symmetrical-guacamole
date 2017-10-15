using UnityEngine;
using System.Collections;

public class Transicion : MonoBehaviour
{
    Animator anim;

    private float inputH;
    private float inputV;


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
    }
}