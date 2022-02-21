using UnityEngine;

public sealed class AttackArea : MonoBehaviour
{
    [SerializeField] private GameObject Obj; 

    public delegate void Damage(GameObject obj); 
    public static event Damage OnDealDamage;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Obj = other.gameObject;
        if (OnDealDamage != null) 
        {
            OnDealDamage(Obj);
            print("Algo Atingido");
        } else if (OnDealDamage == null){
            print("Evento não encontrado");
        }
        Obj = null; 
    }
}
