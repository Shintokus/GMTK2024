using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class HeartWeigher_LiesChecker : MonoBehaviour
{
    Facts_Summary_Text_Sorter facts_Summary_Text_Sorter;
    public GameObject checkLiesButton;
    public SpawnTestWeights heartWeigherScalesSpawner;
    [SerializeField] bool previousHeartDespawned = true;
    [SerializeField]float howLongWaitForNewHeartSpawn = 4;

    void Start()
    {
        facts_Summary_Text_Sorter = GetComponent<Facts_Summary_Text_Sorter>();
    }

   

    //checks if the player has been lied to
    public void CheckLies()
    {
        if (facts_Summary_Text_Sorter.HasLiedToThePlayer())
        {
            Debug.Log("The player has been lied to");
          checkLiesButton.GetComponent<TextMeshProUGUI>().text = "They have lied to you";
            checkLiesButton.GetComponent<TextMeshProUGUI>().color = Color.red;
            //heart is heavier than feather
            heartWeigherScalesSpawner.SpawnHeartLeft(isHeavy: true);
        }
        else
        {
            Debug.Log("The player has not been lied to");
            checkLiesButton.GetComponent<TextMeshProUGUI>().text = "They have been honest";
            checkLiesButton.GetComponent<TextMeshProUGUI>().color = Color.green;
            //heart is the same as feather
            heartWeigherScalesSpawner.SpawnHeartLeft(isHeavy: false);
        }
        checkLiesButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
    }

    //finds the fact by tmp in that pair and checks it
    public void CheckThisFact(TextMeshProUGUI tmp) 
    {
     
        CheckThisFact(facts_Summary_Text_Sorter.currentFactAndTmpPairs.FirstOrDefault(x => x.Value == tmp).Key);
    }
     void CheckThisFact(Fact fact)
    {
        if (previousHeartDespawned)
        { 
         if (fact.isLie)
         {
            //find this fact in the original list, make it different color, strike it through
            //remove its weight from the scales
            facts_Summary_Text_Sorter.currentFactAndTmpPairs[fact].GetComponent<Button>().interactable = false;
            facts_Summary_Text_Sorter.currentFactAndTmpPairs[fact].color = Color.black;
            facts_Summary_Text_Sorter.currentFactAndTmpPairs[fact].fontStyle = FontStyles.Strikethrough;
            facts_Summary_Text_Sorter.factWeightObjectPairs[fact].SetActive(false);

            //remove associated valuepairs
            facts_Summary_Text_Sorter.currentFactAndTmpPairs.Remove(fact);
            facts_Summary_Text_Sorter.factWeightObjectPairs.Remove(fact);
            heartWeigherScalesSpawner.SpawnHeartLeft(isHeavy: true);
            // spawn the true fact, spawn its weight
            facts_Summary_Text_Sorter.SortFrontFact(fact, isFrontFact: false);
         }
         else
         {//find this fact in the original list, make it different color
            facts_Summary_Text_Sorter.currentFactAndTmpPairs[fact].color = Color.green;
            //increase its size 1.2x
            facts_Summary_Text_Sorter.currentFactAndTmpPairs[fact].fontSize *= 1.2f;
            heartWeigherScalesSpawner.SpawnHeartLeft(isHeavy: false);

         }
            StartCoroutine(CanSpawnNextHeartCounter());
        }
   }

    IEnumerator CanSpawnNextHeartCounter()
    {
        previousHeartDespawned = false;
        yield return new WaitForSeconds(howLongWaitForNewHeartSpawn);
        previousHeartDespawned = true;
    }

}
