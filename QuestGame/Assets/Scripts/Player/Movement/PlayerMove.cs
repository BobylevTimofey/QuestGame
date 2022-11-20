using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float speedMove = 4f;
    [SerializeField]
    private float speedRun = 7f;
    [SerializeField]
    private float jump = 2f;
    [SerializeField]
    private float gravity = 0.05f;

    private CharacterController characterController;
    private float xMove;
    private float zMove;
    private Vector3 moveDirection;
    private float speedCurrent;

    private void Start()
    {
        speedCurrent = speedMove;
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0)
            {
                animator.SetBool("IsRun", true);
                speedCurrent = speedRun;
            }
            else
            {
                animator.SetBool("IsRun", false);
                speedCurrent = speedMove;
            }

            PlayWalkAnimations();
            moveDirection = new Vector3(xMove, 0f, zMove);
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y += jump;
            }
        }
        moveDirection.y -= gravity;

        
        characterController.Move(moveDirection * speedCurrent * Time.deltaTime);
    }

    private void PlayWalkAnimations()
    {
        if (Input.GetAxis("Vertical") > 0)
            animator.SetBool("IsWalkForward", true);
        else if (Input.GetAxis("Vertical") < 0)
            animator.SetBool("IsWalkBack", true);
        else
        {
            animator.SetBool("IsWalkForward", false);
            animator.SetBool("IsWalkBack", false);
        }

        if (Input.GetAxis("Horizontal") > 0)
            animator.SetBool("IsWalkRight", true);
        else if (Input.GetAxis("Horizontal") < 0)
            animator.SetBool("IsWalkLeft", true);
        else
        {
            animator.SetBool("IsWalkRight", false);
            animator.SetBool("IsWalkLeft", false);
        }
    }
}
