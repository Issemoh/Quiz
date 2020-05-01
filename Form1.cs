using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {
        // Store all of the RadioButton in a list,
        // to make it easier to figure out which one was checked, or to unchecked all
        private List<RadioButton> QuizRadioButtons;

        // All of the quiz question 
        private List<Question> QuizQuestions;

        //Keeping track of what question 
        private int CurrentQuestionNumber;

        private int score = 0;



        public Form1()
        {
            InitializeComponent();
            // add the four radio button to the list 
            QuizRadioButtons = new List<RadioButton> { radioButton1, radioButton2, radioButton3, radioButton4 };
        

            QuizQuestionSet = new QuestionBank();

            // Create new Question with variables
            string questionText = "What is the fastest animal?";
            string questionAnswer = "Cheetah";
            List<string> wrongAnswers = new List<string> { "Sloth", "Snail", "Tortoise" };
            Question q1 = new Question(questionText, questionAnswer, wrongAnswers);

            Question q2 = new Question("What color is an elephant?", "Gray", new List<string> { "Pink", "Green", "Purple" });
            Question q3 = new Question("What does a cat say?", "Meow", new List<string> { "Quack", "Woof", "Beep" });

            
            // Add quiz question to a List
            QuizQuestions = new List<Question> { q1, q2, q3 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayQuestion(0);
            btnNext.Enabled = false;
            btnCheckAnswer.Focus();
        }
        private void DisplayQuestion(int questionIndex)
        {
            // Look up the question, using questionIndex
            Question question = QuizQuestions[questionIndex];

            List<string> answers = question.AllAnswers;

            foreach (RadioButton rb in QuizRadioButtons)
            {
                rb.Checked = false;
            }
            // Set or reset the label results so it does not show results from previos question
            lblResults.Text = "??";
            
            //  Use the answers to set the text for each RadioButton

            for (int a = 0; a < answers.Count; a++)
            {
                QuizRadioButtons[a].Text = answers[a];
            }
            // And display the question text
            lblQuestion.Text = question.QuestionText;
        }

        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            Question currentQuestion = QuizQuestions[CurrentQuestionNumber];

            // Which RadioButton was select?
            string userAnswer = null;

            foreach  (RadioButton rb in QuizRadioButtons)
            {
                if (rb.Checked == true)
                {
                    userAnswer = rb.Text;
                }
            }
            if (userAnswer == null)
            {
                MessageBox.Show("Pick an answer", "Error");
                return;
            }

           
            if (.Is)
            {
                lblResults.Text = "Correct!";
                score++; // Increase score
            }
            else
            {
                lblResults.Text = $"Wrong. The correct answer is {currentQuestion.CorrectAnswer}";
            }
            // Disable btnCheckAnswer, enable btnNext, focus on btnNext
            btnCheckAnswer.Enabled = false;
            btnNext.Enabled = true;
            btnNext.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Advance to next QUESTIOIN 
            CurrentQuestionNumber++;

            // Are there more question to show?
            if (CurrentQuestionNumber < QuizQuestions.Count)
            {
                DisplayQuestion(CurrentQuestionNumber);
                // Disable Next, enable check Answer and focus on this button
                btnNext.Enabled = false;
                btnCheckAnswer.Enabled = true;
                btnCheckAnswer.Focus();

            }
            else
            {
                MessageBox.Show($"End of Quiz! Your score is {score}", "Quiz Over");
                // Disable both buttons
                btnNext.Enabled = false;
                btnCheckAnswer.Enabled = false;
            }
        }
    }
}
