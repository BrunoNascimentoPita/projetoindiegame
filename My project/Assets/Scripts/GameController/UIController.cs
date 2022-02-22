using UnityEngine;
using UnityEngine.UI; 
public sealed  class UIController : MonoBehaviour
{
    [SerializeField] private Slider _sliderXP;
    [SerializeField] private GameObject _gameOverMessage,_canvas; 
    [SerializeField] private SpriteRenderer[] _hearts; 
    [SerializeField] private int _playerHearts = 3;

    [SerializeField] private bool _ReadyToGameOver = true; 
    
    private bool UsingSecondaryWeapon;

    void Start()    
    {   
        InitComponents();
    }

    private void LateUpdate()
    {
        if ((int)_sliderXP.value == (int)_sliderXP.maxValue)
        {
            print("Você upou de nível");
            _sliderXP.value = 0; 
        }
    }

    private void GiveXp(int xpValue)
    {
        _sliderXP.value += xpValue;
    }

    // private void RemoveHeart()
    // {
    //     _playerHearts -= 1; 
    //     Destroy(_hearts[_playerHearts]);
    // }

    private void ShowGameOver()
    {
        if (_ReadyToGameOver)
        {
            _gameOverMessage.SetActive(true);
            print("O Jogador morreu");
            _ReadyToGameOver = false; 
        }
    }

    private void InitComponents()
    {
        _canvas = GameObject.Find("Canvas");
    }
}
