using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CrazyTitle : MonoBehaviour
{
    //All possible random colors
    string[] colors = new string[7] { "<color=green>", "<color=#00ff00ff>", "<color=red>", "<color=#FFBF00>", "<color=yellow>", "<color=#00ffffff>", "<color=#ff00ffff>" };
    List<string> allChanges = new List<string>(); 

    System.Random r = new System.Random();

    //title Stuff
    int titleLength = 0;
    string titleText = "";
    TextMeshProUGUI TMP;

    void Start()
    {
        //Set up the fancy Title
        TMP = gameObject.GetComponent<TextMeshProUGUI>();
        TMP.richText = true;
        titleLength = TMP.text.Length;
        titleText = TMP.text;

        //Start the Random Title Color Changer
        StartCoroutine(TitleChanger(0.05f));
    }

    IEnumerator TitleChanger(float time)
    {
        yield return new WaitForSeconds(time);

        //Change random character with random color and delelte the old color
        int randColor = r.Next(0, colors.Length - 1);
        int randTitlePos = r.Next(0, titleLength);
        for (int i = 0; i < allChanges.Count; i++)
        {
            if (allChanges[i].Substring(1) == randTitlePos.ToString())
            {
                allChanges.RemoveAt(i);
                break;
            }
        }
        allChanges.Add(randColor.ToString() + randTitlePos.ToString());
        changeSorter();


        //Add all changes to the text
        TMP.text = titleText;
        foreach (string change in allChanges)
        {
            int changePos = int.Parse(change.Substring(1).ToString());
            int changeColor = int.Parse(change[0].ToString());
            TMP.text = TMP.text.Substring(0, changePos) + colors[changeColor] + TMP.text[changePos] + "</color>" + TMP.text.Substring(changePos + 1);
        }

        //Sort the changes       
        StartCoroutine(TitleChanger(0.05f));
    }

    //Sort the Position of all changes so that its easier to work with them
    void changeSorter()
    {
        List<string> sortedList = new List<string>();

        foreach (string change in allChanges)
        {
            bool AddAtTheEnd = true;

            for (int i = 0; i < sortedList.Count;i++)
            {
                if (int.Parse(change.Substring(1)) > int.Parse(sortedList[i].Substring(1)))
                {
                    sortedList.Insert(i, change);
                    AddAtTheEnd = false;
                    break;
                }
            }
            if (AddAtTheEnd == true)
            {
                sortedList.Add(change);
            }
        }

        allChanges = sortedList;
    }
}
