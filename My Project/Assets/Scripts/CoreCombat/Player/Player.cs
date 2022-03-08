using UnityEngine;
namespace WindRose.PlayerContent
{
    public sealed class Player : MonoBehaviour
    {
        [Header("Atributos")]
        [SerializeField] int _jumpForce;
        [SerializeField] int _lifeActual, _lifeMax;
        [SerializeField] int _damageValue;
        [SerializeField] float _speed, _attackSpeed;
        [Header("Componentes")]
        [SerializeField] Transform _t;
        [SerializeField] Rigidbody2D _rb;
        [SerializeField] Animator _ani;
        [SerializeField] BoxCollider2D _attackBox;
        [SerializeField] PlayerValues PlayerDataBase;

        public static bool OnGrounded;
        private static readonly int IsStopped = Animator.StringToHash("IsStopped");

        public static int Life;

        float attackCoolDown;

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
                _ani.SetTrigger("IsAttacking");
                attackCoolDown = 0;
            }

            attackCoolDown += Time.deltaTime;
        }

        void LateUpdate()
        {
            if (_rb.velocity.x == 0)
                _ani.SetBool(IsStopped, true);
            else if
                (_rb.velocity.x != 0) _ani.SetBool(IsStopped, false);
            Life = _lifeActual;
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
            transform.localScale = new Vector3(XValue, 1, 1);
        }

        void Jump()
        {
            _rb.AddForce(new Vector2(0, _jumpForce));
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
