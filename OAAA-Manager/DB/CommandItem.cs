using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAAA_Manager.DB
{
    public class CommandItem
    {
        public SQLiteCommand Command { get; set; }

        public Action<CommandItem> Callback { get; set; }

        public Exception SQLiteException { get; set; }

        public SQLiteDataReader Reader { get; set; }

        public CommandItem() { }
    }
}
