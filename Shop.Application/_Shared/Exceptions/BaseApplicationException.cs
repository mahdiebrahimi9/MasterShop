﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application._Shared.Exceptions
{
    public class BaseApplicationException : Exception
    {
        public BaseApplicationException()
        {

        }

        public BaseApplicationException(string message) : base(message)
        {

        }
    }
}
