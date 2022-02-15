using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public delegate void grounded(bool isTrue); 
    public event grounded OnGrounded;

    private void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.CompareTag("Ground"))
        {
            OnGrounded(true);
        }
        else {
            OnGrounded(false);
        } 
    }
    private void OnTriggerExit2D(Collider2D collision){
        OnGrounded(false);
    }
}
