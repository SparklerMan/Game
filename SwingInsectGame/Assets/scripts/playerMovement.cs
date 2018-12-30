using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public playerController otherScript;
    public int speed;
    private float direction;
    private Vector2 movement;
    private bool isJump, isCrouch;
    

    public void Update()
    {
        
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = 1;
        }else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = -1;
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            isJump = true;
        }else if (Input.GetAxisRaw("Vertical") <= 0)
        {
            isJump = false;
        }
        //add crouch functionality here (set isCrouch if player presses shift)
    }

    public void FixedUpdate()
    {
        otherScript.Move(direction * speed * Time.deltaTime, isCrouch, isJump);
    }
}
