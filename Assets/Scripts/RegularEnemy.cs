using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Vex Vasquez
 * Last Updated: 11/4/2024
 * Controls Enemy Movement for Regular Enemies
 */


public class RegularEnemy : MonoBehaviour
{
    private Vector3 raycastLeftOrigin;
    private Vector3 raycastRightOrigin;

    public float movingrightSpeed = 5;
    public float movingleftSpeed = 5;

    private bool ismovingleft = false;

    // Start is called before the first frame update
    void Start()
    {
        float halfWidth = transform.localScale.x / 2 + 0.1f;


        raycastLeftOrigin = transform.position - new Vector3(halfWidth, 0, 0);
        raycastRightOrigin = transform.position + new Vector3(halfWidth, 0, 0);


    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;


        if (!ismovingleft && Physics.Raycast(raycastLeftOrigin, Vector3.left, out hitInfo))
        {
            if (hitInfo.collider.GetComponent<PlayerMovement>())
            {
                ismovingleft = true;

            }
        }


        if (!ismovingleft && Physics.Raycast(raycastRightOrigin, Vector3.left, out hitInfo))
        {
            if (hitInfo.collider.GetComponent<PlayerMovement>())
            {
                ismovingleft = true;

            }
        }

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
            ismovingleft = false;

    }
}
