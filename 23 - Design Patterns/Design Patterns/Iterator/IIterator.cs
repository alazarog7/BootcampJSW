﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public interface Iterator<T>
    {
        public bool HasNext();
        public T Next();
        public void Remove();

    }
}
