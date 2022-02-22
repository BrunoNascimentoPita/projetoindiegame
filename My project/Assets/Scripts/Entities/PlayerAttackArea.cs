using UnityEngine;
using UnityEngine.Events; 

public sealed class PlayerAttackArea : MonoBehaviour
{
    private GameObject objHit;

    public delegate void _GiveDamage(int id);
    public UnityEvent entro; 
    public static event _GiveDamage GiveDamage;  

    private void OnTriggerEnter2D(Collider2D other)
    {
        objHit = other.gameObject;
        if (objHit.CompareTag("Enemy")) {
            if (GiveDamage!=null)
            {
                GiveDamage(objHit.GetInstanceID());
            } else {
                print("Evento não encontrado"); 
            } 
        }
        objHit = null; 
    } 
}
