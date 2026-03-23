using UnityEngine;
using UnityEngine.InputSystem; 

public class ClickToMove : MonoBehaviour
{
    public LineRenderer lr; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //add a new point into the line 
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, mousePos); 
    }
}
