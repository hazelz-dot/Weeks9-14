using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{
    public GameObject thingToSpawn;
    public float spawnTime = 1/10;
    float t;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("start spawning"); 
            Instantiate(thingToSpawn, transform.position, transform.rotation);
            Debug.Log("Done spawning"); 
        }
     }
}
