using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;	

public class LifeBar : MonoBehaviour {

    private float hitpoint = 150;
    private float maxHitpoint = 150;

    private AudioSource source;
    public AudioClip Pain;


	//edit guille
	[Header("----- REFERENCIAS")]
	public Image healthBar;
	public Text ratioText;

	//Cosas muerte mirar void update

	public GameObject die;
	Animator anim;

	// Use this for initialization
	void Start () {

        source = GetComponent<AudioSource>();

        UpdateHealthbar();

		Time.timeScale = 1;
		anim.SetBool("isDead", false);

    }
	void Update () {
		if (hitpoint <= 0) {
			Time.timeScale = 0;
			die.SetActive (true);

			if (XCI.GetButtonDown(XboxButton.A)){
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

    private void UpdateHealthbar()
    {
		healthBar.fillAmount = hitpoint / maxHitpoint;
        float ratio = hitpoint / maxHitpoint;
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

	public void TakeDamage (float damage)
    {
        source.PlayOneShot(Pain, 0.2f);

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
		
}
