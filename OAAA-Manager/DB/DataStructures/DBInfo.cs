using OAAA_Manager.Utilities;
using System;
using System.Data.SQLite;

namespace OAAA_Manager.DB.DataStructures
{
    public class DBInfo : SafeDependencyObject
    {
        public GenericDependencyProperty<DBInfo, int> ID { private set; get; }

        public GenericDependencyProperty<DBInfo, int> SignID { private set; get; }

        public GenericDependencyProperty<DBInfo, int> Brightness { private set; get; }

        public GenericDependencyProperty<DBInfo, int> AmbientLight { private set; get; }

        public GenericDependencyProperty<DBInfo, int> LightSensorActive { private set; get; }

        public GenericDependencyProperty<DBInfo, double> VisualOperatingPercentage { private set; get; }

        public GenericDependencyProperty<DBInfo, int> ContentInputStatus { private set; get; }

        public GenericDependencyProperty<DBInfo, int> RequiresService { private set; get; }

        public GenericDependencyProperty<DBInfo, string> TimeStamp { private set; get; }

        public DBInfo()
        {
            ID                          = new GenericDependencyProperty<DBInfo, int>    (this, "ID");
            SignID                      = new GenericDependencyProperty<DBInfo, int>    (this, "SignID");
            Brightness                  = new GenericDependencyProperty<DBInfo, int>    (this, "Brightness");
            AmbientLight                = new GenericDependencyProperty<DBInfo, int>    (this, "AmbientLight");
            LightSensorActive           = new GenericDependencyProperty<DBInfo, int>    (this, "LightSensorActive");
            VisualOperatingPercentage   = new GenericDependencyProperty<DBInfo, double> (this, "VisualOperatingPercentage");
            ContentInputStatus          = new GenericDependencyProperty<DBInfo, int>    (this, "ContentInputStatus");
            RequiresService             = new GenericDependencyProperty<DBInfo, int>    (this, "RequiresService");
            TimeStamp                   = new GenericDependencyProperty<DBInfo, string> (this, "TimeStamp");
        }

        public DBInfo(SQLiteDataReader Reader) : this()
        {
            ID.SafeValue                        = (int)     Reader["idinfo"];
            SignID.SafeValue                    = (int)     Reader["idsign"];
            Brightness.SafeValue                = (int)     Reader["brightness"];
            AmbientLight.SafeValue              = (int)     Reader["ambientlight"];
            LightSensorActive.SafeValue         = (int)     Reader["lightsensor"];
            VisualOperatingPercentage.SafeValue = (double)  Reader["vop"];
            ContentInputStatus.SafeValue        = (int)     Reader["content"];
            RequiresService.SafeValue           = (int)     Reader["service"];
            TimeStamp.SafeValue                 = (string)  Reader["timestamp"];
        }

        public SQLiteCommand CreateInsertCommand()
        {
            SQLiteCommand item = new SQLiteCommand();

            item.CommandText = "INSERT INTO info " + 
                "(`idsign`, `brightness`, `ambientlight`, `lightsensor`, `vop`, `content`, `service`, `timestamp`) " +
                "VALUES " + 
                "(@idsign, @brightness, @ambientlight, @lightsensor, @vop, @content, @servive, @timestamp);" +
                "select last_insert_rowid() as idinfo;";

            item.Parameters.Add(new SQLiteParameter("@idsign",          SignID.SafeValue));
            item.Parameters.Add(new SQLiteParameter("@brightness",      Brightness.SafeValue));
            item.Parameters.Add(new SQLiteParameter("@ambientlight",    AmbientLight.SafeValue));
            item.Parameters.Add(new SQLiteParameter("@lightsensor",     LightSensorActive.SafeValue));
            item.Parameters.Add(new SQLiteParameter("@vop",             VisualOperatingPercentage.SafeValue));
            item.Parameters.Add(new SQLiteParameter("@content",         ContentInputStatus.SafeValue));
            item.Parameters.Add(new SQLiteParameter("@servive",         RequiresService.SafeValue));
            item.Parameters.Add(new SQLiteParameter("@timestamp",       TimeStamp.SafeValue));

            return item;
        }

        private void InsertedCommand_Callback(CommandItem item)
        {
            if (item.Reader.Read())
                ID.SafeValue = (int)item.Reader["idinfo"];
            else
                item.SQLiteException = new Exception("Could not get id for inserted info.", item.SQLiteException);
        }
    }
}
