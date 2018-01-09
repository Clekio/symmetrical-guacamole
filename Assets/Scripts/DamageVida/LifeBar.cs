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

    public GameObject feedback;

    public bool alive = true;

    //edit guille
    [Header("----- REFERENCIAS")]
	public Image healthBar;
	public Text ratioText;
    public GameObject cam1;
    public GameObject cam2;

    //Cosas muerte mirar void update

    public GameObject die;
	Animator anim;
    public bool isDead;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        UpdateHealthbar();

		Time.timeScale = 1;
		anim.SetBool("isDead", false);

    }
	void Update () {
		if (hitpoint <= 0) {
            anim.SetBool("isDead", true);
            StartCoroutine(Muerte());

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

        feedback.SetActive(true);

        StartCoroutine(Count1());

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

    IEnumerator Count1()
    {

        yield return new WaitForSeconds(0.1f);
        feedback.SetActive(false);

        yield return null;
    }
    IEnumerator Muerte()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        Time.timeScale = 0;
        die.SetActive(true);
        alive = false;


        yield return null;
    }

}
