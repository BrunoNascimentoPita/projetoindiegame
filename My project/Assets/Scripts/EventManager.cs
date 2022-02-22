using UnityEngine;

public sealed class EventManager : MonoBehaviour
{
    PlayerAttackArea _playerAttackArea;


    [SerializeField] private GameObject _enemy; 

    private void Start()
    {
        _enemy = Resources.Load<GameObject>("Prefabs/Enemies/Bandido Leve/Bandido Leve"); 
    }
    private void RespawnEnemy()
    {
        Instantiate(_enemy, transform.position, Quaternion.identity); 
    }
}
