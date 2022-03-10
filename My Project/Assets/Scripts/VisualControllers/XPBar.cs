using UnityEngine;
using UnityEngine.UI;

namespace WindRose.UI
{
    public class XPBar : MonoBehaviour
    {
        [SerializeField] Slider _xpSlider;

        void Start()
        {
            _xpSlider.value = 0;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            _xpSlider.value = CoreCombat.PlayerContent.Player._xp;
        }

    }
}