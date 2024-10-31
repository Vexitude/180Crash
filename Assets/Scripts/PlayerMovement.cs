using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Name: Alan Buell
 * Date: 10/31/2024
 * Des: Player inputs, movement, lives.
 */
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpForce = 10;
    public float deathY = -5f;

    public int lives = 3;

    private Vector3 moveDir;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            moveDir = Vector3.left;

            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir = Vector3.right;

            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDir = Vector3.forward;

            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir = Vector3.back;

            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
        }

    }

}
