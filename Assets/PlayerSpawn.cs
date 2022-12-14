using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    /// <summary>
    /// This is the Prefab of the player character we will use to spawn The Original
    /// </summary>
    [SerializeField]
    private GameObject playerPrefab;

    private static PlayerCharacterMovement player = null;
    /// <summary>
    /// Access to The Original Player
    /// </summary>
    public static PlayerCharacterMovement Player
    { 
        
        get { return player; }
        private set { }
    }

    void Awake()
    {
        if(player == null) // If there is no player, Instantiate The Original
        {
            GameObject newObject = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            player = newObject.GetComponent<PlayerCharacterMovement>();
        }
    }
}
