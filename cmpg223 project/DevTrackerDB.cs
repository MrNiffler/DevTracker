using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmpg223_project
{
    public partial class DevTrackerDB : Component
    {
        public DevTrackerDB()
        {
            InitializeComponent();
        }

        public DevTrackerDB(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
