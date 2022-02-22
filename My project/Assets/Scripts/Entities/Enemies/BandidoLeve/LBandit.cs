using System;
using UnityEngine;
[System.Serializable]
public sealed class LBandit : Enemy
{
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    
    [SerializeField] private float _attackSpeed = 2;
    private float _attackTime;

    private void Awake() 
    {
        InitComponentsAndVariables(5); 
        PlayerAttackArea.GiveDamage += VerificationDamage; 
    }
    private void OnDestroy() 
    {
        PlayerAttackArea.GiveDamage -= VerificationDamage;
    }

    private void Update()
    {
        if (DistanceToTarget < 1.3F && _attackSpeed > _attackTime)
        {
            Attack();
            _attackTime = 0; 
        }
        if (OnVision && DistanceToTarget > 2) 
        {
            Move(); 
        }
        if (transform.position.x < PlayerPosition.x) 
        {
            Flip(-1); 
        } else {
            Flip(1); 
        }
        if (Life <= 0)
        {
            Die();
        } 
        _attackTime += Time.deltaTime;
    }
    private void LateUpdate()
    {
        SearchPlayer();
    }
    private void VerificationDamage(int id){
        if (id == gameObject.GetInstanceID()) {
            print("Eu fui acertado");
            TakeDamage(); 
        }
    }
}
