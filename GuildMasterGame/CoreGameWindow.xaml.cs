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
        int counter = 0;
        public List<int> questionID = new List<int>();
     //   public List<int> comparsionList = new List<int>();
        public List<int> questionsList = new List<int>();
        

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

            GenerateQuestionList();
            ShowQuestion();
        }


        public void GuildMasterList()
        {
            foreach (KeyValuePair<int, string> question in Question.questionsDictionary)
            {

                    questionID.Add(question.Key);

                // Console.WriteLine($"{question.Key,-15}{question.Value}");
            }
        }

        public void ShowQuestion()
        {
            int firstQuestion = questionsList[counter];
            ChangeTextBlock(counter);
        }
      
        //Dictionary<int, string> questionsDict = new Dictionary<int, string>();
        public int GetRandomID()
        {
            var random = new Random();
            int randomNum = random.Next(questionID.Count);
            return randomNum;
        }

        public void WinCheck()
        {
            //int i = GetRandomID();
            //if (comparsionList.Contains(i))
            //{
                if (counter == questionsList.Count-1)
                {
                    MessageBox.Show("Congratulations you survived! \n Your score is " + score.ToString());
                }
            //else
            //{
            //    IDValidation();
            //}

            //}
            //else if(!(comparsionList.Contains(i)))
            //{
            //    ChangeTextBlock(i);
            //    comparsionList.Add(i);
            //}
            ShowQuestion();
        }

        public void GenerateQuestionList()
        {
            while (questionsList.Count != questionID.Count)
            {
                int i = GetRandomID();

                if (!(questionsList.Contains(i)))
                {
                    questionsList.Add(i);
                }
            }
            
        }
        private void ChangeTextBlock(int i)
        {
            string displayText = Question.questionsDictionary[questionsList[i]];
            QuestionTextBlock.Text = displayText;
            
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            switch (GetBtn(sender))
            {
                case "Confirm":
                    CheckScore("Confirm");
                    counter++;
                    break;

                case "Deny":
                    CheckScore("Deny");
                    counter++;
                    break;
            }
            WinCheck();
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
                if ((num%2.0)== 0)
                {
                    score++;
                    ScoreTextBox.IsEnabled = true;
                    ScoreTextBox.Text = score.ToString();
                    ScoreTextBox.IsEnabled = false;
                }
                else
                {
                    playerHealth--;

                    if (playerHealth == 0)
                    {
                        MessageBox.Show("YOU DIED!");
                        MainWindow mw = new MainWindow();
                        this.Close();
                        mw.Show();
                    }
                }
            }
           
            else if (btn == "Deny")
            {
                if ((num%2.0) == 0)
                {
                    playerHealth--;

                    if (playerHealth == 0)
                    {
                        MessageBox.Show("YOU DIED!");
                        MainWindow mw = new MainWindow();
                        this.Close();
                        mw.Show();
                    }
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
            return (double)questionID[questionsList[counter]];
        }

        
    }

}