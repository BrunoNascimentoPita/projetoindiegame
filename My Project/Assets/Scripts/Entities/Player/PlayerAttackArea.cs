using UnityEngine;
using UnityEngine.Events; 

public sealed class PlayerAttackArea : MonoBehaviour
{
    [SerializeField] private int damageValue; 
    private GameObject objHit;

    public delegate void _GiveDamage(int id, int damageValue);
    public static event _GiveDamage GiveDamage;  
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        objHit = other.gameObject;
        if (objHit.CompareTag("Enemy")) {
            if (GiveDamage != null)
            {
                GiveDamage(objHit.GetInstanceID(), damageValue);
                print("Inimigo atingido"); 
            }  
        }
        objHit = null; 
    }

    private void LateUpdate() {
        damageValue = GetComponentInParent<Player>()._damageValue; 
    }
}
