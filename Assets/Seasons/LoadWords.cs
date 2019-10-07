using Words;
using Keys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;

public class LoadWords : MonoBehaviour
{

    System.Random rz = new System.Random();

    public void LoadingWords()
    {
        //Search after the english file with words
        string filePath = "Assets/Resources/EnglishWords.txt";
        StreamReader r = new StreamReader(filePath);
        int Zeilen = 0;

        
        while (!r.EndOfStream)
        {
            r.ReadLine();
            Zeilen++;
        }
        //Take every word from it and transform it into my Word class
        r = new StreamReader(filePath);
        StartInputs.englishWords = new Word[Zeilen];
        int z = 0;
        while (!r.EndOfStream)
        {
            string row = r.ReadLine();
            Key[] letters = new Key[row.Length];
            int i = 0;
            foreach (char key in row)
            {
                letters[i] = new Key(key.ToString());
                 i++;
            }
            StartInputs.englishWords[z] = new Word(letters);
            Debug.Log(StartInputs.englishWords[z].getName());
                z++;
        }
        r.Close();
        StartInputs.englishkeys = true;
        StartInputs.EngRan = rz.Next(0, StartInputs.englishWords.Length - 1);
        SceneManager.LoadScene("TypingScene", LoadSceneMode.Single);
    }

    public void RandomWords()
    {
        StartInputs.englishkeys = false;
        SceneManager.LoadScene("TypingScene", LoadSceneMode.Single);
    }
    
}
