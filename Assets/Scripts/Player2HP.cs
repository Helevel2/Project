using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2HP : MonoBehaviour
{
    [SerializeField] public int HP2=1;
    [SerializeField] GameObject objEnable;
    [SerializeField] TMP_Text uitext;



    void Update()
    {
        if (HP2 <= 0)
        {
            if (objEnable != null)
            {
                objEnable.SetActive(true);
                uitext.text = "Player 1 Won";
            }

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
