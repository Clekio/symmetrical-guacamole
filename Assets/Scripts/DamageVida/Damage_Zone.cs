using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Zone : MonoBehaviour
{

    public bool damaging;
    public float damage;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage((damaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
            
        }

    }
}
