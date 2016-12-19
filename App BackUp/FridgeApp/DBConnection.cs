using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace FridgeApp
{
    public class DBConnection
    {
        public MySqlConnection Connection { get; private set; }


        private void Connect()
        {
            //TODO: change these values if theyre not the same (password probably)
            try
            {
                Connection = new MySqlConnection(Config.GetConnectionString());
                if (Connection != null && Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                    Logger.GetInstance().Log("Connection opened");
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Logger.GetInstance().Log("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        Logger.GetInstance().Log("Invalid username/password, please try again");
                        break;
                }
            }
            // Probably unnecessary since the switch already checks, but I guess we'll see when a failed connection happens
            if (Connection == null)
                Logger.GetInstance().Log("Connection Failed");
        }

        public bool IsConnected()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                return true;
            return false;
        }

        public void Close()
        {
            Connection.Close();
            Logger.GetInstance().Log("Closed Connection");
        }
        public DBConnection()
        {
            Connection = null;
            Connect();
        }
    }
}
