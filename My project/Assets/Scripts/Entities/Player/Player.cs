using UnityEngine;
public sealed class Player : CombatFunctions
{
    private int _jumpForce;
    internal bool OnGrounded = true;
    private static readonly int IsStopped = Animator.StringToHash("IsStopped");
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    public delegate void ChangeWeapon(); 
    public static event ChangeWeapon OnWeaponChanged; 
    
    public delegate void EntitieDead();

    private void Start()
    {
        InitComponentsAndVariables();
        EventManager.DamagePlayer += TakeDamage; 
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleWeapon();
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
        if (Life <= 0)
        {
            Ani.SetBool(IsDead, true);
        } 
    }
    private void Move(){
        float xMovement = Input.GetAxisRaw("Horizontal");
        Vector2 yMovement = new Vector2(0, Rb.velocity.y);
        Rb.velocity = new Vector2(Speed * xMovement, yMovement.y);

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
    private protected override void InitComponentsAndVariables()
    {
        base.InitComponentsAndVariables();
        Speed = 5;
        Life = 3;   
        _jumpForce = 200;
    }
    private void ToggleWeapon()
    {
        if (OnWeaponChanged != null) OnWeaponChanged();
    }
}
