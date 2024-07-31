using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpForce = 400;
    public bool groundContact;
    public bool alive = true;
    public float speedIncreasePoint = 1f;
    public float speed;
    private Animator animator;
    public GameObject gameOver;


    private Vector2 startTouchPosition, endTouchPosition;
    private bool swipeUp, swipeLeft, swipeRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!alive) return;
        animator.SetBool("dead", false);
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        DetectSwipe();

        if (swipeUp || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (alive && groundContact)
            {
                StartCoroutine(WaitForOneSecond());
            }
            swipeUp = false; 
        }

        if (swipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            float xxleft = rb.transform.position.x;

            if (xxleft > -2.5)
            {
                rb.transform.position = new Vector3((xxleft - 2.5f), transform.position.y, transform.position.z);
            }
            else if (xxleft == -2.5)
            {
                speed = 8;
            }



            swipeLeft = false;
        }

        if (swipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        {
            float xxright = rb.transform.position.x;

            if (xxright < 2.5)
            {
                rb.transform.position = new Vector3((xxright + 2.5f), transform.position.y, transform.position.z);
            }
            else if (xxright == 2.5)
            {
                speed = 8;
            }

            swipeRight = false;
        }

        if (transform.position.y < 0)
        {
            die();
        }
    }

    public void die()
    {
        alive = false;
        gameOver.SetActive(true);
        animator.SetBool("dead", true);
    }

    IEnumerator WaitForOneSecond()
    {
        animator.SetBool("Jump", true);
        rb.AddForce(Vector3.up * jumpForce);
        rb.AddForce(Vector3.forward * 1000);
        yield return new WaitForSeconds(0.6f);
        rb.AddForce(Vector3.down * 8000);
        yield return new WaitForSeconds(0.1f);
        groundContact = false;
        animator.SetBool("Jump", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            groundContact = true;
        }
    }

    private void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    DetectSwipeDirection();
                    break;
            }
        }

        
    }

    private void DetectSwipeDirection()
    {
        Vector2 swipeVector = endTouchPosition - startTouchPosition;
        float swipeThreshold = 50.0f;

        if (swipeVector.magnitude > swipeThreshold)
        {
            float verticalSwipeDistance = endTouchPosition.y - startTouchPosition.y;
            float horizontalSwipeDistance = endTouchPosition.x - startTouchPosition.x;

            if (Mathf.Abs(verticalSwipeDistance) > Mathf.Abs(horizontalSwipeDistance))
            {
                if (verticalSwipeDistance > 0)
                {
                    swipeUp = true;
                    
                }
            }
            else
            {
                if (horizontalSwipeDistance > 0)
                {
                    swipeRight = true;
                    
                }
                else if (horizontalSwipeDistance < 0)
                {
                    swipeLeft = true;
                 
                }
            }
        }
    }
}
