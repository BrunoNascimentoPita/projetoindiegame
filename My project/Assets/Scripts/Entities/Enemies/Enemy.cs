using UnityEngine;
public class Enemy : CombatEntities
{
    private protected int XpValue = 1; 
    [SerializeField]private protected float DistanceToTarget;
    private protected bool OnVision;
    protected Vector2 PlayerPosition;

    private protected void SearchPlayer() {
        try {
            PlayerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        } 
        catch {
            print("O Jogador não se encontra na cena");
        }
        DistanceToTarget = Vector2.Distance(T.localPosition, PlayerPosition);
        if (DistanceToTarget < _rangeAttack) OnVision = true;
    }
    private protected void Move()
    {
        T.position = Vector2.MoveTowards(T.localPosition, PlayerPosition, _speed * Time.deltaTime);
    }
    private protected void Flip(int x)
    {
        T.localScale = new Vector2(x, 1); 
    }
}
