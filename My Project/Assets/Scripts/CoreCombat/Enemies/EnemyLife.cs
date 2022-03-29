using UnityEngine;

namespace WindRose.CoreCombat.EnemyBase
{
    public class EnemyLife : MonoBehaviour
    {
        internal int _life;

        public void TakeDamage(int DamageValue)
        {
            _life -= DamageValue;
        }
    }
}