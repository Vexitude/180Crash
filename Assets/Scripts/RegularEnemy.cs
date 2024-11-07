using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * VEX VASQUEZ
 * Last Updated: 11/6/2024
 * Controls Enemy Movement for Regular Enemies
 */


public class RegularEnemy : MonoBehaviour
{
    private Vector3 raycastLeftOrigin;
    private Vector3 raycastRightOrigin;

    public float movingrightSpeed = 5;
    public float movingleftSpeed = 5;
    public float raycastDist = 1.2f;

    public bool ismovingleft;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

        float halfWidth = transform.localScale.x / 2 + 0.1f;


        raycastLeftOrigin = transform.position - new Vector3(halfWidth, 0, 0);
        raycastRightOrigin = transform.position + new Vector3(halfWidth, 0, 0);

        if (ismovingleft && Physics.Raycast(raycastLeftOrigin, Vector3.left, out hitInfo))
        {
            //print( "Left: " + hitInfo.distance);
            //("Tag: " + hitInfo.collider.tag);
            print("Hit: " + hitInfo.collider.gameObject.name);

            if (hitInfo.collider.CompareTag("Wall") && hitInfo.distance < 0.1f)
            {
                print("Left");
                ismovingleft = false;

            }
        }
        else if (!ismovingleft && Physics.Raycast(raycastRightOrigin, Vector3.right, out hitInfo))
        {
            print("Right: " + hitInfo.distance);
            if (hitInfo.collider.CompareTag("Wall") && hitInfo.distance < 0.1f)
            {
                print("Right");
                ismovingleft = true;

            }
        }
        Debug.DrawRay(raycastLeftOrigin, Vector3.left * raycastDist, Color.red);

        Debug.DrawRay(raycastRightOrigin, Vector3.right * raycastDist, Color.red);


        if(ismovingleft)
        {
            MoveLeft();
        }

        if (!ismovingleft)
        {
            MoveRight();
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            if(collision.gameObject.GetComponent<PlayerMovement>().!isAttacking)
            {
                print("Respawn");
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
                
            
        }
    }

}
