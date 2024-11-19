using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * VEX VASQUEZ
 * Last Updated: 11/18/2024
 * Controls Breakable Platform wait time after player jumps on it
 */

public class BreakPlatform : MonoBehaviour
{
    private bool wait = true;

    public int waitToBreak;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            StartCoroutine(BreakFall());
 

        }
    }

    private IEnumerator BreakFall()
    {
        yield return new WaitForSeconds(waitToBreak);

        TurnOff();

        yield return new WaitForSeconds(5);

        TurnOn();
    }

    private void TurnOff()
    {
        gameObject.SetActive(false);
    }

    private void TurnOn()
    {
        gameObject.SetActive(true);
    }

}
