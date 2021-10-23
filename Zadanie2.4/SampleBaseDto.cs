using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2._4
{
    public class SampleBaseDto
    {
        public List<List<string>> Samples { get; set; }
        public List<string> AttrNames { get; set; }
        public List<bool> IfAttrSym { get; set; }
        public Dictionary<string, List<List<double>>> GroupedSamples { get; set; }
    }
}
