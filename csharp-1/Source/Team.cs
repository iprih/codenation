using System;
using System.Collections.Generic;
using System.Text;

namespace Source
{
    public class Team
    {
       // internal long Captain;

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string MainShirtColor { get; set; }
        public string SecondaryShirtColor { get; set; }
        public long? Captain { get;  set; }
        //public object Captain { get; internal set; }
    }
}
