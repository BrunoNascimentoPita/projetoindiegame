using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    void Start()
    {
        
        Application.targetFrameRate = 60; // Limita o FPS a 60 quadros por segundo 
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("TAttack"); 
    } 
}
