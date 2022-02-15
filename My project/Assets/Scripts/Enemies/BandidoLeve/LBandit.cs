using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBandit : Enemy
{
    [Header("Variaveis Internas")]
    [SerializeField]
    private float findTime;
    [SerializeField]
    public bool ReadyToAttack;

    private void Start()
    {
        InitComponents();
        Life = 3;
        Speed = 5;
        AttackArea.DealDamage += TakeDamage;
    }
    private void Update()
    {
        if (OnRange && DistanceToTarget > 1.5){
            Move();
        }
        if (ReadyToAttack && AttackCooldown > 2){
            Attack();
        }
        AttackCooldown += Time.deltaTime;
        
        if (transform.position.x < playerPosition.x) {
            Flip(-1); 
        } else {
            Flip(1); 
        }
    }
    private void LateUpdate()
    {
        OnRange = (DistanceToTarget < RangeAttack ? true : false);
        SearchPlayer();
    }
    private void TakeDamage() {
        Life -= 1;
        if(Life>0){
            print("O Bandido esta com " + Life + " pontos de vida");
        } else {
            print("O Bandido morreu");
            Destroy(this.gameObject);
        }
    }
    private void Flip(int x){
        transform.localScale = new Vector2(x, transform.localScale.y); 
    } 
}
