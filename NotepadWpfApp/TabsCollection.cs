using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadWpfApp
{
    class TabsCollection
    {
        public ObservableCollection<TabItemControl> tabItemControls { get; set; } = new ObservableCollection<TabItemControl>();


    }
}
