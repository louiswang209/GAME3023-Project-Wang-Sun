using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    Button FleeButton, Skill1, Skill2, Skill3, Skill4;

    public PlayerBattleAct playerObject;
    public EnemyBattleAct enemyObject;
    public BattleUIText UIManager;
    bool ifPlayerTurn = true;
    bool ifEnemyTurn = false;
    bool NextTurn = false;
    bool gameOver = false;


    // Update is called once per frame
    void Update()
    {

        NextTurn = UIManager.ifAnimated();
        if (!gameOver)
        {
            if (NextTurn && Input.GetMouseButton(0))
            {
                if (ifPlayerTurn)
                {
                    UIManager.DisplayText("This is your turn.");
                    playerObject.TakeTurn();
                    ifPlayerTurn = false;
                }
                if (ifEnemyTurn)
                {
                    enemyObject.TakeTurn();
                    ifPlayerTurn = true;
                    ifEnemyTurn = false;
                }
                NextTurn = false;
            }

        }

    }
    public void Flee()
    {
        SceneManager.LoadScene("Town");

        //Clear saved data if any?
    }
    public void PunchPlayer(int atk)
    {
        playerObject.GotPunch(atk);
    }
    public void PunchEnemy(int atk)
    {
        enemyObject.GotPunch(atk);
    }
    public void EnemyTurn()
    {
        ifEnemyTurn = true;
    }

    public void Victory()
    {
        gameOver = true;
        playerObject.GainHealth(10);
        playerObject.GainAttack(5);
        playerObject.GainDefence(2);
        //if (Input.GetMouseButton(0))
        //{
            UIManager.DisplayText("Victory! Player gain 10 health, 5 attack, and 2 defence.");
            //if (Input.GetMouseButton(0))
            //{
                SceneManager.LoadScene("Town");
            //}
        //}

    }
    public void Defeated()
    {
        gameOver = true; 
        //if ( Input.GetMouseButton(0))
        //{
            UIManager.DisplayText("You lost... You will be start over again.");
            //if (Input.GetMouseButton(0))
            //{
               SceneManager.LoadScene("Intro");
            //}
       // }

    }
}
