using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour 
{
    [Header("Atributos")]
    [SerializeField]
    protected int Life; 
    [SerializeField]
    protected float Speed;
    [SerializeField]
    protected float RangeAttack;
    [Header("Estados")]
    [SerializeField]
    protected bool OnRange;
    [SerializeField]
    protected float DistanceToTarget;
    [Header("Componentes")]
    protected Vector2 playerPosition;
    protected Rigidbody2D rb;
    protected Transform t; 

    protected void InitComponents() {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    protected void SearchPlayer() {
        playerPosition = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        DistanceToTarget = Vector2.Distance(t.localPosition, playerPosition);
    }
    protected void Move() {
        t.position = Vector2.MoveTowards(t.localPosition, playerPosition, this.Speed * Time.deltaTime);
    }
}
