using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyDetector : MonoBehaviour
{
    private bool ReadyToAttack;
    [SerializeField]
    private LBandit BanditScript; 
    private void Start() {
        BanditScript = GetComponentInParent<LBandit>(); 
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")){
            ReadyToAttack = true; 
            BanditScript.ReadyToAttack = this.ReadyToAttack; 
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            ReadyToAttack = false;  
        }
    }
}
