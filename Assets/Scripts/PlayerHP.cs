using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] public int HP=1;


    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponentInChildren<Damager>();
        Player2HP Phealth2 = other.GetComponentInChildren<Player2HP>();
        if (damager != null && Phealth2.HP2 > 0)
        {
            Phealth2.HP2 -= damager.damage;

            
        }
    }
}
