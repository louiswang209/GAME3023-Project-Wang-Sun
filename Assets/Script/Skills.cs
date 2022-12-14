using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Attribute which allows right click->Create
[CreateAssetMenu(fileName = "New Skill", menuName = "Skills/New Skill")]

public class Skills : ScriptableObject //Extending SO allows us to have an object which exists in the project, not in the scene
{
    public string description = "";

    //create the enum for item effect, so programmers can edit that within Unity when they create a new item or modifiy the existing item.
    public enum Skill { NONE, BULKUP, PROTECT, PUNCH, RECOVER, SDANCE };

}
