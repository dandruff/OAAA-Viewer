using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using OAAA_Manager.Utilities;

namespace OAAA_Manager.DB
{
    public class DBManager
    {
        private SQLiteConnection connection;
        private ConcurrentQueue<CommandItem> commandQueue;
        private Thread worker;
        private bool _isRunning;

        public bool IsRunning
        {
            get
            {
                return worker.ThreadState == ThreadState.WaitSleepJoin ||
                    worker.ThreadState == ThreadState.Running;
            }
        }

        public DBManager()
        {
            commandQueue = new ConcurrentQueue<CommandItem>();
            connection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            worker = new Thread(ProcessCommandQueue_Worker);
        }

        public void Start()
        {
            if (IsRunning) return;
            _isRunning = true;
            worker.Start(this);
        }

        public void Stop()
        {
            _isRunning = false;
        }

        private static void ProcessCommandQueue_Worker(object obj)
        {
            DBManager self = obj as DBManager;
            CommandItem currentItem;
            int tries;
            while (self._isRunning)
            {
                tries = 0;
                while (self.commandQueue.Count > 0)
                {
                    if (++tries > 30) break;
                    if (self.commandQueue.TryDequeue(out currentItem))
                    {
                        SQLiteDataReader reader;
                        currentItem.Command.Connection = self.connection;
                        currentItem.SQLiteException = Try.Run<SQLiteDataReader>(currentItem.Command.ExecuteReader, out reader);
                        currentItem.Reader = reader;
                        currentItem.Callback(currentItem);
                        currentItem.Command.Dispose();
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}
