using UnityEngine;
public class Player : CombatEntities
{
    [SerializeField] internal bool OnGrounded;

    private static readonly int IsStopped = Animator.StringToHash("IsStopped");
    private UIController ui;
    public static int _Life; 

    private void Start()
    {
        ui = GameObject.FindObjectOfType<UIController>();
        InitComponentsAndVariables(5,300,3, 1);
        _Life = 5; 
        LightBanditAttackArea.DealDamagePlayer += TakeDamage;
    }
    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && OnGrounded) {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.F) && OnGrounded) {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            _Life += 1;
        }
        
    }
    private void LateUpdate()
    {
        if (Rb.velocity.x == 0)
        {
            Ani.SetBool(IsStopped, true);
        }
        else if(Rb.velocity.x != 0)
        {
            Ani.SetBool(IsStopped, false);
        }
        if (_life <= 0)
        {
            Die(); 
        }
        _Life = _life; 
    } 
    private void Move(){
        float xMovement = Input.GetAxisRaw("Horizontal");
        Vector2 yMovement = new Vector2(0, Rb.velocity.y);
        Rb.velocity = new Vector2(_speed * xMovement, yMovement.y);

        if (xMovement != 0){
            Flip((int)xMovement);
        }
    }
    private void Jump() {
        Rb.AddForce(new Vector2(0,_jumpForce));
    }
    private void Flip(int direction) 
    {
        transform.localScale = new Vector3(direction,1,1);
    }
    public override void TakeDamage(int damage) 
    {
        
        Ani.SetTrigger("IsHurt");
        _life -= damage; 
    } 
}
