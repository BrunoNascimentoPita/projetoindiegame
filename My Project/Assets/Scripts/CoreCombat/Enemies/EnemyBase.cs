namespace WindRose.CoreCombat.EnemyBase
{
    public abstract class EnemyBase : UnityEngine.MonoBehaviour
    {
        [UnityEngine.Header("Atributos Base")]
        [UnityEngine.SerializeField] protected int _speed;
        [UnityEngine.SerializeField] protected int _rangeAttack;
        [UnityEngine.SerializeField] protected int _life;
        [UnityEngine.Header("Objetos")]
        [UnityEngine.SerializeField] protected UnityEngine.GameObject Player;
        [UnityEngine.SerializeField] protected UnityEngine.Vector2 PlayerPos;
        [UnityEngine.SerializeField] protected EnemyLife LifeScript;
        [UnityEngine.Header("Componentes")]
        [UnityEngine.SerializeField] protected UnityEngine.Rigidbody2D _rb;
        [UnityEngine.SerializeField] protected UnityEngine.Transform _t;
        [UnityEngine.SerializeField] protected UnityEngine.Animator _ani;

        protected void LoadComponentsAndObjects()
        {
            _t = GetComponent<UnityEngine.Transform>();
            _rb = GetComponent<UnityEngine.Rigidbody2D>();
            LifeScript = GetComponent<EnemyLife>();
            _ani = GetComponent<UnityEngine.Animator>();
        }
        protected void LocalizePlayer()
        {
            if (!Player)
            {
                Player = UnityEngine.GameObject.FindGameObjectWithTag("Player");
            }
            PlayerPos = Player.GetComponent<UnityEngine.Transform>().position;
        }
        protected abstract void LoadVariables();
        protected abstract void Move();
        protected abstract void Die();
    }
}
