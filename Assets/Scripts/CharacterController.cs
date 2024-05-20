using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 3f; // Karakterin hareket hýzý
    public float jumpForce = 3f; // Karakterin zýplama kuvveti
    bool turnRight = true;
    private Rigidbody2D rb;
    private bool isGrounded;
    Animator playerAnimator;
    Vector3 scale;
    float moveInput;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            playerAnimator.SetBool("Jump", true);
        }
        if(Mathf.Approximately(rb.velocity.y, 0)&&playerAnimator.GetBool("Jump")) {
            playerAnimator.SetBool("Jump", false);
        }
        if (moveInput > 0 && turnRight == false)
        {
            flip();
           
        }
        if (moveInput < 0 && turnRight == true)
        {
            flip();
            
        }

    }

    void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        playerAnimator.SetFloat("Speed" , Mathf.Abs(moveInput));
        
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Eðer karakter zeminle temas ederse, isGrounded'ý true yap
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Eðer karakter zeminden ayrýlýrsa, isGrounded'ý false yap
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void flip()
    {
        //turnRight = !turnRight;
        scale= gameObject.transform.localScale;
        scale.x *= -1;
        gameObject.transform.localScale = scale;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            LoadCurrentScene();
        }
    }
    void LoadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
