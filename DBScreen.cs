using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace iGraphTabletServer.Classes.DB
{
    public class DBScreen
    {
        #region Enums
        public enum ScreenQuality
        {
            Low = 0,
            Medium = 1,
            High = 2
        }

        public enum ScreenType
        {
            Screen = 0,
            Region = 1
        }
        #endregion

        #region Properties
            public const string kTableName = "DBScreen";

            public long Id { get; set; }
            public string Name { get; set; }
            public int NumScreen { get; set; }
            public ScreenQuality Quality { get; set; }
            public ScreenType Type { get; set; }
            public Rect Rect { get; set; }
            public bool Enabled { get; set; }
        #endregion

        #region Constructors
            public DBScreen()
            {
                this.NumScreen = -1;
                this.Enabled = true;
                this.Quality = ScreenQuality.Medium;
                this.Rect = new Rect();
            }

            public DBScreen(DataRow row)
            {
                this.NumScreen = -1;
                this.Enabled = true;
                this.Quality = ScreenQuality.Medium;
                this.Rect = new Rect();

                if (row != null)
                {
                    try
                    {
                        if (!DBNull.Value.Equals(row["id"])) this.Id = (long)row["id"];
                        if (!DBNull.Value.Equals(row["Name"])) this.Name = (string)row["Name"];
                        if (!DBNull.Value.Equals(row["NumScreen"])) this.NumScreen = (int)row["NumScreen"];
                        if (!DBNull.Value.Equals(row["Quality"])) this.Quality = (ScreenQuality)((byte)row["Quality"]);
                        if (!DBNull.Value.Equals(row["Type"])) this.Type = (ScreenType)((byte)row["Type"]);

                        Rect r = new Rect();
                        //byte tmp = 0; 
                        //if (!DBNull.Value.Equals(row["X"])) tmp = (short)row["X"];
                        if (!DBNull.Value.Equals(row["X"])) r.X = (double)((short)row["X"]);
                        if (!DBNull.Value.Equals(row["Y"])) r.Y = (double)((short)row["Y"]);
                        if (!DBNull.Value.Equals(row["Width"])) r.Width = (double)((short)row["Width"]);
                        if (!DBNull.Value.Equals(row["Height"])) r.Height = (double)((short)row["Height"]);
                        this.Rect = r;

                        if (!DBNull.Value.Equals(row["Enabled"])) this.Enabled = (bool)row["Enabled"];
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
                        if (!DBNull.Value.Equals(row["id"])) this.Id = (long)row["id"];

                        // Update values in the database :
                        row["Name"] = this.Name;
                        row["NumScreen"] = this.NumScreen;
                        row["Quality"] = (byte)this.Quality;
                        row["Type"] = (byte)this.Type;

                        row["X"] = this.Rect.X;
                        row["Y"] = this.Rect.Y;
                        row["Width"] = this.Rect.Width;
                        row["Height"] = this.Rect.Height;

                        row["Enabled"] = this.Enabled;
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
