using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traveller : MonoBehaviour
{
    private string lastSpawn = "";
    public void SetSpawn(string spawn)
    {
        lastSpawn = spawn;
    }
    
    private void Start()
    {
#if UNITY_EDITOR
        EditorKillClones();
#endif
       if(!gameObject.IsDestroyed())
        {
            DontDestroyOnLoad(gameObject); // This tells Unity that this gameObject should not be cleaned up with all the others when changing scenes
            SceneManager.sceneLoaded += OnSceneLoadedAction;
        }
    }

    void OnSceneLoadedAction(Scene scene, LoadSceneMode loadMode)
    {
        if(lastSpawn != "")
        {
            //Go through all the Spawn Locations to find the one given
            bool transportSuccessful = false;

           PlayerSpawn[] spawnPoints = FindObjectsOfType<PlayerSpawn>(); // Find all possible Spawn Locations
            foreach(PlayerSpawn spawn in spawnPoints)
            {
                if(spawn.name == lastSpawn)
                {
                    //Go to that spawn point
                    transform.position = spawn.transform.position;
                    transportSuccessful = true;
                    break;
                }
            }

            if(!transportSuccessful)
            {
                throw new System.Exception("Could not find spawn point: " + lastSpawn);
            }
        }
    }

    /// <summary>
    /// This is a convenience function only to be used while we keep Player Characters in all the scenes.
    /// </summary>
    private void EditorKillClones()
    {
        PlayerCharacterMovement me = GetComponent<PlayerCharacterMovement>();
        if (PlayerSpawn.Player != me)
        {
            //If we are not the original... We must die.
            Destroy(gameObject);
        }
    }
}
