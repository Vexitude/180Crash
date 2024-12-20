using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * Name: Alan Buell
 * Date: 10/31/2024
 * Des: Player inputs, movement, lives.
 */

/*
 * Name: VEX VASQUEZ
 * Date: 11/6/2024
 * Des: Worked solely on spin attack for player
 */
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8;
    public float jumpForce = 7;
    public float deathY = -5f;
    public float raycastDist = 1.2f;

    public bool isAttacking = false;

    public int lives = 3;
    public int totalFruit = 0;
    public int LvlNum = 0;

    public GameObject respawnPoint1;
    public GameObject respawnPoint2;
    public GameObject respawnPoint3;
    public GameObject respawnPoint4;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded ())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(transform.position.y <= deathY)
        {
            Respawn();
        }

        if(!isAttacking && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SpinAttack());

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WumpaFruit>())
        {
            totalFruit += other.GetComponent<WumpaFruit>().fruitValue;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("JumpKill"))
        {
            Destroy(other.transform.parent.gameObject);
        }
        //resets lives when going through a portal, emulates starting a new game
        if(other.GetComponent<Portal>())
        {
            lives = 3;
            LvlNum += other.GetComponent<Portal>().LvlEqual;
        }

    }

    


    public void Respawn()
    {
        lives--;
        if(lives <= 0)
        {
            print("Game Over");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            SceneManager.LoadScene(1);
        }
        else
        {
            if(LvlNum == 0)
            {
                transform.position = respawnPoint1.transform.position;
            }
            else if (LvlNum == 1)
            {
                transform.position = respawnPoint2.transform.position;
            }
            else if (LvlNum == 2)
            {
                transform.position = respawnPoint3.transform.position;
            }
            else if (LvlNum == 3)
            {
                transform.position = respawnPoint4.transform.position;
            }
           
        }
    }


    private bool IsGrounded()
    {
        bool isGrounded = false;

        if(Physics.Raycast(transform.position, Vector3.down,raycastDist))
        {
            isGrounded = true;
        }
        return isGrounded;
    }

    IEnumerator SpinAttack()
    {
        Color startcolor = GetComponent<MeshRenderer>().material.color;

        GetComponent<MeshRenderer>().material.color = Color.red;

        isAttacking = true;

        yield return new WaitForSeconds(2);

        GetComponent<MeshRenderer>().material.color = startcolor;

        isAttacking = false;
    }




}
