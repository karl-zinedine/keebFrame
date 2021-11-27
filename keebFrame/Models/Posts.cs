using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace keebFrame.Models
{
    public class Posts
    {
        [Key]
        public int pId { get; set; }
        public string pTitle { get; set; }
        public string pQuestion { get; set; }
        public string pAnswer { get; set; }
        public int pImageId { get; set; }
    }
}
