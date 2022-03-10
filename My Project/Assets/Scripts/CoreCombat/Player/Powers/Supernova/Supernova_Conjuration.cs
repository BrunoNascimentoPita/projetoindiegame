using UnityEngine;

namespace WindRose.CoreCombat.PlayerContent.Power
{
    public class Supernova_Conjuration : PowersBase
    {
        [SerializeField] Transform _powerLocal;
        [SerializeField] GameObject Power;
        private void Start()
        {
            Power = Resources.Load<GameObject>("Sprites/Powers/Supernova/Supernova");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                UsePower();
        }
        protected override void UsePower()
        {
            _powerLocal = GameObject.Find("Jogador").GetComponent<Transform>();
            Vector3 _powerPoint = new Vector3(_powerLocal.position.x,
                                                _powerLocal.position.y,
                                                    _powerLocal.position.z);

            Instantiate(Power, _powerPoint, Quaternion.identity);
            Destroy(this);
        }
    }
}
