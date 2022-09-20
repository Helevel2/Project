using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] public int HP;


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

        if (damager!=null && HP>0)
        {
            HP -= damager.damage;

            
        }
    }
}
