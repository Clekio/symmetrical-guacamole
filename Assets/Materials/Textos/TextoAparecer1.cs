using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoAparecer1 : MonoBehaviour
{
    public Image Texto;
    public bool coolingDown;
    public float waitTime = 10.0f;

    public GameObject trigger1;

    // Update is called once per frame


    private void OnTriggerEnter(Collider Weapon)
    {
        if (Weapon.gameObject.tag == "Weapon")
        {
            trigger1.SetActive(true);
        }


    }
}