using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnTest.BLL.DAO;
using HandsOnTest.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HandsOnTest.BLL.Services
{
    /// <summary>
    /// Service to handle adding answers and retrieving questions
    /// </summary>
    public class QuestionService
    {
        public QuestionService()
        {
            new HandsOnTestContext().Database.Migrate();
        }
        public ICollection<QuestionDAO> GetQuestions()
        {
            using (var context = new HandsOnTestContext())
            {
                var questions = context.Questions.Select(x=> new QuestionDAO()
                {
                    QuestionId = x.QuestionId,
                    QuestionText = x.QuestionText
                }).ToList();
                return questions;
            }
        }

        public IEnumerable<QuestionDAO> GetAnsweredQuestions(string userName)
        {
            using (var context = new HandsOnTestContext())
            {
                var questions = context.Users
                                .Where(x => x.UserName == userName)
                                .SelectMany(x => x.Answers.Select(y=>new QuestionDAO(y.Question))).ToList();
                return questions;
            }
        }

        public void AddUpdateAnswer(int questionId, int userId, string answerText)
        {
            using (var context = new HandsOnTestContext())
            {
                if(!context.Answers.Any(x=>x.UserId == userId && x.QuestionId == questionId))
                {
                    context.Answers.Add(new Answer()
                    {
                        UserId = userId,
                        QuestionId = questionId,
                        AnswerText = answerText
                    });
                }
                else
                {
                    var answer = context.Answers.Where(x => x.UserId == userId && x.QuestionId == questionId).FirstOrDefault();
                    if (answer != null)
                    {
                        answer.AnswerText = answerText;
                    }
                }
                try
                {
                    context.SaveChanges();
                }
                catch(Exception)
                {

                }
            }
        }

        public AnswerDAO? GetAnswer(int questionId, int userId)
        {
            try
            {
                using (var context = new HandsOnTestContext())
                {
                    var answer = context.Answers.Where(x => x.UserId == userId && x.QuestionId == questionId).FirstOrDefault();
                    if (answer == null)
                        return null;
                    
                    return new AnswerDAO(answer);
                }
             
            }
            catch(Exception)
            {

            }
            return null;
        }

    }
}
