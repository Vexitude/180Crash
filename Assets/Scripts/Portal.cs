using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Name: Alan Buell
 * Date: 11/18/2024
 * Des: Handles teleporting to a new level
 */
public class Portal : MonoBehaviour
{
    public GameObject teleportPoint;
    public int LvlEqual = 1;


    private void OnTriggerEnter(Collider other)
    {
        

        other.transform.position = teleportPoint.transform.position;
    }
}
