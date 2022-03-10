using UnityEngine;
using System.Collections;

namespace WindRose.CoreCombat.EnemyBase.Goblin
{
    public class Goblin : EnemyBase
    {
        [Header("Atributos Únicos")]
        [SerializeField] float StaggTime;


        [Header("Componentes")]
        [SerializeField] SpriteRenderer _sprite;


        [SerializeField] GoblinValues Data;

        void Start()
        {
            GetComponents();
        }

        protected override void TakeDamage(int Damage)
        {
            Life -= Damage;
            if (Life <= 0)
            {
                PlayerContent.Player._xp += 1;
                Die();
            }
            print("Fui Acertado");
        }
        protected override void GetComponents()
        {
            Life = Data.Vida;
            _sprite = GetComponent<SpriteRenderer>();
        }
        protected override void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("DamageArea"))
            {
                TakeDamage(col.gameObject.GetComponent<PlayerContent.Power.SupernovaEffect>().Damage);
            }
        }
    }
}
