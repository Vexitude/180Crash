using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Name: Alan Buell
 * Date: 11/5/2024
 * Des: Handles hazards. To be attached to threatening foes.
 */
public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            collision.gameObject.GetComponent<PlayerMovement>().Respawn();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            other.gameObject.GetComponent<PlayerMovement>().Respawn();
        }
    }


}
