using UnityEngine;
namespace WindRose.CoreCombat.PlayerContent
{
    public sealed class Player : MonoBehaviour
    {
        [Header("Atributos Base")]
        [SerializeField] int _jumpForce;
        [SerializeField] int _lifeActual, _lifeMax;
        [SerializeField] int _damageValue;
        [SerializeField] float _speed, _attackSpeed;
        [Header("Valores Globais")]
        public static int _xp;
        [Header("Componentes")]
        [SerializeField] Transform _t;
        [SerializeField] Rigidbody2D _rb;
        [SerializeField] Animator _ani;
        [SerializeField] BoxCollider2D _attackBox;
        [SerializeField] PlayerValues PlayerDataBase;
        [Header("Tempos de Ação")]
        [SerializeField] bool ComboTime;

        public static bool OnGrounded;
        private static readonly int IsStop = Animator.StringToHash("IsStop");

        public static int Life;

        [SerializeField] float attackCoolDown;

        void Start()
        {
            GetVariables();
        }


        void Update()
        {

            Move();

            if (Input.GetKeyDown(KeyCode.Space) && OnGrounded)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.F) && OnGrounded && attackCoolDown > _attackSpeed)
            {
                Attack();
            }
            attackCoolDown += Time.deltaTime;
        }

        void LateUpdate()
        {
            if (_rb.velocity.x == 0)
                _ani.SetBool(IsStop, true);
            else if
                (_rb.velocity.x != 0) _ani.SetBool(IsStop, false);
            Life = _lifeActual;

            _ani.SetFloat("YVelocity", _rb.velocity.y);
            if (_xp == 2)
            {
                LevelUp();
            }
        }


        void Move()
        {
            float xMovement = Input.GetAxisRaw("Horizontal");
            Vector2 yMovement = new(0, _rb.velocity.y);
            _rb.velocity = new Vector2(_speed * xMovement, yMovement.y);

            if (xMovement != 0)
                Flip((int)xMovement);
        }

        void Flip(int XValue)
        {
            _t.localScale = new Vector3(XValue, 1, 1);
        }

        void Jump()
        {
            _rb.AddForce(new Vector2(0, _jumpForce));
            _ani.SetTrigger("Jump");
        }
        void Attack()
        {
            _ani.SetTrigger("Attack");
            attackCoolDown = 0;
        }
        void LevelUp()
        {
            _xp = 0;
            gameObject.AddComponent<Power.Supernova_Conjuration>();
        }
        void GetVariables()
        {
            _lifeMax = PlayerDataBase.VidaMaxima;
            _lifeActual = _lifeMax;

            _speed = PlayerDataBase.Velocidade;
            _attackSpeed = PlayerDataBase.AtaqueVelocidade;
            _jumpForce = PlayerDataBase.ForcaPulo;
        }
    }
}
