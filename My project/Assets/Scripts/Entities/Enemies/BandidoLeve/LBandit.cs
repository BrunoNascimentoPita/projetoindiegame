using UnityEngine;

public sealed class LBandit : Enemy
{
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    [SerializeField]
    private float _attackSpeed = 2;
    private float _attackTime; 
    private void Start()
    {
        InitComponentsAndVariables(5);
        EventManager.DamageEnemy += TakeDamage; 
    }
    private void Update()
    {
        if(DistanceToTarget < 1.3F && _attackSpeed > _attackTime) Attack(); _attackTime = 0;
        if (OnRange && DistanceToTarget > 2) {
            Move(); 
        }
        if (transform.position.x < PlayerPosition.x) {
            Flip(-1); 
        } else {
            Flip(1); 
        }
        if (Life <= 0)
        {
            Ani.SetBool(IsDead, true);
        } 
        _attackTime += Time.deltaTime;
    }
    private void LateUpdate()
    {
        SearchPlayer();
    }
}
