using UnityEngine;

namespace WindRose.CoreCombat.EnemyBase
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [Header("Atributos Base")]
        [SerializeField] protected int Life;

        protected abstract void TakeDamage(int Damage);
        protected abstract void GetComponents();
        protected abstract void Die();
    }
}