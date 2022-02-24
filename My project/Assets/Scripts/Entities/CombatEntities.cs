using System.Security.Cryptography;
using UnityEngine;
public abstract class CombatEntities : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField] private  protected int _jumpForce, _life;
    [SerializeField]          internal  int _damageValue;  
    [SerializeField] private  protected float _speed, _rangeAttack, _attackSpeed;
    [Header("Componentes")]
    [SerializeField] private  protected Transform T; 
    [SerializeField] private  protected Rigidbody2D Rb;
    [SerializeField] private  protected Animator Ani;
    [SerializeField] private  protected BoxCollider2D AttackBox; 
    
    private static readonly int IsHurt = Animator.StringToHash("IsHurt");
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    private static readonly int IsDead = Animator.StringToHash("IsDead");


    private protected void InitComponentsAndVariables(int life, int speed, float rangeAttack, float attackSpeed, int damageValue) //Usada para inimigos
    { 
        Rb = GetComponent<Rigidbody2D>();
        T = GetComponent<Transform>();
        Ani = GetComponent<Animator>();
        _life = life;   
        _speed = speed;
        _rangeAttack = rangeAttack;
        _damageValue = damageValue;  
        _attackSpeed = attackSpeed; 
    }
    private protected void InitComponentsAndVariables(int life, int jumpForce, int speed, int damageValue) //Usada para o jogador
    { 
        Rb = GetComponent<Rigidbody2D>();
        T = GetComponent<Transform>();
        Ani = GetComponent<Animator>();
        _life = life;   
        _speed = speed;
        _jumpForce = jumpForce;
        _damageValue = damageValue; 
    }   
    public virtual void TakeDamage(int value)
    {
        if (Ani != null)
        {
            Ani.SetTrigger(IsHurt);
            _life -= value;   
        }
    }

    private protected void Attack()
    {
        Ani.SetTrigger(IsAttacking);
    }

    private protected virtual void Die()
    {
        Ani.SetBool(IsDead, true);
    }
    private protected void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
