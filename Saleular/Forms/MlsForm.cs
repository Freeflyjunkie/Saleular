using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Forms
{
    public class MlsForm : IForm
    {
        private readonly string _state;

        public MlsForm(string state)
        {
            _state = state;
        }

        public List<string> GetForms()
        {            
            return new List<string>
            {
                _state + " MLS Form 1", _state + " MLS Form 2"
            };
        }
    }
}