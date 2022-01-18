using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speed;

    public Animator animator;

    public SpriteRenderer SpriteRenderer;

    private int nbJump;

    public float jumpIntensity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && nbJump < 2) {
            
            animator.SetBool("isRunning", false);
            
            rb.AddForce(Vector2.up * jumpIntensity, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);

            nbJump += 1;
        }else if (rb.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", true);
            
            nbJump = 0;
        }

        if (transform.position.y < -5.0f)
        {
            Application.LoadLevel(0);
        }
            
        }
        
        
}
