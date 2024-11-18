using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
 * VEX VASQUEZ
 * Last Updated: 11/17/2024
 * Controls range crate can spawn wumpa fruit and deals with crate collisions
 */
public class Crate : MonoBehaviour
{
    [RangeAttribute(0, 5)]
    public int wumpafruit;

    public GameObject prefab;
    private Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = gameObject.transform.position;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>().isAttacking)
        {
            Destroy(gameObject);

            for (int i = 0; i < wumpafruit; i++)
            {

                //Instantiate(prefab, spawnPosition, Quaternion.identity);
                PrefabUtility.InstantiatePrefab(prefab);

            }
        }
    }
}
