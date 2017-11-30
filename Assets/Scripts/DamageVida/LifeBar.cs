using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {

    public Image currentHealth;
    public Text ratioText;

    private float hitpoint = 150;
    private float maxHitpoint = 150;

    private AudioSource source;

    public AudioClip pain;

	// Use this for initialization
	void Start () {

        UpdateHealthbar();
        source = GetComponent<AudioSource>();

    }


    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

	public void TakeDamage (float damage)
    {
        source.PlayOneShot(pain, 0.2f);

        hitpoint -= damage;
        if (hitpoint < 0)
        {
            hitpoint = 0;

        }

        UpdateHealthbar();

    }

    public void HealDamage (float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
        {
            hitpoint = maxHitpoint;

        }

        UpdateHealthbar();
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
