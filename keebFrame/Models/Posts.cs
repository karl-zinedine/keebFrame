using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keebFrame.Models
{
    public partial class Posts
    {
        [Key]
        public int? PId { get; set; }
        public string PTitle { get; set; }
        public string PQuestion { get; set; }
        public string PAnswer { get; set; }
        public int? PImageId { get; set; }
    }
}
