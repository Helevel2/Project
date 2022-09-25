using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerHP : MonoBehaviour
{
    [SerializeField] public int HP=1;
    [SerializeField] GameObject objEnable;
    [SerializeField] TMP_Text uitext;


    void Update()
    {
        if (HP <= 0)
        {
            if (objEnable != null)
            {
                objEnable.SetActive(true);
                uitext.text = "Player 2 Won";
            }
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
