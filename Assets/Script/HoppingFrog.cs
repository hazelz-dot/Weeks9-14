using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoppingFrog : MonoBehaviour
{
    Coroutine holdCoroutine;
    Coroutine jumpCoroutine; 

    public float speed = 5;
    public Vector2 movement;
    public float t = 0;
    //public float hopT; 

    public AnimationCurve distance;
    public AnimationCurve hop; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //count when the jump starts
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Vector2 newPosition = transform.position;

        //Debug.Log("Jump!");

        //start counting coroutine
        if (context.started)
        {
            jumpCoroutine = StartCoroutine(Holding());
        }

        //stop counting coroutine and jump 
        if (context.canceled)
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
            hopT += Time.deltaTime * t; 
            Debug.Log("counting");
        }
        

    }

    IEnumerator Jumping()
    {
        Debug.Log("Froggie jump!");
        yield return null;

        Vector2 newPosition = transform.position;

        while (t > 0)
        {
            newPosition.x += speed * distance.Evaluate(t);
            newPosition.y += speed * hop.Evaluate(t/); 
            transform.position = newPosition;
            t -= Time.deltaTime;
            yield return null;
        }
        
    }
}

//froggie art from https://pop-shop-packs.itch.io/frogs-pixel-asset-pack/download/eyJleHBpcmVzIjoxNzc0ODgzMjE0LCJpZCI6MzQ2MTg5Nn0%3d%2eP35VH0WcCMoUmAIWwCKzATi9%2fl4%3d 