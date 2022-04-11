using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckOffProject.Models
{
    public class AnalyzedInstructions
    {
        public int number { get; set; }
        public string step { get; set; }
        public List<InstructionInfo> ingredients { get; set; }
        public List<InstructionInfo> equipment { get; set; }
    }

    public class InstructionInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
    }
}
