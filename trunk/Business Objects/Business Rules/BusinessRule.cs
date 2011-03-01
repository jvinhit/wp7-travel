using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business_Objects.Business_Rules
{
    abstract class BusinessRule
    {
        private string _propertyName;

        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
        public BusinessRule(string propertyName)
        {
            this._propertyName = propertyName;
            this._errorMessage = _propertyName.ToString()+"is not valid";

        }
        public BusinessRule(string propertyName, string errorMessage):this(propertyName)
        {
            
            this._errorMessage = errorMessage;
        }
        public abstract bool ValidProperty(BusinessObject businessRule);
        protected object GetPropertyValue(BusinessObject businessObject)
        {
            return null;
        }
    
        



    }
}
