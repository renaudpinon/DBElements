using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iGraphTabletServer.Classes.DB
{
    public class DBConfiguration
    {
        #region Properties
            public const string kTableName = "DBConfiguration";

            public int Id { get; set; }
            public bool IsLaunchingAtStartup { get; set; }
        #endregion

        #region Constructors
            public DBConfiguration()
            {

            }

            public DBConfiguration(DataRow row)
            {

                if (row != null)
                {
                    try
                    {
                        if (!DBNull.Value.Equals(row["id"])) this.Id = (int)row["id"];
                        if (!DBNull.Value.Equals(row["IsLaunchingAtStartup"])) this.IsLaunchingAtStartup = (bool)row["IsLaunchingAtStartup"];
                    }
                    catch (Exception ex)
                    {
                        int x = 0;
                    }
                }
            }
        #endregion

        #region Methods
            public void UpdateRow(DataRow row)
            {
                if (row != null)
                {
                    try
                    {
                        // Update the object's id :
                        if (!DBNull.Value.Equals(row["id"])) this.Id = (int)row["id"];

                        // Update values in the database :
                        row["IsLaunchingAtStartup"] = this.IsLaunchingAtStartup;
                    }
                    catch (Exception ex)
                    {
                        int x = 0;
                    }
                }
            }
        #endregion
    }
}
