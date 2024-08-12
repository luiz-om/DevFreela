using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.Models
{
    public class CreateProjectCommentInputModel
    {
        public string Content{ get; set; }
        public int IdProject { get; set; } 
        public int IdUser { get; set; }
    }
}