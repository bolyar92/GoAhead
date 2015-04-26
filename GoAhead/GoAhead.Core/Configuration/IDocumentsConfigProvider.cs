﻿using GoAhead.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoAhead.Core
{
    public interface IDocumentsConfigProvider
    {
        DocumentsConfiguration ReadConfiguration();
    }
}
