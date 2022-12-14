using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerBattleAct : MonoBehaviour
{
    [SerializeField]
    Image playerIcon;
    public BattleUIText UIManager;
    public BattleManager battleManager;

    private Skills skill1 = null;
    private Skills skill2 = null;
    private Skills skill3 = null;
    private Skills skill4 = null;


    public Slider healthBar;
    public Enemy player = null;

    public int Health = 0;
    public int Attack = 0;
    public int Defence = 0;
    private int maxAttack;
    private int maxDefence;
    private int maxHealth;
    private bool ifProtect = false;
    private bool ifReady = false;

    // Start is called before the first frame update
    void Start()
    {
        maxAttack = 20 * player.Attack;
        maxHealth = player.Health;
        maxDefence = 10 * player.Defence;
        Health = player.Health;
        Attack = player.Attack;
        Defence = player.Defence;

        healthBar.maxValue = Health;
        healthBar.value = Health;
        healthBar.Rebuild(CanvasUpdate.MaxUpdateValue);
    }

    // Update is called once per frame
    void Update()
    {
        ifReady = UIManager.ifAnimated();
        healthBar.value = Health;
    }
    public void Punch()
    {
        if (ifReady)
        {
            battleManager.PunchEnemy(Attack);
            battleManager.EnemyTurn();
            UIManager.DisplayText("Player used punch, nice hit!");
            UIManager.SetSkillPanelActive(false);
        }
    }
    public void GotPunch(int Atk)
    {
        if (ifReady)
        {
            if (!ifProtect)
            {
                Health -= (int)Atk / (3 * Defence) + 2;
            }
            else
            {
                ifProtect = false;
            }
            if (Health <= 0)
            {
                battleManager.Defeated();

            }
        }
    }
    public void BulkUp()
    {
        if (ifReady)
        {
            Attack += player.Attack;
            Defence += player.Defence;
            if (Attack <= maxAttack)
            {
                Attack = maxAttack;

            }
            if (Defence <= maxDefence)
            {
                Defence = maxDefence;
            }
            battleManager.EnemyTurn();
            UIManager.DisplayText("Player used bulk up, player's attack and defence went up!");
            UIManager.SetSkillPanelActive(false);
        }
    }
    public void Rocover()
    {
        if (ifReady)
        {
            Health += (int)maxHealth / 4;
            if (Health >= maxHealth)
            {
                Health = maxHealth;
                UIManager.DisplayText("Player used recover, player's health is now full!");
            }
            else
            {
                UIManager.DisplayText("Player used recover, player restored " + (int)maxHealth / 4 + " health.");
            }
            battleManager.EnemyTurn();
            UIManager.SetSkillPanelActive(false);
        }
    }
    public void SwordDance()
    {
        if (ifReady)
        {
            Attack += 3 * player.Attack;
            if (Attack <= maxAttack)
            {
                Attack = maxAttack;
            }
            battleManager.EnemyTurn();
            UIManager.DisplayText("Player used sword dance, player's attack went up!");
            UIManager.SetSkillPanelActive(false);
        }
    }
    public void Protect()
    {
        if (ifReady)
        {
            ifProtect = true;
            battleManager.EnemyTurn();
            UIManager.DisplayText("Player used protect, you will be protected for one round.");
            UIManager.SetSkillPanelActive(false);
        }
    }

    public void TakeTurn()
    {
        UIManager.SetSkillPanelActive(true);
    }

    public void GainHealth(int health)
    {
        player.Health += health;
    }
    public void GainAttack(int attack)
    {
        player.Attack += attack;
    }
    public void GainDefence(int defence)
    {
        player.Defence += defence;
    }
}
