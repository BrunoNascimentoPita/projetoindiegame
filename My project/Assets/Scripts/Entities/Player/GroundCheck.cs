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

    private void Update()
    {
        _player.OnGrounded = _onGround; 
    }

    private void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.CompareTag("Ground"))
        {
            _onGround = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _onGround = false; 
        }
    }
}
