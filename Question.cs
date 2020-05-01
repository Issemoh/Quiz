using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Question
    {
        public Question(string questionText, string correctAnswer, List<string> wrongAnswers, int points = 1)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
            Points = points;
        }

        // Auto Properties
        public string UserAnswer { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> WrongAnswers { get; set;}
        public int Points { get; set; }
        public bool Scored { get; set; } = false; // An initial value

        public List<string> AllAnswers
        {
            get
            {
                List<string> allAnswers = new List<string>();
                allAnswers.Add(CorrectAnswer);
                allAnswers.AddRange(WrongAnswers);


                // Create a random number generator
                Random random = new Random();

                // Create anewlist for the  shuffled answer
                List<String> shuffledAnswers = new List<String>();

                // loop until allanswer have been added to the shuffled list
                while (allAnswers.Count > 0)
                {
                    // Pick a random answer from all answers
                    int index = random.Next(allAnswers.Count);
                    // Fetch
                    string answer = allAnswers[index];
                    allAnswers.RemoveAt(index);

                    // pick arandom location to insert this answer into shuffled answers
                    int insertIndex = random.Next(shuffledAnswers.Count);
                    // and insert the answer 
                    shuffledAnswers.Insert(insertIndex, answer);
                }

                return shuffledAnswers;
            }
        }

        public bool IsCorrect 
        {
            get
            {
                return UserAnswer == CorrectAnswer;
            }
          
        }
    }
}
