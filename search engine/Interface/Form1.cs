using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace Interface
{
    public partial class Form1 : Form
    {
        AutoCompleteStringCollection autocompleteSource = new AutoCompleteStringCollection();
        Dictionary<string, string> pair;
        int diffCount = 0;


        /// <summary>
        /// This contains the Graphical User Interface for the search engine
        /// </summary>
        public Form1()
        {
            MessageBox.Show("Building Inverted Index...");
            Ranker.getInvertedIndex(@"C:\Games\Test");
            MessageBox.Show("Complete!");
            foreach (var term in FileIndexer.getCommonIndex())
            {
                autocompleteSource.Add(term);
            }



            InitializeComponent();

        }


        private void searchBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            resultBox.Items.Clear();
            pair = new Dictionary<string, string>();
            if (suggestTxtBox.Text == "")
            {
                suggestTxtBox.Text = "Type here...";
                suggestTxtBox.ForeColor = Color.DimGray;
            }
            else
            {
                pair.Clear();

                resultLbl.Visible = true;
                resultBox.Visible = true;
                resultLbl.SendToBack();
                var queryTokens = QueryParser.parseQuery(suggestTxtBox.Text);
                List<FileInfo> list = Ranker.Rank(queryTokens);
                stopWatch.Stop();
                label2.Visible = true;
                label2.Text = stopWatch.ElapsedMilliseconds.ToString() + " milliseconds";
                foreach (FileInfo x in list)
                {
                    pair.Add(x.FullName, x.Name);
                }
                Debug.WriteLine(pair.Count);
                List<string> keyList = pair.Keys.ToList();
                List<string> valueList = pair.Values.ToList();

                resultBox.Items.AddRange(valueList.ToArray());

            }

        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void suggestTxtBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void suggestTxtBox_Click(object sender, EventArgs e)
        {
            if (suggestTxtBox.Text == "Type here...")
            {
                suggestTxtBox.Text = "";
                suggestTxtBox.ForeColor = Color.Black;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            suggestTxtBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            suggestTxtBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            suggestTxtBox.AutoCompleteCustomSource = autocompleteSource;

        }

        private void resultBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultBox.SelectedIndex == 0 && diffCount == 0)
            {
                diffCount++;
            }
            else
            {

                var indexAndItem = new Dictionary<int, string>();
                var indexAndPath = new Dictionary<int, string>();
                var count = 0;
                foreach (string y in pair.Keys)
                {
                    indexAndPath.Add(count, y);
                    count++;
                }
                var path = indexAndPath[resultBox.SelectedIndex];
                Process.Start(path);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void resultLbl_Click(object sender, EventArgs e)
        {

        }
    }
}

