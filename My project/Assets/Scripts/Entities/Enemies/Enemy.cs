using UnityEngine;
public class Enemy : CombatEntities
{
    private protected int XpValue = 1; 
    private protected float RangeAttack;
    private protected float DistanceToTarget;
    private protected bool OnVision;
    protected Vector2 PlayerPosition;

    private protected void SearchPlayer() {
        try{
            PlayerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        } 
        catch {
            print("The Player isn't active in Scene");
        }

        DistanceToTarget = Vector2.Distance(T.localPosition, PlayerPosition);
        if (DistanceToTarget < RangeAttack) OnVision = true;
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
}
