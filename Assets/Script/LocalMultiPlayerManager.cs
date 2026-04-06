using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiPlayerManager : MonoBehaviour
{
    public List<Sprite> playerSprites;
    public List<PlayerInput> players; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoined(PlayerInput player)
    {
        players.Add(player);

        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[player.playerIndex];

        localMultiPlayerController controller = player.GetComponent<localMultiPlayerController>(); 
        controller.manager = this;
    }

    public void PlayerAttacking(PlayerInput attackingPlayer)
    {
        for(int i = 0; i < players.Count; i++)
        {
            if (attackingPlayer == players[i]) continue; 

            if (Vector2.Distance(attackingPlayer.transform.position, players[i].transform.position)<0.5f)
            {
                Debug.Log("Player" + attackingPlayer.playerIndex + " attacked player " + players[i].playerIndex); 
            } 
        }
    }
}
