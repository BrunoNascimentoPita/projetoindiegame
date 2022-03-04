using UnityEngine;
using System.IO;
[System.Serializable]
public class SaveController : MonoBehaviour
{
    public static PlayerData _playerData = new();
    readonly string pathPlayerData = "C:/Unity/projetoindiegame/projetoindiegame/My Project/Assets/SaveFiles/saveFile.json"; 

    void Awake()
    {  
        string json = File.ReadAllText("C:/Unity/projetoindiegame/projetoindiegame/My Project/Assets/SaveFiles/saveFile.json");
        _playerData = JsonUtility.FromJson<PlayerData>(json); 
    }


    public void UpdateChanges() 
    {
        string saveData = JsonUtility.ToJson(_playerData, true); // Escreve as mudanças com os dados da instancia _playerData
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



