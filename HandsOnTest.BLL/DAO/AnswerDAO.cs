using HandsOnTest.DAL.Models;
using System;
using System.Collections.Generic;

namespace HandsOnTest.BLL.DAO
{
    public partial class AnswerDAO
    {
        public AnswerDAO()
        {

        }
        public AnswerDAO(Answer answer)
        {
            this.AnswerText = answer.AnswerText;
            this.AnswerId = answer.AnswerId;
            this.UserId = answer.UserId;
            this.QuestionId = answer.QuestionId;
        }

        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string? AnswerText { get; set; }
    }
}
