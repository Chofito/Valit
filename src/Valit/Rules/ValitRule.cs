﻿using System;
using System.Collections.Generic;
using System.Text;
using Valit;

namespace Valit
{
    internal class ValitRule<TProperty> : IValitRule<TProperty>, IValitRuleConfigAccessor<TProperty>
    {        
        bool IValitRuleConfigAccessor.IsSatisfied { get; set; } = true;
        List<string> IValitRuleConfigAccessor.ErrorMessages => _errorMessages;

        TProperty IValitRuleConfigAccessor<TProperty>.Property => _property;
        IValitRule<TProperty> IValitRuleConfigAccessor<TProperty>.PreviousRule => _previousRule;

        private readonly List<string> _errorMessages;
        private readonly TProperty _property;
        private readonly IValitRule<TProperty> _previousRule;

        internal ValitRule(IValitRule<TProperty> previousRule)
        {
            var previousRuleAccessor = previousRule.GetAccessor();
            _property = previousRuleAccessor.Property;
            _errorMessages = previousRuleAccessor.ErrorMessages;
            _previousRule = previousRule;
        }

        internal ValitRule(TProperty property)
        {
            _property = property;
            _errorMessages = new List<string>();
            _previousRule = new ValitRule<TProperty>();
        }

        private ValitRule()
        {            
        }
    }
}
