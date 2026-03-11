using UnityEngine;

public class BouncingNotes : MonoBehaviour
{
    //public so we can change the speed of the notes later in the inspector
    public float speedX = 1f;
    public float speedY = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //give the notes movement
        Vector2 newPosition = transform.position;
        newPosition.x += speedX;
        newPosition.y += speedY;
        transform.position = newPosition;

        //check if the position.x <0 or position.x > width of the screen 
        //Y : multiply speed by -1 
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0 || screenPos.x > Screen.width)
        {
            speedX = speedX * -1;
        }

        if (screenPos.y < 0 || screenPos.y > Screen.height)
        {
            speedY = speedY * -1;
        }
    }
}
