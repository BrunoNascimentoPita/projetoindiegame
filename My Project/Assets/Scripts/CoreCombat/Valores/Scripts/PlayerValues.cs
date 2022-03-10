using UnityEngine;

namespace WindRose.CoreCombat.PlayerContent
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObject/Jogador", order = 1)]
    public class PlayerValues : ScriptableObject
    {
        public float Velocidade;
        public float AtaqueVelocidade;
        public int ForcaPulo;
        public int VidaMaxima;
    }
}
