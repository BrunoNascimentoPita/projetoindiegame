using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Atributos")]
    [SerializeField]
    private float Speed = 5;
    [SerializeField]
    private float JumpForce = 200;
    [Header("Componentes")]
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator ani; 
    [Header("Estados")]
    [SerializeField]
    private bool OnGrounded; 

    ///Scripts Auxiliares
    private GroundCheck gc;
    
    private void Start()
    {
        gc = GetComponentInChildren<GroundCheck>();
        gc.OnGrounded += GroundMod;
        InitComponents();
    }
    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && OnGrounded) {
            Jump();
        }
    }
    private void LateUpdate()
    {
        if (rb.velocity.x == 0)
        {
            ani.SetBool("IsStopped", true);
        }
        else if(rb.velocity.x != 0)
        {
            ani.SetBool("IsStopped", false);
        }
    }
    private void Move()
    {
        float XMovement = Input.GetAxisRaw("Horizontal");
        Vector2 YMovement = new Vector2(0, rb.velocity.y);
        rb.velocity = new Vector2(Speed * XMovement, YMovement.y);

        if (XMovement != 0){
            Flip((int)XMovement);
        }
    }
    private void Jump() {
        rb.AddForce(new Vector2(0,JumpForce));
    }
    private void GroundMod(bool IsTrue) {
        OnGrounded = IsTrue; //Inverte o estado sempre que chamado
    }
    private void Flip(int direction) //Gira o personagem caso o ele se mova para a esquerda 
    {
        transform.localScale = new Vector3(direction,1,1);
    }
    private void InitComponents() { // Atribui os componentes nas suas váriaveis 
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
}
