using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptHorizontal : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
    }
    void Update()
    {
        Vector2.ClampMagnitude(rb.velocity, moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("BarriorLeft"))
        {
            rb.AddForce(Vector2.right * moveSpeed * 2f, ForceMode2D.Impulse);
            animator.SetBool("Trigger", true);
        }
        if(other.CompareTag("BarriorRight"))
        {
            rb.AddForce(Vector2.left * moveSpeed * 2f, ForceMode2D.Impulse);
            animator.SetBool("Trigger", false);
        }
    }
}

