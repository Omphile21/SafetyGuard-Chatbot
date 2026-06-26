using System;

namespace safety_chatbot
{
    public class QuizQuestion
    {
        // Stores the question
        public string Question { get; set; }

        // Stores the answer choices
        public string[] Answers { get; set; }

        // Stores the index of the correct answer
        // (0 = first answer, 1 = second answer, etc.)
        public int CorrectAnswer { get; set; }

        // Empty constructor
        public QuizQuestion()
        {
        }

        // Constructor with parameters
        public QuizQuestion(string question,
                            string[] answers,
                            int correctAnswer)
        {
            Question = question;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }

        // Optional: Display the question in a ListBox if needed
        public override string ToString()
        {
            return Question;
        }
    }
}