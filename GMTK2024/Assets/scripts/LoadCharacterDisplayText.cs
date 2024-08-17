using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LoadCharacterDisplayText : MonoBehaviour
{
    public List<TextMeshProUGUI> chat;
    public Character currentCharacter;
    [SerializeField] Facts_Summary_Text_Sorter factSorter;
    [SerializeField] SpriteRenderer characterSR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void LoadCharacterText()
    {
        chat[0].text = currentCharacter.facts[0].frontFact; // first pos in the list is the front fact, there's no question
        SetAnswerTextRedOrGreen(0);

        for (int i = 1; i < chat.Count; i++)
        {
            chat[i].text = currentCharacter.facts[i].question;
        }
    }

    public void LoadCharacterText(Character character)
    {
        currentCharacter = character;
        LoadCharacterText();
        factSorter.SortFrontFact(currentCharacter.facts[0]);
        characterSR.sprite = currentCharacter.characterSprite;
    }

    public void PressQuestion(int index)
    {
        //!!connect it to turn based system


        //shows the answer to your question
        chat[0].text = currentCharacter.facts[index].frontFact;


        //greens or reds it depending on the weight
        SetAnswerTextRedOrGreen(index);


        //puts this fact near the summarizing scales (green or red)
        factSorter.SortFrontFact(currentCharacter.facts[index]);



        //disables the pressed button and greys out the text              
        chat[index].GetComponent<Button>().interactable = false;
        chat[index].color = Color.gray;



    }


    void SetAnswerTextRedOrGreen(int factIndex)
    {
        if (currentCharacter.facts[factIndex].frontWeight >= 0)
        {
            chat[0].color = Color.green;
        }
        else
        {
            chat[0].color = Color.red;
        }
    }
}
