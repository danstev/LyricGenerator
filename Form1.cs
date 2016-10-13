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
            string[] parsed = toParse.Split(' ', ',', '.', '!', '?');
            string prevString = "";
            foreach(string s in parsed)
            {
                addToDict(s);
                if (prevString != "")
                {
                    Word current = getWord(s);
                    current.addToListNext(prevString);
                }
                prevString = s;
            } 
        }

        void addToDict(string s)
        {
            if(checkIfInDict(s))
            {
                addFreqToDict(s);
            }
            else
            {
                Word check = new Word(s, 1);
                dict.Add(check);
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
                        string[] parsed3 = parsed2[x].Split(',');
                        Word w = new Word(parsed3[0], Int32.Parse(parsed3[1]));
                        dict.Add(w);
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

        private void saveChainAction()
        {
            string path = getPath();
            foreach (Word w in dict)
            {
                string save = "";
                save = w.word + "," + w.freq + "/";
                foreach (Word b in w.listOfWord)
                {
                    save += b.word + "," + b.freq + ".";
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
            string toParse = Input.Text;
            string[] parsed = toParse.Split('/');
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    string[] parsed2 = parsed[i].Split(',');
                    Word newWord = new Word(parsed2[0], Int32.Parse(parsed2[1]));
                    if (dict.Contains(newWord))
                    {
                        addFreqToDict(parsed2[0]);
                        previous = newWord;
                        return;
                    }
                    else
                    {
                        dict.Add(newWord);
                    }
                }
                else if (i == 1)
                {
                    string[] parsed2 = parsed[i].Split('.');
                    for (int x = 0; x < parsed2.Length; x++)
                    {
                        string[] parsed3 = parsed2[i].Split(',');
                    }
                }
            }
        }

        private void generateText_Click(object sender, EventArgs e)
        {
            //string here
            string toUse = Output.Text; //Should be changed to "Enter a word to start with: "
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
                }
            }
            else
            {
                //Perhaps pop up a text bos here with this instead.
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
            //Words
            int count = 0;
            //Word input
            int totalFreq = 0;
            //Most used word
            string MostUsed = "";
            //For comparison
            Word prev;

            foreach(Word w in dict)
            { 
                count++;
                totalFreq += w.freq;
                prev = w;
                if (w.freq > prev.freq)
                    MostUsed = w.word;
            }

            chainStats.Text = "Word count: " + count;
            chainStats.Text += "\nTotal words used: " + totalFreq;
            chainStats.Text += "\nMost used word: " + MostUsed;
        }

        private string getPath()
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                //Console.Write(openFileDialog1.FileName); Unneeded for now
                return openFileDialog1.FileName;
            } 
            return "Error";
        }

        private bool checkNonsense()
        {
            return true;
        }

        private Word getWord(string w)
        {
            foreach (Word b in dict)
            {
                if (b.word == w) return b;
            }
            Output.Text += "\nThe previous word was not found in the dictionary.";
            return null;
        }

        private void genChain_Click(object sender, EventArgs e)
        {
            addToChain();
        }

        private void displayDict()
        {
            foreach(Word w in dict)
            {
                Input.Text += "\n";
                Input.Text += w.word + ":" + w.freq;
                foreach(Word t in w.listOfWord)
                {
                    Input.Text += "\t" + t.word + ":" + t.freq;
                }
            }
        }

        private void displayChain_Click(object sender, EventArgs e)
        {
            displayDict();
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
                x += w.freq;
            }
            return x;
        }

        public void addToListNext(string s)
        {
            if( checkWord(s) ) //Do this in this function, so its not done twice
            {
                foreach (Word words in listOfWord)
                {
                    if( words.word == s)
                    {
                        words.freq++;
                        return;
                    }
                }
            }
            else
            {
                Word add = new Word(s, 1);
                listOfWord.Add(add);
            }
        }

        bool checkWord(string word) 
        {
            if ( listOfWord.Count != 0 )
            {
                foreach (Word w in listOfWord)
                {
                    if (w.word == word)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }

}
