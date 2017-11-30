using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {

    private float hitpoint = 150;
    private float maxHitpoint = 150;
	//edit guille
	[Header("REFERENCIAS")]
	public Image healthBar;
	public Text ratioText;

	// Use this for initialization
	void Start () {

        UpdateHealthbar();

    }


    private void UpdateHealthbar()
    {
		healthBar.fillAmount = hitpoint / maxHitpoint;
        float ratio = hitpoint / maxHitpoint;
        ratioText.text = (ratio * 100).ToString("0") + '%';
    }

	public void TakeDamage (float damage)
    {
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
