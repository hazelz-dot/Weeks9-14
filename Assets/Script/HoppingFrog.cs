using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoppingFrog : MonoBehaviour
{
    public GameObject Froggie; 

    Coroutine holdCoroutine;
    Coroutine jumpCoroutine; 

    public float speed = 5;
    public Vector2 movement;
    public float t = 0;
    //public float hopT; 

    public AnimationCurve distance;
    public AnimationCurve hop;

    public Animator animator;
    public bool IsJumping = false;

    bool isOnLeaf = true;

    Vector2 startPosition;

    float resetTimer;

    public pointSystem pointSystem;

    public bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        IsJumping = false;

        isOnLeaf = true;

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //game over if froggie does not land on leaf
        if (!isOnLeaf && !IsJumping && t ==0)
        {
            resetTimer += Time.deltaTime;

            if (resetTimer >= 0.2f)
            {
                GameOver();
            }
        }
        else
        {
            resetTimer = 0f;
            gameOver = false; 
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Vector2 newPosition = transform.position;

        //Debug.Log("Jump!");

        //start counting coroutine
        if (context.started)
        {
            holdCoroutine = StartCoroutine(Holding());
        }

        //stop counting coroutine and jump 
        if (context.canceled && !IsJumping)
        {
            if (holdCoroutine != null)
            {
                StopCoroutine(holdCoroutine);
            }

            StartCoroutine(Jumping());

            if (jumpCoroutine != null)
            {
                StopCoroutine(jumpCoroutine);
                newPosition.y = 0; 
            }
            
        }

    }

    IEnumerator Jump()
    {
        yield return holdCoroutine = StartCoroutine(Holding()); 
        yield return jumpCoroutine = StartCoroutine(Jumping());
    }

    IEnumerator Holding()
    {
        Debug.Log("Player holds space");

        while (true)
        {
            yield return null;
            t += Time.deltaTime;
            //hopT += Time.deltaTime * t; 
            Debug.Log("counting");
        }
        

    }

    IEnumerator Jumping()
    {
        Debug.Log("Froggie jump!");

        IsJumping = true;

        animator.SetBool("IsJumping", true);

        yield return null;

        Vector2 newPosition = transform.position;


        while (t > 0)
        {
            newPosition.x += speed * distance.Evaluate(t);
            //newPosition.y += speed * hop.Evaluate(t); 
            transform.position = newPosition;
            t -= Time.deltaTime;

            yield return null;
        }

        t = 0;  

        animator.SetBool("IsJumping", false);

        IsJumping = false;

    }

    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<LeafSpawner>() != null)
        {
            isOnLeaf = true; 
        }
    }

    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/MonoBehaviour.OnCollisionExit2D.html
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<LeafSpawner>() != null)
        {
            isOnLeaf = false;
        }
    }

    public void GameOver()
    {
        //t = 0;
        IsJumping = false;
        isOnLeaf = true;
        gameOver = true;
        //transform.rotation = Quaternion.identity;
        //froggie go back to starting point
        transform.position = startPosition;

        if (pointSystem != null)
        {
            pointSystem.ResetScore();
        }
            
        Debug.Log("game over!"); 
    }
}

//froggie art from https://pop-shop-packs.itch.io/frogs-pixel-asset-pack/download/eyJleHBpcmVzIjoxNzc0ODgzMjE0LCJpZCI6MzQ2MTg5Nn0%3d%2eP35VH0WcCMoUmAIWwCKzATi9%2fl4%3d 