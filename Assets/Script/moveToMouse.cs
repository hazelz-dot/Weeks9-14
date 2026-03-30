using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class moveToMouse : MonoBehaviour
{
    public Vector2 destination;
    public float t = 0;

    public Tilemap tilemap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3Int cellPos = tilemap.WorldToCell(mousPos);
        Vector3 pos = tilemap.GetCellCenterWorld(cellPos);

        if ((t < 1) && (Vector3)mousPos == pos)
        {
            t += Time.deltaTime / 2f;
            transform.position = Vector2.Lerp(transform.position, destination, t);
        }
        else
        {

        }

        
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed == true)
        {
            t = 0;
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            destination = mousPos;
            Debug.Log("move");
        }
        
        

    }
}
