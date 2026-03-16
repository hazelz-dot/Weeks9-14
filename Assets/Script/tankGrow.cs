using System.Collections;
using UnityEngine;

public class tankGrow : MonoBehaviour
{

    public Transform wheels;
    public Transform body;
    public Transform barrel;

    Coroutine growingCoroutine;
    Coroutine wheelsCoroutine;
    Coroutine bodyCoroutine;
    Coroutine barrelCoroutine; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wheels.localScale = Vector2.zero;
        body.localScale = Vector2.zero; 
        barrel.localScale = Vector2.zero;

        StartCoroutine(Growing()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TankGrow()
    {
        if(growingCoroutine != null)
        {
            StopCoroutine(growingCoroutine); 
        }

        if(wheelsCoroutine != null)
        {
            StopCoroutine(wheelsCoroutine);
        }

        if(bodyCoroutine != null)
        {
            StopCoroutine(bodyCoroutine);
        }

        if (barrelCoroutine != null)
        {
            StopCoroutine(barrelCoroutine);
        }
    }

    IEnumerator Growing()
    {
        yield return wheelsCoroutine = StartCoroutine(GrowWheels());
        yield return bodyCoroutine = StartCoroutine(GrowBody());
        yield return barrelCoroutine = StartCoroutine(GrowBarrel());
    }

    IEnumerator GrowWheels()
    {
        Debug.Log("Start growing wheels");
        float t = 0;
        wheels.localScale = Vector2.zero;
        body.localScale = Vector2.zero; 
        barrel.localScale = Vector2.zero;

        while (t < 1)
        {

            t += Time.deltaTime;
            wheels.localScale = Vector2.one*t;
            yield return null; 
        }

        Debug.Log("Finish growing wheels"); 

    }

    IEnumerator GrowBody()
    {
        Debug.Log("Start growing body");
        float t = 0;
        body.localScale = Vector2.zero;
        barrel.localScale = Vector2.zero;

        while(t < 1)
        {
            t += Time.deltaTime;
            body.localScale = Vector2.one*t;
            yield return null; 
        }

        Debug.Log("Finish growing body");
    }

    IEnumerator GrowBarrel()
    {
        Debug.Log("Start growing barrel");
        float t = 0;
        barrel.localScale = Vector2.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            barrel.localScale = Vector2.one*t;
            yield return null; 
        }

        Debug.Log("Finish growing barrel");
    }
}
