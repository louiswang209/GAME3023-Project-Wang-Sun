using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class EnemyBattleAct : MonoBehaviour
{

    public Enemy enemy = null;

    public Enemy PossibleEnemy1 = null;
    public Enemy PossibleEnemy2 = null;
    public Enemy PossibleEnemy3 = null;
    public Enemy PossibleEnemy4 = null; 
    public Enemy PossibleEnemy5 = null;

    public int Health = 0;
    public int Attack = 0;
    public int Defence = 0;
    private int maxAttack;
    private int maxDefence;
    private int maxHealth;
    private bool ifProtect = false;
    [SerializeField]
    Image enemyIcon;
    
    [SerializeField]
    private TMPro.TextMeshProUGUI enemyName;
    public BattleManager battleManager;
    public BattleUIText UIManager;

    private Skills skill1 = null;
    private Skills skill2 = null;
    private Skills skill3 = null;
    private Skills skill4 = null;

    public int tempHealth = 0;

    [SerializeField]
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(1, 6);
        switch (randomNum)
        {
            case 1:
                enemy = PossibleEnemy1;
                break;
            case 2:
                enemy = PossibleEnemy2;
                break;
            case 3:
                enemy = PossibleEnemy3;
                break;
            case 4:
                enemy = PossibleEnemy4;
                break;
            case 5:
                enemy = PossibleEnemy5;
                break;
            default:
                enemy = PossibleEnemy1;
                break;
        }

        skill1 = enemy.skill1;
        skill2 = enemy.skill2;
        skill3 = enemy.skill3;
        skill4 = enemy.skill4;
        enemyName.text = enemy.name;


        maxAttack = 20 * enemy.Attack;
        maxHealth = enemy.Health;
        maxDefence = 10 * enemy.Defence;
        Health = enemy.Health;
        Attack = enemy.Attack;
        Defence = enemy.Defence;

        healthBar.maxValue = Health;
        healthBar.value = Health;
        healthBar.Rebuild(CanvasUpdate.MaxUpdateValue);
    }

    // Update is called once per frame
    void Update()
    {
        enemyIcon.sprite = enemy.icon;
        enemyIcon.gameObject.SetActive(true);

        healthBar.value = Health;
    }


    public void TakeTurn()
    {
        if (Health < maxHealth / 4)
        {
            Health += (int)maxHealth / 4; //recover
            UIManager.DisplayText("Enemy used recover, enemy restored " + (int)maxHealth / 4 + " health.");
        }
        else if (Health > 3 * maxHealth / 4)
        {
            battleManager.PunchPlayer(Attack);//punch
            UIManager.DisplayText("Enemy used punch, ouch!");
        }
        else if (Health > maxHealth / 2)
        {
            Attack += 3 * enemy.Attack;//sword dance
            if (Attack <= maxAttack)
            {
                Attack = maxAttack;
            }
            UIManager.DisplayText("Enemy used sword dance, enemy's attack went up!");
        }
        else
        {
            battleManager.PunchPlayer(Attack);//punch
            UIManager.DisplayText("Enemy used punch, ouch!");
        }
    }

    public void GotPunch(int Atk)
    {
        if (!ifProtect)
        {
            Health -= (int)Atk / (3 * Defence) + 3;
        }
        else
        {
            ifProtect = false;
        }
        if (Health <= 0)
        {
            battleManager.Victory();

        }
    }
}
