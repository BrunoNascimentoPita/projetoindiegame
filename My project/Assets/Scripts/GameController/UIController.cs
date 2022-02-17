using System;
using UnityEngine;
using UnityEngine.UI; 
public sealed  class UIController : MonoBehaviour
{
    public CombatEntities combat;
    [SerializeField]
    private Slider _sliderXP;
    [SerializeField]
    private SpriteRenderer Weapon1;
    [SerializeField]
    private SpriteRenderer Weapon2; 
    private Sprite SwordSprite;
    private Sprite StaffSprite;
    [SerializeField]
    private bool UsingSecondaryWeapon;

    void Start()
    {
        Enemy.GiveXP += AddXP; 
        _sliderXP = GameObject.Find("Bar_XP_Controller").GetComponent<Slider>(); 
        Player.OnWeaponChanged += ChangeWeaponImage; 
    }
    private  void ChangeWeaponImage() {
        print("Arma Trocada");
        UsingSecondaryWeapon = !UsingSecondaryWeapon;
        if (UsingSecondaryWeapon) 
        {
            Weapon1.color = new Color(255, 255, 255, 100);
            Weapon2.color = new Color32(255, 255, 255, 255);  
        } else if (!UsingSecondaryWeapon)
        {
            Weapon2.color = new Color32(255, 255, 255, 100);
            Weapon1.color = new Color32(255, 255, 255, 255);   
        } 
    }

    private void AddXP()
    {
        print("XP Adicionado");
        _sliderXP.value += 1; 
    }
}
