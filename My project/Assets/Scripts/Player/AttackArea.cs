using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField]
    private GameObject Obj; 
    private IEnumerator DestroyEnemy;

    public delegate void Attack();
    public static event Attack DealDamage; 

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Obj = other.gameObject;
        if (other.gameObject.CompareTag("Enemy")) {
            DealDamage();
            print("Inimigo Acertado");
        }
    }
}
