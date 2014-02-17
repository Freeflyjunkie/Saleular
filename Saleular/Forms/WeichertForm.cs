using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saleular.Forms
{
    public class WeichertForm : IForm
    {
        private readonly string _state;

        public WeichertForm(string state)
        {
            _state = state;
        }

        public List<string> GetForms()
        {
            return new List<string>
            {
                _state + " Weichert Form 1", _state + " Weichert Form 2"
            };
        }
    }
}