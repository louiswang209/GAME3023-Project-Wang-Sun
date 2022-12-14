
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameSystemManager : MonoBehaviour
{
    [SerializeField]
    Button NewGameButton, ContinueButton, CreditsButton, BackButton, ExitButton;

    [SerializeField]
    GameObject CreditsBoxes;

    public Enemy playerData = null;

    private void Start()
    {
        BackButton.gameObject.SetActive(false);
        CreditsBoxes.SetActive(false);
    }

    //For New Game : To add more later
    public void NewGame()
    {
        playerData.Health = 50;
        playerData.Attack = 10;
        playerData.Defence = 2;
        SceneManager.LoadScene("Town");

        //Clear saved data if any?

    }

    //For Continue : add more later
    public void Continue()
    {
        SceneManager.LoadScene("Town");

        //Load saved data
    }

    //Credits
    public void Credits()
    {
        //Make Credits UI visable
        BackButton.gameObject.SetActive(true);
        CreditsBoxes.SetActive(true);

        //Make Other UI invisable
        NewGameButton.gameObject.SetActive(false);
        ContinueButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        CreditsButton.gameObject.SetActive(false);
    }

    public void Back()
    {
        //Make Credit UI invisable
        BackButton.gameObject.SetActive(false);
        CreditsBoxes.SetActive(false);

        //Make Other UI visable again
        NewGameButton.gameObject.SetActive(true);
        ContinueButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(true);
        CreditsButton.gameObject.SetActive(true);
    }

    //For Exit Button
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        //Debug.Log("Ending Game...");
    }
}
