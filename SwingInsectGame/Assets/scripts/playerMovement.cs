using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody2D rb;
	private float moveInput;
	public float moveSpeed;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRaduis;
	public LayerMask whatIsGround;

	private float extraJumps;
	public float extraJumpsValue;
	public float jumpForce;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();

		//rb variable is the rigidbody on our player object
	}
	

	void FixedUpdate ()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRaduis, whatIsGround);

		//Checking if player is on the ground

		moveInput = Input.GetAxisRaw ("Horizontal");
		rb.velocity = new Vector2 (moveInput * moveSpeed, rb.velocity.y);

		//move left and right

		if (isGrounded == true ){
			extraJumps = extraJumpsValue;
		}

		if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) {
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
		}
	}
}
