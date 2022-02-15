using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Enemy : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField]
    protected int Life;
    [SerializeField]
    protected float Speed;
    [SerializeField]
    protected float RangeAttack;
    [SerializeField]
    protected float AttackCooldown;
    [SerializeField]
    protected bool ReadyToSearch = true;
    [SerializeField]
    protected int   DamageValue;
    [Header("Estados")]
    [SerializeField]
    protected bool OnRange;
    [SerializeField]
    protected float DistanceToTarget;
    [Header("Componentes")]
    [SerializeField]
    protected Animator ani;
    [SerializeField]
    protected Vector2 playerPosition;
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected Transform t;

    public delegate void GivenDamage(int DamageValue);
    public static event GivenDamage GiveDamage; 

    protected void InitComponents() {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>(); 
    }
    protected void SearchPlayer() {
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        DistanceToTarget = Vector2.Distance(t.localPosition, playerPosition);
    }
    protected void Move() {
        t.position = Vector2.MoveTowards(t.localPosition, playerPosition, this.Speed * Time.deltaTime);
    }
    protected void Attack() {
        ani.SetTrigger("IsAttacking");
        AttackCooldown = 0;
    }
    protected void DealDamage() {
        print("O " + gameObject.name + "causou " + DamageValue + " de dano");
        GiveDamage(DamageValue); 
    }
}
