using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BasovHotel
{
    class AppData
    {
        public static Frame MainFrame = new Frame();
        public static HotelSQLBasSimEntities Context = new HotelSQLBasSimEntities();
        public static string UserName;
    }
}
