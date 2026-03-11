using UnityEngine;

public class FirstScript : MonoBehaviour
{
    float speed = 0.01f;

    //Vector2 bottomLeft;
   // Vector2 topRight; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)); 
        //topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.x += speed; 
        transform.position = newPosition;

        //Vector3 newPosition = transform.position;
        //newPosition.x += speed * Time.deltaTime; 

        //check if the position.x <0 or position.x > width of the screen 
        //Y : ,ultiply speed by -1 
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //if (screenPos.x < 0 || screenPos.x > Screen.width)
        if (screenPos.x < 0)
        {
            //newPosition.x = bottomLeft.x; 

            speed = speed * -1; 
        }

        if (screenPos.x > Screen.width)
        {
            //newPosition.x = topRight.x; 

            speed = speed * -1;
        }
    }
}
