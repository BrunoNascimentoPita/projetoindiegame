using UnityEngine;
namespace WindRose.CoreCombat.PlayerContent
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] protected int _damage;
        [SerializeField] WeaponValues weaponData;
        private void Start()
        {
            _damage = weaponData.Dano;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            GameObject target = col.gameObject;
            if (target.CompareTag("Enemy"))
            {
                target.GetComponent<EnemyBase.EnemyLife>().TakeDamage(_damage);
            }
        }

    }
}
