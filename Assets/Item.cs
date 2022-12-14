using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    public Sprite icon; // icon for this item

    public string description = "this is an item";

    public bool isConsumable = true;

    public void Use()
    {
        Debug.Log("Used item: " + name + "-- " + description);
    }
}
