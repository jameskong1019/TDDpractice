﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TDDpractice.Core.Validation
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        #region properties
        public Func<DateTime> _dateTimeNowProvidier { get; }
        #endregion

        public DateInFutureAttribute()
            : this(() => DateTime.Now)
        {
        }

        public bool IsValid(DateTime date)
        {
            if(date > _dateTimeNowProvidier())
            {
                return true;
            }

            return false;
        }

        public DateInFutureAttribute(Func<DateTime> dateTimeNowProvidier)
        {
            _dateTimeNowProvidier = dateTimeNowProvidier;
        }

    }
}
