using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                        dict.Where(Word => Word.word == parsed2[0]).ToList().ForEach(Word => Word.freq++);
                    }
                    else
                    {
                        dict.Add(newWord);
                    }

                }
                else if(i == 1)
                {

                }

                //freqTable.addToTable(s);   
            }

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
