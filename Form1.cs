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

        public FreqTable freqTable;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


        }

        

        void readIntoTable()
        {
            char[] delim = { ' ', '.', ',', ':' };

            string toParse = Input.Text;
            string[] parsed = toParse.Split(delim);

            foreach(string s in parsed)
            {
                freqTable.addToTable(s);   
            }

        }
    }

    public class FreqTable
    {
        List<Word> list = new List<Word>();

        FreqTable()
        {}

        public void addToTable(string s)
        {
            list.Add(s);
        }
    }

    public class Word
    {
        public string word;
        public int freq;


    }
}
