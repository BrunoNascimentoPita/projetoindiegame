using UnityEngine;
using UnityEngine.UI; 
public sealed class UIController : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider; 
    private int _playerLife; 
    
    private void Awake()
    {
        Invoke("ShowBar",3F); 
    }

    private void ShowBar() 
    {       
        _playerLife = Player._Life;
        _healthSlider.maxValue = _playerLife;
        _healthSlider.enabled = true; 
    }
    private void Update()
    {
        _playerLife = Player._Life; 
    }
    private void LateUpdate() 
    {
        _healthSlider.value = _playerLife;
    } 
}
