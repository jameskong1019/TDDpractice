﻿using System;

namespace TDDpractice.Core.Processor
{
    public class TableBookingRequest
    {
        public TableBookingRequest()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
    }
}