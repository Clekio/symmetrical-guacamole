using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour {

    public GameObject camera1;
    public GameObject camera2;

    private void OnTriggerEnter(Collider Player)
    {
        camera1.SetActive(false);
        camera2.SetActive(true);

    }

    private void OnTriggerExit(Collider Player)
    {
        camera1.SetActive(true);
        camera2.SetActive(false);

    }

}
