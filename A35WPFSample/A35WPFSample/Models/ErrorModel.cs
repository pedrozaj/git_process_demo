using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A35WPFSample.Models
{
    public class ErrorModel
    {
        //CONSTRUCTOR
        public ErrorModel(String desc)
        {
            _errDescription = desc;
        }


        //MEMBERS
        String _errDescription;


        //PROPERTIES
        public String ErrorDescription
        {
            get
            {
                return _errDescription;
            }
            set
            {
                _errDescription = value;
            }
        }
        public int ErrorCount { get;set; }
    }
}
