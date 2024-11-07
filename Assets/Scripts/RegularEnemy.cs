using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * VEX VASQUEZ
 * Last Updated: 11/7/2024
 * Controls Enemy Movement for Regular Enemies
 */


public class RegularEnemy : MonoBehaviour
{
    private Vector3 raycastLeftOrigin;
    private Vector3 raycastRightOrigin;
    private Vector3 raycastBackOrigin;
    private Vector3 raycastFrontOrigin;

    public float movingrightSpeed = 5;
    public float movingleftSpeed = 5;
    public float movingBackSpeed = 5;
    public float movingFrontSpeed = 5;
    public float raycastDist = 1.2f;

    public bool isMovingLeft;
    public bool isMovingBack;
    public bool changeDir = false;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

        float halfWidth = transform.localScale.x / 2 + 0.1f;
        float hWidth = transform.localScale.z / 2 + 0.1f;


        raycastLeftOrigin = transform.position - new Vector3(halfWidth, 0, 0);
        raycastRightOrigin = transform.position + new Vector3(halfWidth, 0, 0);

        raycastBackOrigin = transform.position - new Vector3(hWidth, 0, 0);
        raycastFrontOrigin = transform.position + new Vector3(hWidth, 0, 0);


        if(!changeDir)
        {
            if (isMovingBack && Physics.Raycast(raycastBackOrigin, Vector3.back, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Wall") && hitInfo.distance < 0.1f)
                {
                    isMovingBack = false;
                }
            }
            else if (!isMovingBack && Physics.Raycast(raycastFrontOrigin, Vector3.forward, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Wall") && hitInfo.distance < 0.1f)
                {
                    isMovingBack = true;
                }
            }

            if (isMovingBack)
            {
                MoveBack();
            }

            if (!isMovingBack)
            {
                MoveFront();
            }
            Debug.DrawRay(raycastBackOrigin, Vector3.back * raycastDist, Color.red);
            Debug.DrawRay(raycastFrontOrigin, Vector3.forward * raycastDist, Color.red);
        }
        else
        {

            if (isMovingLeft && Physics.Raycast(raycastLeftOrigin, Vector3.left, out hitInfo))
            {
                //print( "Left: " + hitInfo.distance);
                //("Tag: " + hitInfo.collider.tag);
                //print("Hit: " + hitInfo.collider.gameObject.name);

                if (hitInfo.collider.CompareTag("Wall") && hitInfo.distance < 0.1f)
                {
                    //print("Left");
                    isMovingLeft = false;

                }
            }
            else if (!isMovingLeft && Physics.Raycast(raycastRightOrigin, Vector3.right, out hitInfo))
            {
                //print("Right: " + hitInfo.distance);
                if (hitInfo.collider.CompareTag("Wall") && hitInfo.distance < 0.1f)
                {
                    //print("Right");
                    isMovingLeft = true;

                }
            }
            Debug.DrawRay(raycastLeftOrigin, Vector3.left * raycastDist, Color.red);

            Debug.DrawRay(raycastRightOrigin, Vector3.right * raycastDist, Color.red);


            if (isMovingLeft)
            {
                MoveLeft();
            }

            if (!isMovingLeft)
            {
                MoveRight();
            }
        }
        

    }

    private void MoveLeft()
    {
        transform.position += Vector3.left * movingleftSpeed * Time.deltaTime;
    }

    private void MoveRight()
    {

        transform.position += Vector3.right * movingrightSpeed * Time.deltaTime;

    }

    private void MoveBack()
    {
        transform.position += Vector3.back * movingBackSpeed * Time.deltaTime;
    }

    private void MoveFront()
    {
        transform.position += Vector3.forward * movingFrontSpeed * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            if(collision.gameObject.GetComponent<PlayerMovement>().isAttacking)
            {
                //player is attacking
                print("Respawn");
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerMovement>().Respawn();
            }
                
            
        }
    }

}
