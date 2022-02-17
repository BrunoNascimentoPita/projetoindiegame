using System;
using UnityEngine;
public class Enemy : CombatFunctions
{
    
    private protected float RangeAttack;
    private protected float DistanceToTarget;
    private protected bool OnRange;
    protected Vector2 PlayerPosition;

    public static event Action GiveXP;
    public static event Action RequestSpawn; 

    private protected void SearchPlayer() {
        PlayerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        DistanceToTarget = Vector2.Distance(T.localPosition, PlayerPosition);
        if(DistanceToTarget < RangeAttack) OnRange = true;
    }
    private protected void Move()
    {
        T.position = Vector2.MoveTowards(T.localPosition, PlayerPosition, Speed * Time.deltaTime);
        print("O inimigo está se movendo");
    }
    private protected override void InitComponentsAndVariables(float rangeAttack)
    {
        base.InitComponentsAndVariables();
        RangeAttack = rangeAttack;
        Life = 3;
        Speed = 2;
        EventManager.DamageEnemy += TakeDamage; 
    }
    private protected void Flip(int x)
    {
        T.localScale = new Vector2(x, 1); 
    }
    private protected override void Die()
    {
        base.Die();
        if (GiveXP != null) GiveXP();
        RequestSpawn(); 
    }
}
