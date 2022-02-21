using UnityEngine;
public class Enemy : CombatFunctions
{
    private protected int XpValue = 1; 
    private protected float RangeAttack;
    private protected float DistanceToTarget;
    private protected bool OnRange;
    protected Vector2 PlayerPosition;

    public delegate void OnDead(int value);  
    public static event OnDead OnEnemyDied; 
    private protected void SearchPlayer() {
        try{
            PlayerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        } catch {
            print("O jogador provavelmente morreu");
        }
        DistanceToTarget = Vector2.Distance(T.localPosition, PlayerPosition);
        if (DistanceToTarget < RangeAttack) OnRange = true;
    }
    private protected void Move()
    {
        T.position = Vector2.MoveTowards(T.localPosition, PlayerPosition, Speed * Time.deltaTime);
    }
    private protected override void InitComponentsAndVariables(float rangeAttack)
    {
        base.InitComponentsAndVariables();
        RangeAttack = rangeAttack;
        Life = 3;
        Speed = 2; 
    }
    private protected void Flip(int x)
    {
        T.localScale = new Vector2(x, 1); 
    }
    private protected override void Die()
    {
        base.Die();
        if (OnEnemyDied != null) OnEnemyDied(XpValue);
    }
}
