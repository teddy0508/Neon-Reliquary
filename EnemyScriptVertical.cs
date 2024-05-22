using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptVertical : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.AddForce(Vector2.down * moveSpeed, ForceMode2D.Impulse);
    }
    void Update()
    {
        Vector2.ClampMagnitude(rb.velocity, moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("BarriorUp"))
        {
            rb.AddForce(Vector2.up * moveSpeed * 2f, ForceMode2D.Impulse);
            animator.SetBool("Trigger", true);
        }
        if(other.CompareTag("BarriorDown"))
        {
            rb.AddForce(Vector2.down * moveSpeed * 2f, ForceMode2D.Impulse);
            animator.SetBool("Trigger", false);
        }
    }
}
