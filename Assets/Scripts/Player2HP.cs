using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2HP : MonoBehaviour
{
    [SerializeField] public int HP2=1;


    void Update()
    {
        if (HP2 <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponentInChildren<Damager>();
        PlayerHP Phealth = other.GetComponentInChildren<PlayerHP>();
        
        if (damager != null && Phealth.HP > 0)
        {
            Phealth.HP -= damager.damage;


        }
    }
}
