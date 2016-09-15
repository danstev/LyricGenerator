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

/*
Plan:

1. Adding words to data structure
    Fix input algorithm
    Add previous word to implementation

2. Context checker
    Get word structure
    Check it makes a sentence

3. Custom options for generation
    Amount of lines
    Length of lines

4. Weight out-of-context words
    Get nouns
    Check against verbs


*/
namespace LyricGenerator
{
    public partial class MainForm : Form
    {
        private List<Word> dict = new List<Word> { };
        private Word previous;
        public int amountOfWords = 100;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Input.Text = "Please load a chain before you try to generate content.";
        }

        void addToChain()
        {
            string toParse = Input.Text;
            string[] parsed = toParse.Split(' ');
            foreach(string s in parsed)
            {

            } 
        }

        void addTiDict(string s)
        {
            if(checkIfInDict(s))
            {
                addFreqToDict(s);
            }
            else
            {
                Word check = new Word(s, 1);

            }
        }

        void readIntoTable()
        {
            //Get string
            string toParse = Input.Text;
            //Parse the word and freq, from the next words
            string[] parsed = toParse.Split('/');
            for (int i = 0; i < 2; i++)
            {
                //Word and freq
                if(i == 0)
                {
                    //split word and freq
                    string[] parsed2 = parsed[i].Split(',');
                    //Put into new word
                    Word newWord = new Word(parsed2[0], Int32.Parse(parsed2[1]));
                    //If it contains word
                    if(dict.Contains(newWord))
                    {
                        //Add freq ++
                        addFreqToDict(parsed2[0]);
                        //save previous
                        previous = newWord;
                        //exit loop
                        return;
                    }
                    else
                    {
                        dict.Add(newWord);
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
            //Init words with exact count
            string[] nextWord = new string[w.listOfWord.Count];
            //Same with amount of times the word came next
            int[] nextWordFreq = new int[w.listOfWord.Count];
            //Count for use in loop
            int wordCount = 0;
            //Same
            int count = 0;

            //Populate the arrays
            for (int i = 0; i < w.listOfWord.Count; i++)
            {
                //Populate with word
                nextWord[i] = w.listOfWord[i].word;
                //Populate with frequency used
                nextWordFreq[i] = w.listOfWord[i].freq;
                //add word count
                wordCount++;
                //Add freq
                count += w.listOfWord[i].freq;
            }

            //New array with sum of all words freq size
            string[] words = new string[count];
            //Another count for use in loop
            int count2 = 0;

            //for each word
            for(int i = 0; i < wordCount; i++)
            {
                //for each freqenecy for word used
                for(int x = 0; x < nextWordFreq[i]; x++)
                {
                    //populate words
                    words[count2] = nextWord[i];
                    count2++;
                }
            }
            //New random so i can generate numbers
            Random rand = new Random();
            //random number from 0 to count, randomly
            //But obviously more used words get more chance to be used
            int r = rand.Next(0, count);
            //Return the random word for use.
            return words[r];
        }

        private void saveChainAction()
        {
            string path = "C:\\User\\Public\\Chains\\chainTest.txt";
            foreach (Word w in dict)
            {
                string save = "";
                save += w.word;
                save += ",";
                save += w.freq;
                save += "/";
                foreach (Word b in w.listOfWord)
                {
                    save += b.word;
                    save += ",";
                    save += b.freq;
                    save += ".";
                }
                System.IO.File.WriteAllText(path, save);
            }
        }

        private bool checkIfDictIsEmpty()
        {
            if( dict.Count <= 0){return false;}
            else{return false;}
        }

        private void saveChain_Click(object sender, EventArgs e)
        {
           if(checkIfDictIsEmpty())
            {
                saveChainAction();
            }
           else
            {
                Output.Text = "The chain is empty, add some information in first.";
            }
        }

        private void loadChain_Click(object sender, EventArgs e)
        {

        }

        private void generateText_Click(object sender, EventArgs e)
        {
            //string here
            string toUse = Output.Text;
            Word currentWord;
            if( checkIfInDict( Output.Text ) )
            {
                for(int i = 0; i < amountOfWords; i++)
                {
                    //Word for current word
                    currentWord = getWord(toUse);
                    //Use word to get next word
                    toUse = getWhichIsNext(currentWord);
                    Output.Text += " ";
                    Output.Text += toUse;

                    //Repeat
                }
            }
            else
            {
                Output.Text = "That word is not in the dictionary. Please load a chain which has that word, or change the word.";
            }

        }

        private void SaveText_Click(object sender, EventArgs e)
        {
            if(Output.Text == null)
            {
                Output.Text = " ";
            }
            string path = getPath();
            System.IO.File.WriteAllText(path, Output.Text);
        }

        private void ExportStats_Click(object sender, EventArgs e)
        {

        }

        private string getPath()
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                Console.Write(openFileDialog1.FileName);
                return openFileDialog1.FileName;
            } 
            return "Error";
        }

        private Word getWord(string w)
        {
            foreach (Word b in dict)
            {
                if (b.word == w) return b;
                else return null;
            }
            Output.Text += "/n The previous word was not found in the dictionary.";
            return null;
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

        int getTotalFreq()
        {
            int x = 0;
            foreach(Word w in listOfWord)
            {
                x = w.freq;
            }
            return x;
        }

        void addToListNext(Word w)
        {
            if( checkWord(w.word) ) //Do this in this function, so its not done twice
            {
                foreach (Word words in listOfWord)
                {
                    if( words.word == w.word)
                    {
                        words.freq++;
                        return;
                    }
                }
            }
            else
            {
                Word add = new Word(w.word, 1);
                listOfWord.Add(add);
            }
        }

        bool checkWord(string word) //Maybe unneeded
        {
            foreach(Word w in listOfWord)
            {
                if(w.word == word)
                {
                    return true;
                }
            }
            return false;
        }

    }

}
