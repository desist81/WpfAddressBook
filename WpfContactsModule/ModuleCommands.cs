﻿using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfContactsModule
{
    public static class ModuleCommands
    {
        public static CompositeCommand AddCommand = new CompositeCommand();
        public static CompositeCommand SaveCommand = new CompositeCommand();
        public static CompositeCommand RefreshCommand = new CompositeCommand();
    }
   
}
