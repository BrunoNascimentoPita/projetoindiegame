using UnityEngine;
namespace WindRose.CoreCombat.EnemyBase.Goblin
{
    public class Goblin_IA : EnemyBase
    {
        [SerializeField] GoblinValues Data;
        [SerializeField] internal bool OnTarget;
        [SerializeField] internal bool _readyToMove;
        [SerializeField] float _attacktimer;
        [SerializeField] float timecont;
        private void Awake()
        {
            LoadComponentsAndObjects();
            LoadVariables();
        }
        void Update()
        {
            timecont += Time.deltaTime;
            if (_readyToMove) 
            {
                Move(); 
            }
        }

        void LateUpdate()
        {
            _life = LifeScript._life;
            LocalizePlayer();

            if (_life <= 0)
            {
                Die();
            }

            if (OnTarget && timecont > _attacktimer)
            {
                _readyToMove = false; 
                Attack();
            }
            
            if(Vector2.Distance(PlayerPos, _t.position) > _rangeAttack)
            {
                _readyToMove = true;                 
            } 
            else 
            {
                _readyToMove = false; 
            }
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }
        protected override void LoadVariables()
        {
            _speed = Data.Velocidade;
            LifeScript._life = Data.Vida;
            _rangeAttack = Data.AreadeAtaque;
            _attacktimer = Data.Velocidade_De_Ataque;
        }
        protected override void Move()
        {
            _t.position = Vector2.MoveTowards(_t.transform.position, PlayerPos, Time.deltaTime * _speed);
        }

        internal void Attack()
        {
            _ani.SetTrigger("Attack");
            timecont = 0;
        }
    }
}
