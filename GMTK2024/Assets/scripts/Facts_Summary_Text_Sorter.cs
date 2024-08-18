using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Facts_Summary_Text_Sorter : MonoBehaviour
{
    public List<TextMeshProUGUI> goodFactsTMP;
    public List<TextMeshProUGUI> badFactsTMP;
    public List<Fact> currentFactsInGoodSlots;
    public List<Fact> currentFactsInBadSlots;
    public List<Fact> currentFactsAlreadyGivenToThePlayer;
    public LoadCharacterDisplayText loadCharacterDisplayText;
    public SpawnTestWeights scalesSpawnerFactsSummary;

    void Start()
    {
        loadCharacterDisplayText = GetComponent<LoadCharacterDisplayText>();
    }

    public void SortFrontFact(Fact fact)
    {
        if (fact.frontWeight >= 0)
        {
          int slotNum =  WhichTextSlotIsVacant(isGoodSlot: true );
            currentFactsInGoodSlots.Add(fact);
            goodFactsTMP[slotNum].text = fact.frontFactForSummaryScales;
            goodFactsTMP[slotNum].gameObject.SetActive(true);
            scalesSpawnerFactsSummary.SpawnObjRight(Mathf.Abs(fact.frontWeight));
        }
        else
        {
            int slotNum = WhichTextSlotIsVacant(isGoodSlot: false);
            currentFactsInBadSlots.Add(fact);
            badFactsTMP[slotNum].text = fact.frontFactForSummaryScales;
            badFactsTMP[slotNum].gameObject.SetActive(true);
            scalesSpawnerFactsSummary.SpawnObjLeft(Mathf.Abs(fact.frontWeight));
        }

        currentFactsAlreadyGivenToThePlayer.Add(fact);
        // spawn a cube to put on the scales
    }

 

    public bool hasLiedToThePlayer()
    {
       
        foreach(Fact factGiven in currentFactsAlreadyGivenToThePlayer)
        {
            if (factGiven.isLie)
                return true;
            else
                return false;

        }
        return false;
    }




    public void ShowTrueFacts()
    {
        Character character = loadCharacterDisplayText.currentCharacter;

      
        for (int i = 0; i < character.facts.Count; i++)
        {
            if (character.facts[i].actualWeight >= 0)
            {
                goodFactsTMP[WhichTextSlotIsVacant(true)].text = character.facts[i].actualFactForSummaryScales;
                goodFactsTMP[WhichTextSlotIsVacant(true)].gameObject.SetActive(true);
            }

        }

        for (int i = 0; i < character.facts.Count; i++)
        {
            if (character.facts[i].actualWeight < 0)
            {
                badFactsTMP[WhichTextSlotIsVacant(true)].text = character.facts[i].actualFactForSummaryScales;
                badFactsTMP[WhichTextSlotIsVacant(true)].gameObject.SetActive(true);
            }

        }

    }




    // returns the index of the first empty slot in the good or bad list
    int WhichTextSlotIsVacant(bool isGoodSlot)
    {

        int slot = 0;

        if (isGoodSlot)
        {
            for (int i = 0; i < goodFactsTMP.Count; i++)
            {
                if (goodFactsTMP[i].gameObject.activeSelf == false)
                {
                    return i;
                }
            }
        }
        else
        {
            for (int i = 0; i < badFactsTMP.Count; i++)
            {
                if (badFactsTMP[i].gameObject.activeSelf == false)
                {
                    return i;
                }
            }
        }
        return slot;

    }
}
