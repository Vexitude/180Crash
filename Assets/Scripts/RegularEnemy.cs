using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Vex Vasquez
 * Last Updated: 10/31/2024
 * Controls Enemy Movement for Regular Enemies
 */


public class RegularEnemy : MonoBehaviour
{
    private Vector3 raycastLeftOrigin;
    private Vector3 raycastRightOrigin;

    public float movingrightSpeed = 5;
    public float movingleftSpeed = 5;


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
        
    }

}
