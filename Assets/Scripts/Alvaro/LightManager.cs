using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {


    public GameObject bloque;
    public GameObject bloque2;

    //public Light luz1;
    //public Light luz2;
    //public Light luz3;
    //public Light luz4;
    //public Light luz5;


    private void OnTriggerExit(Collider Player)
    {

        //luz1.enabled = !luz1.enabled;

        StartCoroutine(Count0());

        //bloque.SetActive(true);

    }


    IEnumerator Count0()
    {


        yield return new WaitForSeconds(0.3f);

        bloque.SetActive(true);
        bloque2.SetActive(false);

        yield return null;

    }

}
