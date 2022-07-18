using HandsOnTest.DAL.Models;
using System;
using System.Collections.Generic;

namespace HandsOnTest.BLL.DAO
{
    public partial class QuestionDAO
    {
        public QuestionDAO()
        {
            this.QuestionText = String.Empty;
        }

        public QuestionDAO(Question question)
        {
            QuestionId = question.QuestionId;
            QuestionText = question.QuestionText;
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
    }
}
