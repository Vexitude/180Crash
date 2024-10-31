using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WumpaFruit : MonoBehaviour
{
    public int fruitValue = 1;

    public float rotSpeed;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
    }
}
