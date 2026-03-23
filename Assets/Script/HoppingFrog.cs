using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoppingFrog : MonoBehaviour
{
    Coroutine holdCoroutine;
    Coroutine jumpCoroutine; 

    public float speed = 5;
    public Vector2 movement;
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
        Debug.Log("Jump!");

        //start counting coroutine
        if (context.started)
        {
            jumpCoroutine = StartCoroutine(Holding()); 
        }

        //stop counting coroutine and jump 
        if (context.canceled)
        {
            StopCoroutine(Holding()); 
            StartCoroutine(Jumping());
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
        yield return null; 
    }

    IEnumerator Jumping()
    {
        Debug.Log("Froggie jump!");
        yield return null;
    }
}
