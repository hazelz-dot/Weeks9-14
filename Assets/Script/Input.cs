using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public Vector2 square; 
    public Vector2 destination;
    public float t = 0;
    public LineRenderer lr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lr.positionCount = 2; 
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (Vector3)movement * speed * Time.deltaTime;
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //transform.position += (Vector3)mousPos * speed * Time.deltaTime;

     
        

        if (t<1)
        {
            t += Time.deltaTime/5f;
            transform.position = Vector2.Lerp(transform.position, destination, t);
            lr.SetPosition(1, transform.position);
        }
        else
        {

        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        t = 0; 
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        destination = mousPos;
        lr.SetPosition(0, destination); 
        Debug.Log("move"); 
        
    }
}
