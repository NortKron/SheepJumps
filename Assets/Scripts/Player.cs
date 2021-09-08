using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour 
{

    public float SizeStep = 1;
    public float boundaryDestroy = -10;
    public float boundaryRespawn = 10;

    private bool isJump;
    private bool isRespawn;

    private Vector3 playerPosition;
    private Vector3 playerPositionStart;

    //public Transform prefabPlayer;

    //public Rigidbody2D rb;

    void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 3.0f, 200.0f, 200.0f), "X: " + transform.position.x);
    }

    void OnTriggerEnter()
    {
        Debug.Log("OnTriggerEnter");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = true;
        //Debug.Log("OnCollisionEnter2D");
        /*
        if (collision.gameObject.name == "Bed")
        {
            Debug.Log("Collision 1");
        }
        */
    }

    // Use this for initialization
    void Start()
    {
        // get start position player
        playerPosition = gameObject.transform.position;
        playerPositionStart = gameObject.transform.position;

        isJump = false;
        isRespawn = false;

        this.name = "Sheep";
    }

    // Update is called once per frame
    void Update()
    {
        //playerPosition.x += SizeStep;
        //transform.position = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
                
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + transform.right,
            //transform.position + transform.up,
            SizeStep * Time.deltaTime);
            //SizeStep);
        
        /*
        if (!isJump && Input.GetButtonDown("Jump"))
        {
            //isJump = true;
            Debug.Log("Jumping");
        }
        */
        
        if (!isRespawn && transform.position.x > boundaryDestroy)
        {
            isRespawn = true;
            Debug.Log("Respawn, X : " + transform.position.x);
            Instantiate(this.transform, playerPositionStart, Quaternion.identity);
        }
        
        if (transform.position.x > boundaryDestroy)
        {
            //Debug.Log("boundaryDestroy : " + boundaryDestroy);
            Debug.Log("Destroy, X : " + transform.position.x);
            Destroy(this.gameObject);
        }
    }
}
