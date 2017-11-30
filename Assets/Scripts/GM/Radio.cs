using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio: MonoBehaviour {

	public GameObject Boom;
	public GameObject Sangre1;
	public GameObject Sangre2;
	public GameObject Sangre3;
	public GameObject Modelo;

    private AudioSource source;
    public AudioClip boom;

    [Range(0.1f, 100f)]
	public float radius = 1.0f;

	[Range(3, 256)]
	public int numSegments = 128;

	void Start ( ) {
		DoRenderer();

        source = GetComponent<AudioSource>();

    }

	public void DoRenderer ( ) {
		LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetVertexCount(numSegments + 1);
		lineRenderer.useWorldSpace = false;

		float deltaTheta = (float) (2.0 * Mathf.PI) / numSegments;
		float theta = 0f;

		for (int i = 0 ; i < numSegments + 1 ; i++) {
			float x = radius * Mathf.Cos(theta);
			float z = radius * Mathf.Sin(theta);
			Vector3 pos = new Vector3(x, 0, z);
			lineRenderer.SetPosition(i, pos);
			theta += deltaTheta;
		}
	}
	private void attacking ()
	{
		GetComponent<LineRenderer>().enabled = false;
        source.PlayOneShot(boom, 1f);
        Boom.SetActive(true);
		Sangre1.SetActive(true);
		Sangre2.SetActive(true);
		Sangre3.SetActive(true);
		Modelo.SetActive(false);

        StartCoroutine(Count1());


    }


    IEnumerator Count1()
    {

        yield return new WaitForSeconds(2.2f);

        Destroy(this.gameObject);

        yield return null;
    }


}