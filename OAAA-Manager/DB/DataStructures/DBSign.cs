using OAAA_Manager.Utilities;
using System;
using System.Data.SQLite;

namespace OAAA_Manager.DB.DataStructures
{
    public class DBSign : SafeDependencyObject
    {
        public GenericDependencyProperty<DBSign, int> ID { private set; get; }
        
        public GenericDependencyProperty<DBSign, string> Name { private set; get; }

        public GenericDependencyProperty<DBSign, string> Address { private set; get; }

        public GenericDependencyProperty<DBSign, int> Port { private set; get; }
        
        public DBSign()
        {
            ID = new GenericDependencyProperty<DBSign, int>(this, "ID");
            Name = new GenericDependencyProperty<DBSign, string>(this, "Name");
            Address = new GenericDependencyProperty<DBSign, string>(this, "Address");
            Port = new GenericDependencyProperty<DBSign, int>(this, "Port");
        }

        public CommandItem CreateInsertCommand()
        {
            CommandItem item = new CommandItem()
            {
                Command = new SQLiteCommand()
                {
                    CommandText = "INSERT INTO signs " +
                        "(`name`, `address`, `port`) " +
                        "VALUES " +
                        "(@name, @address, @port);" +
                        "select last_insert_rowid() as idsign;"
                }
            };

            item.Command.Parameters.Add(new SQLiteParameter("@name", Name.SafeValue));
            item.Command.Parameters.Add(new SQLiteParameter("@address", Address.SafeValue));
            item.Command.Parameters.Add(new SQLiteParameter("@port", Port.SafeValue));
            item.Callback += InsertedCommand_Callback;

            return item;
        }

        private void InsertedCommand_Callback(CommandItem item)
        {
            if (item.Reader.Read())
                ID.SafeValue = (int)item.Reader["idsign"];
            else
                item.SQLiteException = new Exception("Could not get id for inserted sign.", item.SQLiteException);
        }
    }
}
