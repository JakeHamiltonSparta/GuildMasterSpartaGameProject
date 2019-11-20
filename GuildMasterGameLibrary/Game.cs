using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace GuildMasterGameLibrary
{
    public class Game
    {
        public Game()
        {
            
        }
        
    }
    public class Question
    {

        public static Dictionary<int, string> questionsDictionary = new Dictionary<int, string>();
       
        
        public Question()
        {
            // get the questions from our text file
            string[] questions = File.ReadAllLines("QuestionBank.dat");

            questionsDictionary.Clear();

            // put questions into dictionary
            for (int i = 0; i < questions.Length; i++)
            {
                questionsDictionary.Add(i, questions[i]);
            }
        }
        //public Dictionary<int, string> QuestionDict(Dictionary<int, string> questionsDict)
        //{
        //    string[] questions = File.ReadAllLines(@"C:\Users\Jake Hamilton\Engineering45\Week3\day5\GuildMasterGame");
        //    for (int i = 0; i < questions.Length; i++)
        //    {
        //        questionsDict.Add(i, questions[i]);
        //    }
        //    return questionsDict;
        //}

       
    }
       
}
