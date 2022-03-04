using UnityEngine;
namespace WindRose.PlayerContent
{
    public sealed class GroundCheck : MonoBehaviour
    {
        [SerializeReference] private bool OnGrouded;
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Ground"))
            {
                PlayerContent.Player.OnGrounded = true;
                OnGrouded = PlayerContent.Player.OnGrounded;
            }
        }
        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Ground"))
            {
                PlayerContent.Player.OnGrounded = false;
                OnGrouded = PlayerContent.Player.OnGrounded;
            }
        }
    }
}
