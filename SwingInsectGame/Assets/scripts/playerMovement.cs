using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    private float moveInput;
    public float moveSpeed;
    public bool jumpInput;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRaduis;
    public LayerMask whatIsGround;
    public LayerMask Hookable;

    private float extraJumps;
    public float extraJumpsValue;
    public float jumpForce;

    public bool isDead = false;
    public bool facing = false;
    private Vector3 newScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //rb variable is the rigidbody on our player object
    }


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRaduis, whatIsGround | Hookable);
        moveInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetKeyDown(KeyCode.W);
        //Checking wether the player is on the ground or not
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (jumpInput == true && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
    }
    void FixedUpdate()
    {
        flip();
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        

        //move left and right


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "killMe")
        {
            isDead = true;
        }else if (collision.collider.tag == "boundariesUnder")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }else if (collision.collider.tag == "cantaloop")
        {
            SceneManager.LoadScene(1);
        }

    }

    public void flip()
    {
        if(moveInput > 0 && !facing || moveInput < 0 && facing)
        {
            newScale = new Vector3(-1 * transform.localScale.x , transform.localScale.y, transform.localScale.z);
            transform.localScale = newScale;
            facing = !facing;
        }
    }


}
