using UnityEngine;

public class CombatEntities : MonoBehaviour
{
    private  protected bool BoxState; 
    private  protected float Speed;
    [SerializeField]
    private  protected int Life;
    private  protected Transform T; 
    private  protected Rigidbody2D Rb;
    private  protected Animator Ani;
    [SerializeField] private  protected BoxCollider2D AttackBox; 
}
public abstract class CombatFunctions : CombatEntities  
{
    private protected virtual void InitComponentsAndVariables() {
        Rb = GetComponent<Rigidbody2D>();
        T = GetComponent<Transform>();
        Ani = GetComponent<Animator>();
    }
    private protected virtual void InitComponentsAndVariables(float rangeAttack) {
        Rb = GetComponent<Rigidbody2D>();
        T = GetComponent<Transform>();
        Ani = GetComponent<Animator>(); 
    }

    private protected void TakeDamage()
    {
        Ani.SetTrigger("IsHurt");
        print("O "+gameObject.name+ " levou 1 de dano");
        Life -= 1;
    }

    private protected void Attack()
    {
        Ani.SetTrigger("IsAttacking");
    }

    private void AttackBoxToggle()
    {
        BoxState = !BoxState; 
        AttackBox.enabled = BoxState;
    }

    private protected virtual void Die()
    {
        Ani.speed = 0;
        if (GetComponent<Player>() == null)
        {
            GetComponent<LBandit>().enabled = false;
            Rb.simulated = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
} 