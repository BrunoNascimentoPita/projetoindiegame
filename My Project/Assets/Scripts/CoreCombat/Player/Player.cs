using System;
using System.Collections; 
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
        [SerializeField] float _dashSize; 
        [Header("Valores Globais")]
        public static int _xp;
        [Header("Componentes")]
        [SerializeField] Transform _t;
        [SerializeField] Rigidbody2D _rb;
        [SerializeField] Animator _ani;
        [SerializeField] BoxCollider2D _attackBox;
        [SerializeField] PlayerValues PlayerDataBase;
        [SerializeField] SpriteRenderer _playerSprite;
        [Header("Tempos de Açao")]
        [SerializeField] bool ComboTime;
        [SerializeField] float attackCoolDown;
        [SerializeField] float skillCoolDown;
        [Header("Variaveis Auxiliares")]
        [SerializeField] bool OnFacingLeft; 
        public static bool OnGrounded;


        private static readonly int IsStop = Animator.StringToHash("IsStop");

        public static int Life;


        void Start()
        {
            GetVariables();
        }
        void Update()
        {

            Move();

            if (OnGrounded && Input.GetKeyDown(KeyCode.Space)) Jump();
            
            if (Input.GetKeyDown(KeyCode.F) && OnGrounded && attackCoolDown > _attackSpeed) Attack();

            if(_rb.velocity.x > 0 ) _rb.gravityScale  = 2; // A gravidade é maior quando o personagem está no ar. 
            
            skillCoolDown += Time.deltaTime; 
            attackCoolDown += Time.deltaTime;
        }

        void LateUpdate()
        {
            Life = _lifeActual;

            if (_rb.velocity.x == 0) _ani.SetBool(IsStop, true);
                else if(_rb.velocity.x != 0) _ani.SetBool(IsStop, false);

            if (-transform.localScale.x < 0) OnFacingLeft = true;
                else OnFacingLeft = false; 
        }

        void Move()
        {
            float xMovement = Input.GetAxisRaw("Horizontal");
            Vector2 yMovement = new(0, _rb.velocity.y);
            _rb.velocity = new Vector2(_speed * xMovement, yMovement.y);
            if (xMovement != 0) Flip((int)xMovement * -1);
        }

        void Flip(int XValue) //Gira o Personagem de Acordo com o sentido do movimento 
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

        IEnumerator Dash(int DashDirection)
        {
            _playerSprite.color = new Color32(20, 255, 255, 255);
            yield return new WaitForSeconds(0.5f); 
            _t.transform.position = new(transform.position.x + _dashSize * DashDirection, transform.position.y, transform.position.z); 
            _playerSprite.color = new Color32(255, 255, 255, 255);
        }

        void GetVariables()
        {
            _lifeMax = PlayerDataBase.VidaMaxima;
            _lifeActual = _lifeMax;
            _speed = PlayerDataBase.Velocidade;
            _attackSpeed = PlayerDataBase.AtaqueVelocidade;
            _jumpForce = PlayerDataBase.ForcaPulo;
            _dashSize = PlayerDataBase.EsquivaDistancia; 
        }
        
    }
}
