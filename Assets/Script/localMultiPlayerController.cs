using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class localMultiPlayerController : MonoBehaviour
{
    public LocalMultiPlayerManager manager;
    public PlayerInput playerInput; 
    public Vector2 movementInput;
    public float speed = 5;

    Coroutine AttackCoroutine;
    public AnimationCurve curve;

    public AudioSource AttackSFX;
    public AudioSource AttackSFX2;
    public AudioSource InteractSFX; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void AttackPlayer()
    {
        AttackCoroutine = StartCoroutine(Attacking()); 
    }

    IEnumerator Attacking()
    {
        yield return AttackCoroutine = StartCoroutine(Attack());

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>(); 
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        

        if (context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + " attack!");
            manager.PlayerAttacking(playerInput);
            AttackCoroutine = StartCoroutine(Attacking());
            AttackSFX.Play();
            AttackSFX2.Play(); 
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + " is interacting...");
            InteractSFX.Play(); 
        }
    }

     IEnumerator Attack()
    {
        //when players attacks, players[i] shrinks/gets squeezed 
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime; 
            transform.localScale = Vector2.one *15 * curve.Evaluate(t);
            yield return null; 
        }

    }
}
