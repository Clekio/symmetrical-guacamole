using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBoss : MonoBehaviour {

    // Use this for initialization
    void Start () {



        StartCoroutine(Count1());

    }



    IEnumerator Count1()
    {
        yield return new WaitForSeconds(0.4f);

        Destroy(this.gameObject);

        yield return null;
    }
}
