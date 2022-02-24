using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBanditAttackArea : MonoBehaviour
{
    [SerializeField] private int damageValue; 
    private GameObject objHit;

    public delegate void _DealDamage(int damageValue);
    public static event _DealDamage DealDamagePlayer;  
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        objHit = other.gameObject;
        if (objHit.CompareTag("Player")) {
            if (DealDamagePlayer != null)
            {
                DealDamagePlayer(damageValue);
                print("O Jogador foi atingido"); 
            }  
        }
        objHit = null; 
    }

    private void LateUpdate() {
        damageValue = GetComponentInParent<LBandit>()._damageValue; 
    }
}
