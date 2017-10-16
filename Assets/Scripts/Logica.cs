using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;		// Para poder incluir en mando de Xbox

public class Logica : MonoBehaviour 
{

	public float VelocidadMax;
	public XboxController controller;

	private Vector3 newPosition;

    public bool hasWeapon = false;

    public bool canWeapon = false;

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
            if (XCI.GetButton(XboxButton.X, controller))
            {
                Debug.Log("pene");
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


    }

}
