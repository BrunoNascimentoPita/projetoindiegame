using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WindRose.UI
{
    public class UI_Controller : MonoBehaviour
    {
        [SerializeField] Slider lifeSlider;

        void Start()
        {
            lifeSlider.maxValue = 5;
        }
        void LateUpdate()
        {
            lifeSlider.value = WindRose.PlayerContent.Player.Life;
        }
    }
}
