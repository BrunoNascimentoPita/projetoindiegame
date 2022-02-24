using UnityEngine;
public sealed class LBandit : Enemy
{
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private float _attackTime;

    private void Start() 
    {
        InitComponentsAndVariables(3, 2, 5F, 2, 2); 
        PlayerAttackArea.GiveDamage += VerificationDamage; 
    }

    private void Update()
    {
        if (DistanceToTarget < 2F && _attackSpeed < _attackTime)
        {
            Attack();
            _attackTime = 0; 
        }
        if (OnVision && DistanceToTarget > 2) 
        {
            Move(); 
        }
        if (_life <= 0)
        {
            Die();
        } 
        if (transform.position.x < PlayerPosition.x) //Gira conforme a posição do jogador
        {
            Flip(-1); 
        } else {
            Flip(1); 
        }
        _attackTime += Time.deltaTime;
    }


    private void LateUpdate()
    {
        SearchPlayer();
    }


    private void OnDestroy() //Limpa o evento
    {
        PlayerAttackArea.GiveDamage -= VerificationDamage;
    }


    private void VerificationDamage(int id, int damageValue){ //Verifica se o esse objeto foi acertado
        if (id == gameObject.GetInstanceID()) {
            TakeDamage(damageValue); 
        }
    }


}
