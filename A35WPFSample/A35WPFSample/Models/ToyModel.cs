using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A35WPFSample.Models
{
    public class ToyModel
    {
        //CONSTRUCTOR
        public ToyModel(String name)
        {
            _nameForDisplay = name;
        }


        //MEMBERS
        private String _nameForDisplay;


        //PROPERTIES
        public String NameForDisplay
        {
            get { return _nameForDisplay; }
            set { _nameForDisplay = value; }
        }
    }
}
