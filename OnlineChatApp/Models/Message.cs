﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineChatApp.Models
{
    public class Message
    {
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime When { get; set; }

        public string UserID  { get; set; }
        public virtual AppUser appUser { get; set; }

        public Message()
        {
            When = DateTime.Now;
        }
    }
}
