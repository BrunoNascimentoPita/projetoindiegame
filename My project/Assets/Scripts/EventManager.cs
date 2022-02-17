using UnityEngine;

public sealed class EventManager : MonoBehaviour
{
    internal delegate void DealDamage();
    internal static event DealDamage DamagePlayer;
    internal static event DealDamage DamageEnemy;
    
    private float _playerImunity;
    private float _enemyImunity;
    private float _timeImunity;

    [SerializeField] private GameObject _enemy; 
    private void Start()
    {
        Enemy.RequestSpawn += RespawnEnemy; 
        AttackArea.OnDealDamage += DamageRedirect;
        _enemy = Resources.Load<GameObject>("Prefabs/Bandido Leve"); 
    }
    private void Update()
    {
        _playerImunity += Time.deltaTime;
        _enemyImunity += Time.deltaTime;
    }
    private void DamageRedirect(string tagObj) 
    {
        if (tagObj == "Player" && _playerImunity > _timeImunity)
        {
            if (DamagePlayer != null) DamagePlayer();
            _playerImunity = 0; 
        }
        if (tagObj == "Enemy" && _enemyImunity > _timeImunity)
        {
            if (DamageEnemy != null) DamageEnemy();
            _enemyImunity = 0; 
        } 
    }

    private void RespawnEnemy()
    {
       
        Instantiate(_enemy, transform.position, Quaternion.identity); 
    }


}
