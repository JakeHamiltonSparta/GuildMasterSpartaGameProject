using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GuildMasterGameLibrary;
using System.Diagnostics;

namespace GuildMasterGame
{
    /// <summary>
    /// Interaction logic for CoreGameWindow.xaml
    /// </summary>
    public partial class CoreGameWindow : Window
    {
        int playerHealth = 3;
        int score = 0;
        public List<int> questionID = new List<int>();
        public List<int> comparsionList = new List<int>();

        Question quest = new Question();

        public CoreGameWindow()
        {
            InitializeComponent();
            InitialiseCoreGame();
        }

        void InitialiseCoreGame()
        {
            // test print of all questions
            // production code Trace.WriteLine
            // dev code        Debug.WriteLine
            // parse dictionary
            // Trace.WriteLine("\n\nPrinting Question Bank\n");
            //foreach(KeyValuePair<int,string> question in Question.questionsDictionary)
            //{
            //    Console.WriteLine($"{question.Key,-15}{question.Value}");
            //}

            GuildMasterList();

            IDValidation();
        }


        public void GuildMasterList()
        {
            foreach (KeyValuePair<int, string> question in Question.questionsDictionary)
            {

                    questionID.Add(question.Key);

                
                // Console.WriteLine($"{question.Key,-15}{question.Value}");
            }
        }

      
        //Dictionary<int, string> questionsDict = new Dictionary<int, string>();
        public int GetRandomID()
        {
            var random = new Random();
            int randomNum = random.Next(questionID.Count);
            return randomNum;
        }

        public void IDValidation()
        {
            int i = GetRandomID();
            if (comparsionList.Contains(i))
            {
                if (comparsionList.Count == questionID.Count)
                {

                }
                else
                {
                    IDValidation();
                }

            }
            else if(!(comparsionList.Contains(i)))
            {
                ChangeTextBlock(i);
                comparsionList.Add(i);
            }

        }
        private void ChangeTextBlock(int i)
        {
            string displayText = Question.questionsDictionary[i];
            QuestionTextBlock.Text = displayText;
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            switch (GetBtn(sender))
            {
                case "Confirm":
                    CheckScore("Confirm");
                    break;

                case "Deny":
                    CheckScore("Deny");
                    break;
            }
        }

        public string GetBtn(object obj)
        {
            Button btn = (Button)obj;
            return btn.Content.ToString();
        }

        public void CheckScore(string btn)
        {
            double num = CheckListArray();

            if (btn == "Confirm")
            {  
                if ((num%2.0) == 0)
                {
                    score++;
                    ScoreTextBox.IsEnabled = true;
                    ScoreTextBox.Text = score.ToString();
                    ScoreTextBox.IsEnabled = false;
                }
                else
                {
                    playerHealth--;
                }
            }
            else if (btn == "Deny")
            {
                if ((num%2.0) == 0)
                {
                    playerHealth--;
                }
                else
                {
                    score++;
                    ScoreTextBox.IsEnabled = true;
                    ScoreTextBox.Text=score.ToString();
                    ScoreTextBox.IsEnabled = false;
                }
            }
        }
        public double CheckListArray()
        {
            int checkNum = comparsionList.Count() - 1;
            return (double)comparsionList[checkNum];
        }
    }
}