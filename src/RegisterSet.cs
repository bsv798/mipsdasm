using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public abstract class RegisterSet
    {
        protected Register[] arr;

        public RegisterSet()
        {

        }

        public Register getRegister(int idx)
        {
            return arr[idx];
        }
    }
}
