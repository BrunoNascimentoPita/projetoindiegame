using UnityEngine;

public sealed class EventManager : MonoBehaviour
{
    internal delegate void DealDamage();
    internal static event DealDamage DamagePlayer;
    internal static event DealDamage DamageEnemy;

    [SerializeField] private GameObject _enemy; 

    private void Start()
    {
        InitEvents();
        _enemy = Resources.Load<GameObject>("Prefabs/Enemies/Bandido Leve/Bandido Leve"); 
    }   
    private void DamageRedirect(GameObject obj) 
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            if (DamagePlayer != null) DamagePlayer();
        }
        if (obj.gameObject.CompareTag("Enemy"))
        {
            if (DamageEnemy != null) DamageEnemy();
        } 
    }
    private void RespawnEnemy()
    {
        Instantiate(_enemy, transform.position, Quaternion.identity); 
    }
    private void OnEnemyDied(int value)
    {
        RespawnEnemy();
    } 
    private void InitEvents()                       
    {
        Enemy.OnEnemyDied += OnEnemyDied;
        AttackArea.OnDealDamage += DamageRedirect; 
    }
}
