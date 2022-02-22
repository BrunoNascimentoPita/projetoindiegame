using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint; 
    [SerializeField] private GameObject _lightEnemy;
    void Start()
    {
        Instantiate(_lightEnemy, _spawnPoint.position, Quaternion.identity); 
        Application.targetFrameRate = 60; // Limita o FPS a 60 quadros por segundo 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(_lightEnemy, _spawnPoint.position, Quaternion.identity); 
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("TAttack");
    } 
}
