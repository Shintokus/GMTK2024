using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Character> characters;
    public LoadCharacterDisplayText loadCharacterDisplayText;
    public Character currentCharacterJudged;
    public AllUIRefs allUIRefs;
  

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
    }
   
    public void HeavenOrHellChoose()
    {
       FindObjectOfType<Facts_Summary_Text_Sorter>().ShowTrueFacts();
        // show "Next level" button
       allUIRefs.ShowNextLevelButton();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
