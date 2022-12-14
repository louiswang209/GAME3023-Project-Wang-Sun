using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy/New Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    public Sprite icon; // icon for this item

    public int Health = 0;
    public int Attack = 0;
    public int Defence = 0;

    public Skills skill1 = null;
    public Skills skill2 = null;
    public Skills skill3 = null;
    public Skills skill4 = null;

}
