using UnityEngine;
using System.IO;

namespace WindRose.PlayerContent
{
    public class SaveController : MonoBehaviour
    {
        public static PlayerData _playerData = new();
        readonly string pathPlayerData = "C:/Unity/projetoindiegame/projetoindiegame/My Project/Assets/SaveFiles/saveFile.json";

        public static int TESTE;

        void Awake()
        {
            string json = File.ReadAllText("C:/Unity/projetoindiegame/projetoindiegame/My Project/Assets/SaveFiles/saveFile.json");
            _playerData = JsonUtility.FromJson<PlayerData>(json);
        }


        void Start()
        {
            TESTE = 2;
        }


        public void UpdateChanges()
        {
            string saveData = JsonUtility.ToJson(_playerData, true); // Escreve as mudan�as com os dados da instancia _playerData
            File.WriteAllText(pathPlayerData, saveData);
        }

    }

    [System.Serializable]
    public class PlayerData // Tipos de base para os atributos do jogador 
    {
        public int LifeMax;
        public int Speed;
        public int JumpForce;
        public int DamageValue;
        public int Level;
    }
}


