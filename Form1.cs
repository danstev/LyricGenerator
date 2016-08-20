using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
Dan Steve Ward - 2016
www.danstev.uk
*/

namespace LyricGenerator
{
    public partial class MainForm : Form
    {
        public List<Word> dict;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


        }

        void readFromInput()
        {
            string input = Input.Text;
            string[] parsed = input.Split(' ');
            string previous;
            foreach(string s in parsed)
            {
                if(checkIfInDict(s))
                {
                    addFreqToDict(s);
                    previous = s;
                }


                
                
            }
        }

        

        void readIntoTable()
        {
            string toParse = Input.Text;
            string[] parsed = toParse.Split('/');
            for (int i = 0; i < 2; i++)
            {
                if(i == 0)
                {
                    string[] parsed2 = toParse.Split(',');
                    Word newWord = new Word(parsed2[0], Int32.Parse(parsed2[1]));
                    if(dict.Contains(newWord))
                    {
                        addFreqToDict(parsed2[0]);
                    }
                    else
                    {
                        dict.Add(newWord);
                    }

                }
                else if(i == 1)
                {

                } 
            }
        }

        bool checkIfInDict(string checkString)
        {
            foreach(Word w in dict)
            {
                if(w.word == checkString)
                {
                    return true;
                }
            }
            return false;
        }

        void addFreqToDict(string addFreqTarget)
        {
            List<Word> tempDict = new List<Word>();
            foreach(Word w in dict)
            {
                if (w.word == addFreqTarget)
                {
                    Word tempAddFreq = w;
                    tempAddFreq.freq++;
                    tempDict.Add(tempAddFreq);
                }
                else
                {
                    tempDict.Add(w);
                }
            }
            dict = tempDict;
        }
    }

    public class Word
    {
        public string word;
        public int freq;
        public List<Word> listOfWord;

        public Word(string w, int f)
        {
            word = w;
            freq = f;
        }
    }

}
