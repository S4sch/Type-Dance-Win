using Words;
using Keys;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartInputs : MonoBehaviour
{
    //Playersprites
    public List<Sprite> playerSprites = new List<Sprite>();
    SpriteRenderer SR;
    int playerPos = 0;
   
    //Generate Random Keys 
    Key[] AllKeys = new Key[26];
    Word RandomWord = new Word(3,7);

    //English words and keys
    public static Word[] englishWords;
    public static bool englishkeys = false;

    //Different Colors & Stuff
    GUIStyle style = new GUIStyle();

    //Random Stuff
    System.Random r = new System.Random();
    public static int EngRan = 0;

    void Start()
    {
        //Make the standard a - z keys
        for (int i = 0; i < AllKeys.Length; i++)
        {
            AllKeys[i] = new Key();
        }

        //Set up stuff
        StartCoroutine(TimeNeeded());
        GameObject.Find("Press").GetComponent<TextMeshProUGUI>().richText = true;
        style.richText = true;
        SR = gameObject.GetComponent<SpriteRenderer>();

    }
  
    void Update()
    {

        //Set the time label to the amount of time left
        ChangeTimeLabel();

        //Check if the random keys are activated and hitted
        if (Input.anyKeyDown && !englishkeys)
        {
            GameObject.Find("Pos").GetComponent<TextMeshProUGUI>().text = RandomWord.getPosition().ToString();
            //check if the right key is hitted
            if (RandomWord.KeyChecking())
            {
                GameObject.Find("Press").GetComponent<TextMeshProUGUI>().text = RandomWord.getName().ToString();
                UpdatePlayerSprite();
                if (RandomWord.getPosition() == RandomWord.getWord().Length)
                {
                    Word.setTotalPoints(Word.getTotalPoints() + RandomWord.getPoints());
                    ResetRandomWord();
                }
            }
           else
            {
                Word.setTotalPoints(Word.getTotalPoints() - 200);
                ResetRandomWord();
            }
           
        } //Check for the english words
        else if (Input.anyKeyDown && englishkeys)
        {
            GameObject.Find("Pos").GetComponent<TextMeshProUGUI>().text = englishWords[EngRan].getPosition().ToString();
            //When the right key is hitted
            if (englishWords[EngRan].KeyChecking())
            {
                GameObject.Find("Press").GetComponent<TextMeshProUGUI>().text = englishWords[EngRan].getName().ToString();
                UpdatePlayerSprite();
                if (englishWords[EngRan].getPosition() == englishWords[EngRan].getWord().Length)
                {
                    Word.setTotalPoints(Word.getTotalPoints() + englishWords[EngRan].getPoints());
                    ResetEnglishWord();
                }
            }
            else
            {
                Word.setTotalPoints(Word.getTotalPoints() - 200);
                ResetEnglishWord();
            }
        }    
    }

    void UpdatePlayerSprite()
    {
        if (playerPos >= playerSprites.Count - 1)
        {
            playerPos = 0;
        }
        else
        {
            playerPos++;
        }
        SR.sprite = playerSprites[playerPos];
    }

    //Reset the Random Word and start the new Timer for it
    void ResetRandomWord()
    {
        RandomWord = new Word(3, 7);
        StartCoroutine(timeChanger(RandomWord.getTime(), RandomWord));
        ChangeLabels(RandomWord);
    }

    //Make a new random number for the english words and start a new timer for it
    void ResetEnglishWord()
    {
        englishWords[EngRan].setPosition(0);
        englishWords[EngRan].NameSetting();
        EngRan = r.Next(0, englishWords.Length - 1);
        StartCoroutine(timeChanger(englishWords[EngRan].getTime(), englishWords[EngRan]));
        ChangeLabels(englishWords[EngRan]);
    }

    //Check which time should be checked and if the time is over
    public void ChangeTimeLabel()
    {
        if (englishkeys)
        {
            GameObject.Find("Pos").GetComponent<TextMeshProUGUI>().text = englishWords[EngRan].getPosition().ToString();
            GameObject.Find("Time").GetComponent<TextMeshProUGUI>().text = englishWords[EngRan].getTime().ToString();
            if (englishWords[EngRan].getStatus() == false)
            {
                Word.setTotalPoints(Word.getTotalPoints() - 200);
                ResetEnglishWord();
                ChangeLabels(englishWords[EngRan]);
            }
        }
        else
        {
            GameObject.Find("Pos").GetComponent<TextMeshProUGUI>().text = RandomWord.getPosition().ToString();
            GameObject.Find("Time").GetComponent<TextMeshProUGUI>().text = RandomWord.getTime().ToString();
            if (RandomWord.getStatus() == false)
            {
                Word.setTotalPoints(Word.getTotalPoints() - 200);
                ResetRandomWord();
                ChangeLabels(RandomWord);
            }
        }
    }

    //Change the labels to the words stats
    public void ChangeLabels(Word woert)
    {
        GameObject.Find("Pos").GetComponent<TextMeshProUGUI>().text = woert.getPosition().ToString();
        GameObject.Find("Press").GetComponent<TextMeshProUGUI>().text = woert.getName();
        GameObject.Find("Points").GetComponent<TextMeshProUGUI>().text = Word.getTotalPoints().ToString();
    }

    //After a time set the Stats of the word offline 
    IEnumerator timeChanger(float time,Word woert)
    {
        yield return new WaitForSeconds(time);
        woert.setStatus(false);
    }

    IEnumerator TimeNeeded()
    {
        yield return new WaitForSeconds(1);
        Word.setTotalTime(Word.getTotalTime() + 1);
        GameObject.Find("Keys").GetComponent<TextMeshProUGUI>().text = (Math.Round(Convert.ToSingle(Word.getKeySolved()) / Word.getTotalTime(),2)).ToString();
        GameObject.Find("KeysO").GetComponent<TextMeshProUGUI>().text = Word.getKeySolved().ToString();
        GameObject.Find("TotalTime").GetComponent<TextMeshProUGUI>().text = Word.getTotalTime().ToString();
        StartCoroutine(TimeNeeded());
    }

    
    //Shuffle a word array
    void Shuffle(List<Word> woerter)
    {
        System.Random r = new System.Random();

        for (int t = 0; t < woerter.Count; t++)
        {
            Word tmp = woerter[t];
            int z = r.Next(t, woerter.Count);
            woerter[t] = woerter[z];
            woerter[z] = tmp;
        }
    }
    
}
