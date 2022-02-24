using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI; 

public class PlayerPrefsController : MonoBehaviour
{
    public TMPro.TMP_InputField _nameField;

    public void SaveName() 
    {
        PlayerPrefs.SetString("NomeJogador", _nameField.text);
        PlayerPrefs.Save(); 
    }

    public void LoadName() 
    {
        print(PlayerPrefs.GetString("NomeJogador"));
        _nameField.text = PlayerPrefs.GetString("NomeJogador");
    }

    public void SetName() 
    {
        PlayerPrefs.SetString("NomeJogador", _nameField.text); 
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            PlayerPrefs.DeleteAll(); 
         }
    }
}
