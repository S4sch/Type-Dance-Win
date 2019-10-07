using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Keys
{
    //Class Key
    public class Key
    {
        // Key Attributes
        private string myName;
        private string myInput; 
        private static int OurAsciiCode = 97; //97 - 122, a - z

        public Key(string input)
        {
            myInput = input;
            myName = "Press the " + input + " Key";
        }

        public Key(string input, string Name)
        {
            myInput = input;
            myName = Name;
        }

        //Automatic Key Creator
        public Key()
        {     
            char Asc = Convert.ToChar(OurAsciiCode);
            myName = "Press the " + Asc + " Key";
            myInput = Asc.ToString();
            OurAsciiCode++;
        }
        //Use Ascii code to set a certain key
        public Key(int AscciCode)
        {
            char Asc = Convert.ToChar(AscciCode);
            myName = "Press the " + Asc + " Key";
            myInput = Asc.ToString();
        }

        // get- und set-Methoden:
        public string getName()
        {
            return myName;
        }
        public void setName(string NewName)
        {
            myName = NewName;
        }
        public string getInput()
        {
            return myInput;
        }
        public void setInput(string input)
        {
            myInput = input;
        }

    }
}
