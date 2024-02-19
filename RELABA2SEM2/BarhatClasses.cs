using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RELABA2SEM2
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [NotComparable()]
    public class Test2NOTCOMPARABLE
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Test3
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Test4
    {
        [Unreadable()]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
