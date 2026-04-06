using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float t = 0; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 newPosition = transform.position;
        newPosition.x = Random.Range(-8, 8);
        newPosition.y = Random.Range(-4, 4);

        t += Time.deltaTime;
        if (t >= 3)
        {
            t = 0; 
            transform.position = newPosition;
        }
    }
}
