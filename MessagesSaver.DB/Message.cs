using System;
using System.ComponentModel.DataAnnotations;

namespace MessagesSaver.DB
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }


    }
}
