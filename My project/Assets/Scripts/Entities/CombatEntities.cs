using UnityEngine;
public class CombatEntities : MonoBehaviour
{
    [SerializeField] private  protected bool BoxState; 
    [SerializeField] private  protected float Speed;
    [SerializeField] internal int Life;
    [SerializeField] private  protected Transform T; 
    [SerializeField] private  protected Rigidbody2D Rb;
    [SerializeField] private  protected Animator Ani;
    [SerializeField] private  protected BoxCollider2D AttackBox; 
}
public abstract class CombatFunctions : CombatEntities  
{
    private static readonly int IsHurt = Animator.StringToHash("IsHurt");
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

    public delegate void OnEntitieDead();
    public static event OnEntitieDead OnPlayerDead; 
    
    private protected virtual void InitComponentsAndVariables() 
    {
        Rb = GetComponent<Rigidbody2D>();
        T = GetComponent<Transform>();
        Ani = GetComponent<Animator>();
    }
    private protected virtual void InitComponentsAndVariables(float rangeAttack) 
    {
        Rb = GetComponent<Rigidbody2D>();
        T = GetComponent<Transform>();
        Ani = GetComponent<Animator>(); 
    }

    private protected void TakeDamage()
    {
        if (Ani != null) Ani.SetTrigger(IsHurt);
        Life -= 1; 
    }

    private protected void Attack()
    {
        Ani.SetTrigger(IsAttacking);
    }

    private protected virtual void Die()
    {
        if (CompareTag("Player"))
        {
            if (OnPlayerDead != null) OnPlayerDead();
        } 
        Destroy(gameObject);
    }
} 