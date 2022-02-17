using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements; 

public class GameManager : MonoBehaviour
{
    [SerializeField]private Slider Slider; 
    void Start()
    { 
        Application.targetFrameRate = 60; // Limita o FPS a 60 quadros por segundo 
    }
}
