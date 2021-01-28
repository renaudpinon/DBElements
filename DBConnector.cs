using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace iGraphTabletServer.Classes.DB
{
    public class DbConnector
    {

        #region Properties
        private const string kDBSchema = "Data\\iGraphTabletServerSchema.xsd";
        private const string kDBFilename = "Data\\iGraphTabletServerData.xml";

        private DataSet _dataset = new DataSet("iGraphTabletServer");
        #endregion

        #region Constructors

        public DbConnector()
        {
            try
            {
                // Schema :
                _dataset.ReadXmlSchema(AppDomain.CurrentDomain.BaseDirectory + kDBSchema);

                // Load data from xml :
                if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + kDBFilename))
                {
                    _dataset.ReadXml(AppDomain.CurrentDomain.BaseDirectory + kDBFilename);
                }
                else
                {
                    _dataset.WriteXml(AppDomain.CurrentDomain.BaseDirectory + kDBFilename); // we create empty xml.
                }
            }
            catch (Exception ex)
            {
                int x = 0;  // TODO: logger l'erreur.
            }
        }


        #endregion

        #region Methods
            public void DBSubmitChanges()
            {
                try
                {
                    _dataset.WriteXml(AppDomain.CurrentDomain.BaseDirectory + kDBFilename); // we save xml.
                }
                catch (Exception ex)
                {
                    int x = 0;  // TODO: logger l'erreur
                }
            }

            #region DBScreen
                public void DBScreenInsertOrUpdate(DBScreen screen)
                {
                    if (screen != null)
                    {
                        try
                        {

                            if (screen.Id <= 0)
                            {
                                DataRow r = _dataset.Tables[DBScreen.kTableName].NewRow();
                                if (r != null)
                                {
                                    screen.UpdateRow(r);
                                    _dataset.Tables[DBScreen.kTableName].Rows.Add(r);
                                }
                            }
                            else
                            {
                                DataRow r = _dataset.Tables[DBScreen.kTableName].Rows.Find(screen.Id);
                                if (r != null)
                                {
                                    screen.UpdateRow(r);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            int x = 0;
                        }
                    }
                }

                public void DBScreenRemove(DBScreen screen)
                {
                    if (screen != null && screen.Id > 0)
                    {
                        try
                        {
                            DataRow r = _dataset.Tables[DBScreen.kTableName].Rows.Find(screen.Id);
                            if (r != null)
                            {
                                _dataset.Tables[DBScreen.kTableName].Rows.Remove(r);
                            }
                        }
                        catch (Exception)
                        {
                            int x = 0;
                        }
                    }
                }

                public void DBScreenRemoveAll()
                {
                    try
                    {
                        _dataset.Tables[DBScreen.kTableName].Rows.Clear();
                    }
                    catch (Exception)
                    {
                        int x = 0;
                    }
                }

                public List<DBScreen> GetDbScreens()
                {
                    List<DBScreen> screens = new List<DBScreen>();

                    foreach (DataRow r in _dataset.Tables[DBScreen.kTableName].Rows)
                    {
                        DBScreen screen = new DBScreen(r);
                        screens.Add(screen);
                    }

                    return screens;
                }
            #endregion
        #endregion
    }
}
