using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public struct Inventory
{
    public int Id;
    public string Name;
    public float buster;
}

public class Player : MonoBehaviour //, IPointerDownHandler
{

    public float SizeStep = 1;
    public float JumpForce = 0.03f;
    public float timeRespawn = 0.5f;

    public GameObject panelTutorial;
    public GameObject panelH;

    private bool isRunnig;
    private bool isCanJump;

    private Vector3 playerPositionStart;

    //private float boundaryRespawn = -10;
    private float boundaryDestroy = -10;

    private new Rigidbody2D rigidbody;
    Animator animator;
    SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        //boundaryRespawn = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        boundaryDestroy = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f)).x + 1f;

        //Debug.Log("size : " + GetComponent<SpriteRenderer>().sprite.rect.size);

        //Vector2 v1 = Camera.main.ViewportToWorldPoint( new Vector2(0, 0) );
        //Vector2 v2 = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        //Debug.Log("boundary : " + v1.x + ", " + v2.x);

        // get start position player
        playerPositionStart = gameObject.transform.position;

        panelTutorial.GetComponent<Text>().text = "Tap to jump";
        //panelH.GetComponent<Text>().text = "X : " + transform.position.x;

        rigidbody = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        isRunnig = true;
        isCanJump = true;
        this.name = "Sheep";
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunnig)
        {
            panelH.GetComponent<Text>().text = "X : " + transform.position.x;

            // Овечка бежит вперёд
            transform.position = Vector3.MoveTowards(
                transform.position,
                transform.position + transform.right,   
                SizeStep * Time.deltaTime);

            //Input.GetTouch(0).

            // Прыжок
            //if (Input.GetButtonDown("Jump") && isCanJump)
            if (Input.touchCount > 0 || Input.GetButton("Jump"))
            //if (Input.GetButton("Jump"))
            {
                if (isCanJump) Jump();
            }

            if (transform.position.x > boundaryDestroy)
            {
                StartCoroutine(InstDestroyFail(0));
            }
        }
        else
        {
            // to do something
        }
    }

    void Jump()
    {
        //Debug.Log("Jump");
        rigidbody.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(5.0f, 3.0f, 200.0f, 200.0f), "X: " + transform.position.x);
    }

    void OnTriggerEnter()
    {
        Debug.Log("OnTriggerEnter");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision tag : " + collision.gameObject.name);

        if (collision.gameObject.name == "Bed")
        {
            //stumble animation
            rigidbody.AddForce(transform.up * 5, ForceMode2D.Impulse);
            rigidbody.AddForce(transform.forward * 10, ForceMode2D.Impulse);

            panelTutorial.GetComponent<Text>().text = "Jump fail";

            isCanJump = false;
            isRunnig = false;
            StartCoroutine(InstDestroyFail(timeRespawn));
        }
    }

    private IEnumerator InstDestroyFail(float time)
    {
        yield return new WaitForSeconds(time);

        // Создать новую овечку за левой границей экрана
        Instantiate(this.transform, playerPositionStart, Quaternion.identity);

        // Удалить овечку при пересечении правой границы экрана
        Destroy(this.gameObject);
    }

    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("eventData : " + eventData.position);
    }
    */

    void OnBecameVisible()
    {
        //Debug.Log("OnBecameVisible");
    }

    private void OnBecameInvisible()
    {
        //StartCoroutine(InstDestroyFail(0));
    }
}
