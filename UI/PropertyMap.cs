using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClient.UI
{
    public partial class PropertyMap : UserControl
    {
        public PropertyMap()
        {
            InitializeComponent();
        }

        public void SetPropertyObject(object obj)
        {
            PropertyGrid.SelectedObject = obj;
        }

        public T GetPropertyObject<T>()
        {
            return ((T)PropertyGrid.SelectedObject);
        }
    }
}
