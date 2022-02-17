using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AttackArea : MonoBehaviour
{
    [SerializeField]
    private GameObject Obj; 

    public delegate void Damage(string tagOBJ); 
    public static event Damage OnDealDamage;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Obj = other.gameObject;
        print("Alguem foi acertado");
        if (OnDealDamage != null) OnDealDamage(Obj.tag);
    }
}
