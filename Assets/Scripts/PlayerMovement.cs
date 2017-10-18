﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;		// Para poder incluir en mando de Xbox

public class PlayerMovement : MonoBehaviour 
{

	public float VelocidadMax;
	public XboxController controller;
    public Animator animator;
    public float desiredSpeed;

	private Vector3 newPosition;

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

        if (XCI.GetButtonDown(XboxButton.B, controller))
        {
            StartCoroutine(Correr());
        }
    }
    IEnumerator Correr()
    {
        VelocidadMax = VelocidadMax * 5;
        animator.speed = 5;
        yield return new WaitForSeconds(3f);
        VelocidadMax = 5;
        animator.speed = 1;
    }

}
