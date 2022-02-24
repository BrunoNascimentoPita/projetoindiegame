using System;
using UnityEngine;

public sealed class GroundCheck : MonoBehaviour
{
    private Player _player;
    private bool _onGround;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>(); 
    }

    private void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.CompareTag("Ground"))
        {
            print("O Jogador está no chao"); 
            _player.OnGrounded = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _player.OnGrounded = false; 
        }
    }
}
