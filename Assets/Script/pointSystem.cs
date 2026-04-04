using UnityEngine;

public class pointSystem : MonoBehaviour
{
    public int score = 0; 
    public TMPro.TextMeshProUGUI Score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score.text = "Score: " + score;
        UpdateScore(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        score++;
        UpdateScore(); 
    }

    void UpdateScore()
    {
        Score.text = "Score: " + score; 
    }
}
