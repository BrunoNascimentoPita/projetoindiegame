using UnityEngine;
namespace WindRose.CoreCombat.PlayerContent.Power
{
    public class SupernovaEffect : MonoBehaviour
    {
        public int Dano;
        public int Damage
        {
            get => Dano;
        }
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {

            }
        }
    }
}
