using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iGraphTabletServer.Classes.DB
{
    public class DBShortcut
    {
        #region Enums
        #endregion

        #region Properties
            public const string kTableName = "DBShortcut";

            public int Id { get; set; }
            public string Name { get; set; }
            public bool CmdState { get; set; }
            public bool CtrlState { get; set; }
            public bool AltState { get; set; }
            public bool ShiftState { get; set; }
            public char Value { get; set; }   //1 char
        #endregion

        #region Constructors
            public DBShortcut()
            {

            }

            public DBShortcut(DataRow row)
            {

                if (row != null)
                {
                    try
                    {
                        if (!DBNull.Value.Equals(row["id"])) this.Id = (int)row["id"];
                        if (!DBNull.Value.Equals(row["Name"])) this.Name = (string)row["Name"];
                        if (!DBNull.Value.Equals(row["CmdState"])) this.CmdState = (bool)row["CmdState"];
                        if (!DBNull.Value.Equals(row["CtrlState"])) this.CtrlState = (bool)row["CtrlState"];
                        if (!DBNull.Value.Equals(row["AltState"])) this.AltState = (bool)row["AltState"];
                        if (!DBNull.Value.Equals(row["ShiftState"])) this.ShiftState = (bool)row["ShiftState"];

                        if (!DBNull.Value.Equals(row["Value"])) this.Value = (char)row["Value"];
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
                        row["Name"] = this.Name;
                        row["CmdState"] = this.CmdState;
                        row["CtrlState"] = this.CtrlState;
                        row["AltState"] = this.AltState;
                        row["ShiftState"] = this.ShiftState;

                        row["Value"] = this.Value;
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
