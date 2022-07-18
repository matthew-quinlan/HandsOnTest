﻿using System;
using System.Collections.Generic;

namespace HandsOnTest.DAL.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string? AnswerText { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
