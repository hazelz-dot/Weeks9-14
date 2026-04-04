using UnityEngine;

public class LeafSpawner : MonoBehaviour
{

    public GameObject leaf;
    bool hasSpawned = false;
    public float minDistance = 2f;
    public float maxDistance = 5f;

    public pointSystem pointSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //leaf = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //detect collision 
    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html 
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (hasSpawned) return; 

        //if we collide with froggie... 
        // we spawn a new leaf for froggie to hop on to 
        if (collision.gameObject.GetComponent<HoppingFrog>() != null)
        {
            Debug.Log("froggie on leaf"); 

            hasSpawned = true;

            if(pointSystem != null)
            {
                pointSystem.AddPoint(); 
            }

            float distance = Random.Range(minDistance, maxDistance);

            Vector2 spawnPos = new Vector2(transform.position.x + distance, transform.position.y);

            Instantiate(leaf, spawnPos, Quaternion.identity);
        }
    }
}
