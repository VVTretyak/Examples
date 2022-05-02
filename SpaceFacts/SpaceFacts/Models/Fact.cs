using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceFacts.Models
{
    public class Fact
    {
        public int Id { get; set; }
        public string NameOfFact { get; set; }
        public string Content { get; set; }
    }
}
