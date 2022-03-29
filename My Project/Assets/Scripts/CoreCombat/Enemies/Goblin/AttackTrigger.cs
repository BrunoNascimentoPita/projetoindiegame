namespace WindRose.CoreCombat.EnemyBase.Goblin
{
    public class AttackTrigger : UnityEngine.MonoBehaviour
    {
        Goblin_IA ScriptIA;
        private void Awake()
        {
            ScriptIA = GetComponentInParent<Goblin_IA>();
        }

        private void OnTriggerEnter2D(UnityEngine.Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                ScriptIA.OnTarget = true;
            }
        }
        private void OnTriggerExit2D(UnityEngine.Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                ScriptIA.OnTarget = false;
            }
        }
    }
}
