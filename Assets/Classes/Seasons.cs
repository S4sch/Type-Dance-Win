using Keys;
using Words;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Seasons
{
    //Class Season
    public class Season
    {
        // Season Attributes
        private List<Word> myWords = new List<Word>(); //A Season contains many words
        private int myPosition = 0;
        private int myCombo = 0;
        private string myName;
        private float myTime;
        private float myRestTime;
        private int myPoints = 0;
        private int myHighscore = 0;
        private int myHighestPoints = 0; //Highest possible Score
        private bool myStatus = false; // if the Season is running


        //Make Own Seaons with indivdual stats
        public Season(List<Word> Words, int Time, string Name)
        {
            myWords = Words;
            myTime = Time;
            myName = Name;
            foreach (Word word in Words)
            {
                myHighestPoints += word.getPoints();
            }
        }

        //Automatic Stats
        public Season(List<Word> Words,string Name)
        {
            myWords = Words;
            StatsDefining();
            myName = Name;
        }

        //Automatic Season Creator with everything
        public Season(int SeasonsLength, int WordMinLength, int WordMaxLength,string Name)
        {
            System.Random r = new System.Random();
            for (int i = 0; i < SeasonsLength; i++)
            {
                Word word = new Word(WordMinLength, WordMaxLength);
                myWords.Add(word);
            }
            StatsDefining();
            myName = Name;
        }

        

        public bool WordChecking()
        {
            if (Input.GetKey(myWords[myPosition].getKeyAt(myWords[myPosition].getPosition()).getInput()) && myStatus)
            {
                myWords[myPosition].setPosition(myWords[myPosition].getPosition() + 1);
                if (myWords[myPosition].getWord().Length == myWords[myPosition].getPosition())
                {
                    myPosition++;
                }

                return true;
            }
            else
            { 
                return false;
            }

        }


        void StatsDefining()
        {
            int i = 0;
            foreach (Word word in myWords)
            {
                myTime += word.getTime();
                myHighestPoints += word.getPoints() + (i * 10);
                i++;
            }
            myRestTime = myTime;
        }

        public void ResetTime()
        {
            myRestTime = myTime;
        }

        //Shuffle a word List
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

        #region Get, Set Methods
        // get- und set-Methoden:

        //Name
        public string getName()
        {
            return myName;
        }
        public void setName(string NewName)
        {
            myName = NewName;
        }

        //Word
        public List<Word> getWords()
        {
            return myWords;
        }
        public void setWords(List<Word> Word)
        {
            myWords = Word;
        }

        //Position
        public int getPosition()
        {
            return myPosition;
        }
        public void setPosition(int Position)
        {
            myPosition = Position;
        }


        //Combo
        public int getCombo()
        {
            return myCombo;
        }
        public void setCombo(int Combo)
        {
            myCombo = Combo;
        }

        //Highest possible Score
        public int getHighestScore()
        {
            return myHighestPoints;
        }


        //Highscore
        public int getHighscore()
        {
            return myHighscore;
        }
        public void setHighScore(int HighScore)
        {
            myHighscore = HighScore;
        }

        //Time
        public float getTime()
        {
            return myTime;
        }
        public void setTime(int Time)
        {
            myTime = Time;
        }


        //RestTime
        public float getRestTime()
        {
            return myRestTime;
        }
        public void setRestTime(int Time)
        {
            myRestTime = Time;
        }

        //Pointas
        public float getPoints()
        {
            return myPoints;
        }
        public void setPoints(int Points)
        {
            myPoints = Points;
        }

        //Status 
        public bool getStatus()
        {
            return myStatus;
        }
        public void setStatus(bool newStatus)
        {
            myStatus = newStatus;
        }      

        //get Word
        public Word getWordAt(int Index)
        {
            return myWords[Index];
        }
        #endregion
    }
}
