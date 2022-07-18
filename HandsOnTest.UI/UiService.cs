using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.BLL.DAO;
using HandsOnTest.BLL.Services;

namespace HandsOnTest.UI
{
    /// <summary>
    /// Creates DB if necessary and handles app UI
    /// </summary>
    internal class UiService
    {
        UserDAO user;
        UserService userService = new UserService();
        QuestionService questionService = new QuestionService();
        List<QuestionDAO> questions = new List<QuestionDAO>();
        List<QuestionDAO> answeredQuestions = new List<QuestionDAO>();

        public UiService()
        {
            // Creates db and seed data if necessary
            new StartupService();
        }

        /// <summary>
        /// Kicks off UI
        /// </summary>
        public void Start()
        {
            var userName = string.Empty;
            this.questions = questionService.GetQuestions().ToList();

            while (string.IsNullOrEmpty(userName))
            {
                userName = this.GetName().Trim().ToLower();
                var dbUser = userService.GetUser(userName);
                if (dbUser != null)
                {
                    this.user = dbUser;
                }
            }

            if (this.user == null)
            {
                return;
            }

            this.answeredQuestions = questionService.GetAnsweredQuestions(this.user.UserName).ToList();

            if (!answeredQuestions.Any())
            {
                this.StoreFlow();
            }
            else
            {
                var willAnswerSecurityQuestion = this.GetUserInputYesNo("Do you want to answer a security question?");

                if (willAnswerSecurityQuestion)
                {
                    this.AnswerFlow();
                }
                else
                {
                    this.StoreFlow();
                }
            }
        }

        public string GetName()
        {
            var userName = this.GetUserInput("Hi, what is your name?");
            return userName;
        }

        public void StoreFlow()
        {
            var shouldStoreAnswers = this.GetUserInputYesNo("Would you like to store answers to security questions?");

            if (shouldStoreAnswers)
            {
                this.Display("You must answer at least 3 questions");

                var answeredQuestions = 0;

                while (answeredQuestions <= 2)
                {
                    foreach (var question in this.questions)
                    {
                        if (answeredQuestions > 2)
                        {
                            break;
                        }

                        var answer = this.GetUserInput(question.QuestionText);
                        answer = answer.Trim().ToLower();
                        if (!String.IsNullOrEmpty(answer) && this.user != null)
                        {
                            this.questionService.AddUpdateAnswer(question.QuestionId, this.user.UserId, answer);
                            answeredQuestions++;
                        }
                    }
                }

                this.Display("Thank you");
            }
            else
            {
                this.Display("User declined to store");
            }

            this.Start();
        }

        public void AnswerFlow()
        {
            bool successfulAnswer = false;
            foreach (var question in this.answeredQuestions)
            {
                var answerForQuestion = questionService.GetAnswer(question.QuestionId, this.user.UserId);
                if (answerForQuestion == null)
                {
                    continue;
                }
                var usersAnswerForSecurityQuestion = this.GetUserInput(question.QuestionText);
                usersAnswerForSecurityQuestion = usersAnswerForSecurityQuestion.Trim().ToLower();

                if (answerForQuestion.AnswerText == usersAnswerForSecurityQuestion)
                {
                    successfulAnswer = true;
                    break;
                }
            }

            if (successfulAnswer)
            {
                this.Display("Congratulations! You have successfully authenticated.");
            }
            else
            {
                this.Display("You haven't answered the questions correctly.");
            }

            this.Start();
        }

        public void Display(string displayText)
        {
            Console.WriteLine(displayText);
        }

        public string GetUserInput(string displayText)
        {
            Console.WriteLine(displayText);
            var result = String.Empty;

            try
            {
                result = Console.ReadLine();
            }
            catch (Exception)
            {

            }

            return result ?? String.Empty;
        }

        public bool GetUserInputYesNo(string displayText)
        {
            string input = String.Empty;
            bool yesNoFilter = (input.ToLower() == "y" || input.ToLower() == "n" || input.ToLower() == "yes" || input.ToLower() == "no");

            while (input == String.Empty || !yesNoFilter)
            {
                try
                {
                    Console.WriteLine(displayText);
                    var yesNoPrompt = "\tPlease enter (y)es or (n)o: \r\n";
                    input = GetUserInput(yesNoPrompt);
                    input = input.ToLower();
                    if (input == "y" || input == "yes")
                    {
                        return true;
                    }
                    if (input == "n" || input == "no")
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
    }
}
