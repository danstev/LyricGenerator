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
        public Word previous;

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
                    string[] parsed2 = parsed[i].Split(',');
                    Word newWord = new Word(parsed2[0], Int32.Parse(parsed2[1]));
                    if(dict.Contains(newWord))
                    {
                        addFreqToDict(parsed2[0]);
                        previous = newWord;
                        return;
                    }
                    else
                    {
                        //dict.Add(newWord);
                    }

                }
                else if(i == 1)
                {
                    string[] parsed2 = parsed[i].Split('.');
                    for(int x = 0; x < parsed2.Length; x++)
                    {
                        string[] parsed3 = parsed2[i].Split(',');

                    }

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

        int getTotalWords(Word w)
        {
            int count = 0;
            foreach(Word word in w.listOfWord)
            {
                count += word.freq;
            }
            return count;
        }

        string getWhichIsNext(Word w)
        {
            string[] nextWord = new string[w.listOfWord.Count];
            int[] nextWordFreq = new int[w.listOfWord.Count];
            int wordCount = 0;
            int count = 0;

            for (int i = 0; i < w.listOfWord.Count; i++)
            {
                nextWord[i] = w.listOfWord[i].word;
                nextWordFreq[i] = w.listOfWord[i].freq;
                wordCount++;
                count += w.listOfWord[i].freq;
            }

            string[] words = new string[count];
            int count2 = 0;

            for(int i = 0; i < wordCount; i++)
            {
                for(int x = 0; x < nextWordFreq[i]; x++)
                {
                    words[count2] = nextWord[i];
                    count2++;
                }
            }
            Random rand = new Random();
            int r = rand.Next(0, count);
            return words[r];
        }

        private void saveChain_Click(object sender, EventArgs e)
        {
            string path = "C:\\User\\Public\\Chains\\chainTest.txt";
            foreach (Word w in dict)
            {
                string save = "";
                save += w.word;
                save += ",";
                save += w.freq;
                save += "/";
                foreach(Word b in w.listOfWord)
                {
                    save += b.word;
                    save += ",";
                    save += b.freq;
                    save += ".";
                }
                System.IO.File.WriteAllText(path, save);
            }
        }

        private void loadChain_Click(object sender, EventArgs e)
        {

        }

        private void generateText_Click(object sender, EventArgs e)
        {

        }

        private void SaveText_Click(object sender, EventArgs e)
        {

        }

        private void ExportStats_Click(object sender, EventArgs e)
        {

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
