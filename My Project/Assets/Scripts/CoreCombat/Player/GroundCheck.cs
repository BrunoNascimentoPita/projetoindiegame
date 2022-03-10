using UnityEngine;
namespace WindRose.CoreCombat.PlayerContent.GroundCheck
{
    public sealed class GroundCheck : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Ground"))
            {
                Player.OnGrounded = true;
            }
        }
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Ground"))
            {
                Player.OnGrounded = false;
            }
        }
    }
}
