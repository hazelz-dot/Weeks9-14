using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{
    public GameObject thingToSpawn;

    void Update()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = mousPos;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("start spawning"); 
            Instantiate(thingToSpawn, transform.position, transform.rotation);
            Debug.Log("Done spawning"); 
        }
     }
}
