using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{
    //set start and end positions for the movement
    public Transform start; 
    public Transform end;
    public float t = 0;

    //use animation curve to imitate human eye movement
    public AnimationCurve curve; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 1)
        {
            t = 0; 
        }

        //transform.position = Vector2.Lerp(start.position, end.position, t); 
        transform.position = Vector2.Lerp(start.position, end.position, curve.Evaluate(t));
    }
}
