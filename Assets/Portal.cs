//This Portal script will allow any Traveler to touch it, then it will send them to a specified location in a specified Scene 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This Portal leads to the Scene with the same name as its Tag, to a portal with the same Tag as this one.
/// </summary>
public class Portal : MonoBehaviour
{
    //Target scene is determined by tag
    //Target location within scene is determined by this string
    public string targetSpawn = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Portal Triggered with: " + collision.gameObject.name);
        //collision
        Traveller traveller = collision.GetComponent<Traveller>();
        
        if(traveller != null)
        {
            Debug.Log("Portal Warping " + traveller.gameObject.name);
            traveller.SetSpawn(targetSpawn);
            SceneManager.LoadScene(tag, LoadSceneMode.Single);
        }
    }
}
