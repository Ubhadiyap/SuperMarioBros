using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour {

    public float speed = 20f;

    private Animator animator;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        animator.Play("Idle");
	}

    private void FixedUpdate()
    {
        float axis = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * speed * axis);
        animator.SetInteger("Speed", (int)axis);



        this.Run(axis);
        this.TurnBack(axis);
        this.StopRunning(axis);

    }

    //activate the animation "Run" of mario 
    private void Run(float axis = 0f)
    {
        if (axis > 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            animator.SetBool("isRunning", true);
        }

        if (axis < -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            animator.SetBool("isRunning", true);
        }
    }

    //deactivate the Run animation of mario
    private void StopRunning(float axis = 0f)
    {
        if ((int)axis == 0 && !Input.anyKey)
        {
            animator.SetBool("isRunning", false);
        }
    }

    // activate the turn function when the user change the input that is using at the momento of mario being running.
    private void TurnBack(float axis = 0f)
    {
        bool inputRight = Input.GetKey("right");
        bool inputLeft = Input.GetKey("left");

        if (animator.GetBool("isRunning") == true && axis == 0f && (inputRight || inputLeft)) animator.SetTrigger("RunBack");
    }

}
