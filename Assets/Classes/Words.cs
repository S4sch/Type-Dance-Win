using Keys;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Words
{
    //Class Word
    public class Word
    {
        // Word Attributes
        private Key[] myWord; //A Word contains of differnt keys
        private int myPosition = 0;
        private string myName;
        private float myTime;
        private int myPoints;
        private bool myStatus = true; // if the word is still achievable
        private static int ourSolvedKeys = 0;
        private static float ourTimeNeeded = 0;
        private static int OurWordPoints = 0;

        //Make Own Words with Individual Stats
        public Word(Key[] Keys,int Time, int Points)
        {
            myWord = Keys;
            myTime = Time;
            myPoints = Points;
            NameSetting();
        }

        //Automatic Stats
        public Word(Key[] Keys)
        {
            myWord = Keys;
            myTime = 0.6f + 0.3f * Keys.Length;
            myPoints = (200 + (10 * Keys.Length)) * Keys.Length;
            NameSetting();
        }

        //Automatic Word Creator with the Word Length
        public Word(int WordLength)
        {
            System.Random r = new System.Random();
            myWord = new Key[WordLength];
            for (int i = 0; i < WordLength; i++)
            {
                int rKey = r.Next(97, 122);
                Key RandomKey = new Key(rKey);
                myWord[i] = RandomKey;
            }
            myTime = 0.6f + 0.3f * WordLength;
            myPoints = (200 + (10 * WordLength)) * WordLength;
            NameSetting();
        }

        //Random Word Creator with Random Word Length
        public Word(int minLength,int maxLength)
        {
            System.Random r = new System.Random();
            int wordsize = r.Next(minLength, maxLength);
            myWord = new Key[wordsize];
            for (int i = 0; i < wordsize; i++)
            {
                int rKey = r.Next(97, 122);
                Key RandomKey = new Key(rKey);
                myWord[i] = RandomKey;
            }
            myTime = 0.6f + 0.3f * wordsize;
            myPoints = (200 + (10 * wordsize)) * wordsize;
            NameSetting();
        }

        public bool KeyChecking()
        {
            
            if (Input.GetKey(myWord[myPosition].getInput()) && myStatus)
            {
                ourSolvedKeys++;
                myPosition++;
                return true;
            }
            else
            {
                ourSolvedKeys -= myPosition;
                return false;
            }
            
        }

        //Name Method
        public void NameSetting()
        {
            string Name = "";
            for (int i = 0; i < myWord.Length; i++)
            {

                Name += myWord[i].getInput();
               
            }
            if (myPosition > 0)
            {
                Name = "<color=green>" + Name.Substring(0,myPosition) + "</color>" + Name.Substring(myPosition,Name.Length - myPosition);
            }

            myName = Name;          
        }

        

        IEnumerator TimeNeeded()
        {

            yield return new WaitForSeconds(1);
            ourTimeNeeded++;
            
        }
        

        #region Get, Set Methods
        // get- und set-Methoden:

            //Name
        public string getName()
        {
            NameSetting();
            return myName;
        }
        public void setName(string NewName)  {
            myName = NewName;
        }

        //Word
        public Key[] getWord()
        {
            return myWord;
        }
        public void setWord(Key[] Word)
        {
            myWord = Word;
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

        //Points
        public int getPoints()
        {
            return myPoints;
        }
        public void setPoints(int Points)
        {
            myPoints = Points;
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

        //Status 
        public bool getStatus()
        {
            return myStatus;
        }
        public void setStatus(bool newStatus)
        {
            myStatus = newStatus;
        }

        //TotalPoints
        public static int getTotalPoints()
        {
            return OurWordPoints;
        }
        public static void setTotalPoints(int Points)
        {
            OurWordPoints = Points;
        }

        //TotalTime
        public static float getTotalTime()
        {
            return ourTimeNeeded;
        }
        public static void setTotalTime(float time )
        {
            ourTimeNeeded = time;
        }

        //Total Key Solved
        public static float getKeySolved()
        {
            return ourSolvedKeys;
        }
        public static void setKeySolved(int keysolved)
        {
            ourSolvedKeys = keysolved;
        }

        //get Key
        public Key getKeyAt(int Index)
        {
            return myWord[Index];
        }
        #endregion
    }
}
