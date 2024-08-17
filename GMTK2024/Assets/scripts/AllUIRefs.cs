using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUIRefs : MonoBehaviour
{
    public GameObject FactsSummaryScalesObject;
    public GameObject LiesCheckScalesObject;
    public GameObject PlayerChatBoxCanvas;
    public GameObject UIJudgeToHeaven;
    public GameObject UIJudgeToHell;
    public GameObject nextLevelCanvas;
    public GameObject judgeButtonPanel;

    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void HideUIJudge()
    {
        
        LiesCheckScalesObject.SetActive(false);
        PlayerChatBoxCanvas.SetActive(false);
        judgeButtonPanel.SetActive(false);
        UIJudgeToHeaven.SetActive(true);
        UIJudgeToHell.SetActive(true);
      
    }

    public void ShowNextLevelButton()
    {
        UIJudgeToHeaven.SetActive(false);
        UIJudgeToHell.SetActive(false);
        nextLevelCanvas.SetActive(true);
    }

    public void Judge()
    {
        gameManager.Judge();
    }

    public void HeavenOrHellChoose()
    {
        gameManager.HeavenOrHellChoose();
    }

    public void NextLevel()
    {
        gameManager.RestartScene();
    }
}
