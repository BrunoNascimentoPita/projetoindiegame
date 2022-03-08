using UnityEngine;

namespace WindRose.PlayerContent
{
    [CreateAssetMenu(fileName = "ScriptableObject", menuName = "Jogador", order = 1)]
    public class PlayerValues : ScriptableObject
    {
        public float Velocidade;
        public float AtaqueVelocidade;
        public int ForcaPulo;
        public int VidaMaxima;
    }
}
