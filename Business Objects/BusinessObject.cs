using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business_Objects.Business_Rules;

namespace Business_Objects
{
    class BusinessObject
    {
        private List<BusinessRule> _businessRules = new List<BusinessRule>();
        private List<string> _validationErrors = new List<string>();

        public List<string> ValidationErrors
        {
            get { return _validationErrors; }
         
        }
        protected void AddRule(BusinessRule rule)
        {
            _businessRules.Add(rule);
        }


        public bool Validate()
        {
            bool isValid = true;

            _validationErrors.Clear();

            foreach (BusinessRule rule in _businessRules)
            {
                if (!rule.ValidProperty(this))
                {
                    isValid = false;
                    _validationErrors.Add(rule.ErrorMessage);
                }
            }
            return isValid;
        }
        
    }
}
