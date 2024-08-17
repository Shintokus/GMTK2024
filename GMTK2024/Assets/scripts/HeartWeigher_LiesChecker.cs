using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartWeigher_LiesChecker : MonoBehaviour
{
    Facts_Summary_Text_Sorter facts_Summary_Text_Sorter;
    public GameObject checkLiesButton;
    public SpawnTestWeights heartWeigherScalesSpawner;
    // Start is called before the first frame update
    void Start()
    {
        facts_Summary_Text_Sorter = GetComponent<Facts_Summary_Text_Sorter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckLies()
    {
        if (facts_Summary_Text_Sorter.hasLiedToThePlayer())
        {
            Debug.Log("The player has been lied to");
          checkLiesButton.GetComponent<TextMeshProUGUI>().text = "They have lied to you";
            checkLiesButton.GetComponent<TextMeshProUGUI>().color = Color.red;
            //heart is heavier than feather
            heartWeigherScalesSpawner.SpawnHeartLeft(true);
        }
        else
        {
            Debug.Log("The player has not been lied to");
            checkLiesButton.GetComponent<TextMeshProUGUI>().text = "They have been honest";
            checkLiesButton.GetComponent<TextMeshProUGUI>().color = Color.green;
            //heart is the same as feather
            heartWeigherScalesSpawner.SpawnHeartLeft(false);
        }
        checkLiesButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
    }
}
