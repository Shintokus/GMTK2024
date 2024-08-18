using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public List<Character> characters;
    public LoadCharacterDisplayText loadCharacterDisplayText;
    public Character currentCharacterJudged;
    public AllUIRefs allUIRefs;

    public int turns;
    public int incorrectChoices;
  

    public static GameManager instance;
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (turns <= 0 || incorrectChoices < -3)
        {
            GameOver();
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    //onloadscene
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        loadCharacterDisplayText = FindObjectOfType<LoadCharacterDisplayText>();
        allUIRefs = FindObjectOfType<AllUIRefs>();

        currentCharacterJudged = characters[Random.Range(0, characters.Count)];
        loadCharacterDisplayText.LoadCharacterText(currentCharacterJudged);
    }

    public void Judge()
    { 
        allUIRefs.HideUIJudge();
        UIManager.instance.inVerdictState = true;
    }

    private void GameOver()
    {
        // TODO: IMPLEMENT ACTUAL GAME OVER LOGIC
        Debug.Log("Game Over");
    }
   
    public void HeavenOrHellChoose(bool heaven)
    {
        if ((heaven && currentCharacterJudged.shouldGoToHeaven) || !heaven && !currentCharacterJudged.shouldGoToHeaven)
        {
            // NO POINTS ARE LOST
        }
        else
        {
            // LOSE POINTS
            incorrectChoices += 1;
            UIManager.instance.UpdateVerdictsText();
        }
       FindObjectOfType<Facts_Summary_Text_Sorter>().ShowTrueFacts();
       allUIRefs.ShowNextLevelButton();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
