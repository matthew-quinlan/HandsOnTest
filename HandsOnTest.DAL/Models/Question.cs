using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HandsOnTest.DAL.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                    new Question()
                    {
                        QuestionId = 1,
                        QuestionText = "In what city were you born?"
                    },
                    new Question()
                    {
                        QuestionId = 2,
                        QuestionText = "What is the name of your favorite pet?"
                    },
                    new Question()
                    {
                        QuestionId = 3,
                        QuestionText = "What is your mother's maiden name?"
                    },
                    new Question()
                    {
                        QuestionId = 4,
                        QuestionText = "What was the mascot of your high school?"
                    },
                    new Question()
                    {
                        QuestionId = 5,
                        QuestionText = "What was the make of your first car?"
                    },
                    new Question()
                    {
                        QuestionId = 6,
                        QuestionText = "What was your favorite toy as a child?"
                    },
                    new Question()
                    {
                        QuestionId = 7,
                        QuestionText = "Where did you meet your spouse?"
                    },
                    new Question()
                    {
                        QuestionId = 8,
                        QuestionText = "What is your favorite meal?"
                    },
                    new Question()
                    {
                        QuestionId = 9,
                        QuestionText = "Who is your favorite actor / actress ?"
                    },
                    new Question()
                    {
                        QuestionId = 10,
                        QuestionText = "What is your favorite album ?"
                    }
            );

        }
    }
}
