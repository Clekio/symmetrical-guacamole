using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowThings : MonoBehaviour {

    public Rigidbody rb;

    public Movimiento direction;

    

    public Transform spawn;

    public GameObject prefab;

    public AudioClip broken;

    // Use this for initialization
    void Start () {

        

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(prefab, spawn.position, spawn.rotation);

        Destroy(this.gameObject);

        //Destroy(this.gameObject);
    }
    //public void OnTriggerEnter(Collider other)
    //{

    //    source.PlayOneShot(broken, 0.4f);

    //    Destroy(this.gameObject);
    //}


    //IEnumerator Count1()
    //{
    //    yield return new WaitForSeconds(0.2f);

    //    Instantiate(prefab, spawn.position, spawn.rotation);

    //    Destroy(this.gameObject);

    //    yield return null;
    //}
}
