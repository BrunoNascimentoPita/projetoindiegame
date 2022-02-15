using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LBandit : Enemy
{
    private bool ReadyToSearch = true;
    private float findCount;
    [SerializeField]
    private float findTime;

    private void Start()
    {
        InitComponents();
        Life = 3;
        Speed = 5;
        AttackArea.DealDamage += TakeDamage;
    }
    private void Update()
    {
        if (OnRange && DistanceToTarget > 1.5)
        {
            Move();
        }
        if (DistanceToTarget < 1 && AttackCooldown > 2)
        {
            Attack();
            AttackCooldown = 0;
        }
        findCount += Time.deltaTime;
        AttackCooldown += Time.deltaTime; 
    }
    private void LateUpdate()
    {
        OnRange = (DistanceToTarget < RangeAttack ? true : false);
        if (ReadyToSearch)
        {
            SearchPlayer();
        }
    }
    private void TakeDamage() {
        Life -= 1;
        if(Life>0){
            print("O Bandido está com " + Life + " pontos de vida");
        } else {
            print("O Bandido morreu");
            Destroy(this.gameObject);
        }
    }
}
