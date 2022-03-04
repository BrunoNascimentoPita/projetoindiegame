using UnityEngine;
namespace WindRose.PlayerContent
{
    public class Player : MonoBehaviour
    {
        [Header("Atributos")]
        [SerializeField] private int _jumpForce, _lifeActual, _lifeMax;
        [SerializeField] private int _damageValue;
        [SerializeField] private float _speed, _attackSpeed;
        [Header("Componentes")]
        [SerializeField] Rigidbody2D Rb;
        [SerializeField] Animator Ani;
        [SerializeField] BoxCollider2D AttackBox;

        public static bool OnGrounded;
        private static readonly int IsStopped = Animator.StringToHash("IsStopped");

        public static int Life;

        void Start()
        {
            print("O Jogador está na cena");
        }
        void Update()
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Space) && OnGrounded)
                Jump();

            if (Input.GetKeyDown(KeyCode.F) && OnGrounded)
                Ani.SetTrigger("IsAttacking");

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                /*  LoadVariables(); */
                print("Atributos Carregados");
            }
        }

        void LateUpdate()
        {
            if (Rb.velocity.x == 0)
                Ani.SetBool(IsStopped, true);
            else if
                (Rb.velocity.x != 0) Ani.SetBool(IsStopped, false);
            Life = _lifeActual;
        }

        void Move()
        {
            float xMovement = Input.GetAxisRaw("Horizontal");
            Vector2 yMovement = new(0, Rb.velocity.y);
            Rb.velocity = new Vector2(_speed * xMovement, yMovement.y);

            if (xMovement != 0)
                Flip((int)xMovement);
        }

        void Jump()
        {
            Rb.AddForce(new Vector2(0, _jumpForce));
        }

        void Flip(int direction)
        {
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }
}
