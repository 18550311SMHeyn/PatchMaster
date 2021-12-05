using Patch_Master.DbContext.Database;
using Patch_Master.DbContext.QueryReader;
using Patch_Master.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Patch_Master.Forms
{
    public partial class UpdateQueryBuilder : Form
    {
        public static string SelectedDatabase;

        bool userLogged = false;
        int loggedUserId = 0;
        string loggedUserName = string.Empty;
        string roleName = string.Empty;
        int roleId = 0;
        int availablecheckedListBoxCount = 0;
        bool queryValidated = true;
        public static string firstSelectedTable = string.Empty;

        Dictionary<string, string> SelectedColumnList = new Dictionary<string, string>();
        public static List<String> AddedTableList = new List<string>();
        public static List<String> UpdateTableList = new List<string>();
        NameConditionBuilder conditionBuilder;
        SelectJoinBuilder selectJoinBuilder;
        UpdateFields updateFields;
        public UpdateQueryBuilder()
        {
            InitializeComponent();
            richTextBoxQueryDes.Text = QueryTypeSelector.QueryDes;
            textBoxQueryName.Text = QueryTypeSelector.QueryName;
            CheckLogin();
            InitializeScrollBars();
            //LoadAvailableDatabases();
            LoadAvailableTablesForDb(Requirements.SELECTEDDATABSENAME);

        }
        private void CheckLogin()
        {
            userLogged = Home.Userlogged;
            loggedUserId = Home.loggedUserId;
            loggedUserName = Home.UserName;
            roleId = Home.RoleId;
            roleName = Home.Role;

        }
        #region Load Tables of the Database
        private void LoadAvailableTablesForDb(string databaseName)
        {
            List<string> AvailableTables = LoadAvailableTablesFromDb(databaseName);

            foreach (var tableName in AvailableTables)
            {
                TableList_treeView.Nodes.Add(tableName);
            }

        }
        private List<string> LoadAvailableTablesFromDb(string dbName)
        {
            DbConnector dbContext = new DbConnector();
            List<string> AvailableTableList = new List<string>();
            try
            {
                string queryString = SqlQueryStringReader.GetQueryStringById("LoadAvailableTables", "DBConnections");
                List<SqlParameter> sqlParams = new List<SqlParameter>();

                sqlParams.Add(new SqlParameter("DbName", dbName));
                var dataReaders = dbContext.ExecuteQueryWithIDataReader(queryString, sqlParams);
                var reader = dataReaders[0];

                while (reader.Read())
                {
                    var TableName = reader["TableName"].ToString();
                    AvailableTableList.Add(TableName);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                dbContext.CloseConnection();
            }
            return AvailableTableList;
        }
        private void InitializeScrollBars()
        {
            TableView_panel.AutoScroll = false;
            TableView_panel.VerticalScroll.Enabled = false;
            TableView_panel.VerticalScroll.Visible = false;
            TableView_panel.VerticalScroll.Maximum = 0;
            TableView_panel.AutoScroll = true;
        }
        #endregion
        #region view table colunms
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool tableAlreadyAdded = false;
            string DbName = Requirements.SELECTEDDATABSENAME;
            string tableName = e.Node.Text;

            foreach (Control ctrl in TableView_panel.Controls)
            {
                if (ctrl.Name == tableName+ "_label")
                {
                    tableAlreadyAdded = true;
                }
            }
            if (!tableAlreadyAdded)
            {               
                TablesListView.Items.Add(tableName);
                AddedTableList.Add(tableName);
                availablecheckedListBoxCount++; 
            }
            if (availablecheckedListBoxCount>0)
            {
                btnSingleSelectCondition.Enabled = true;
            }
            if (availablecheckedListBoxCount>1)
            {
                AddJoins_button.Enabled = true;
            }
            if (AddedTableList.Count ==1)
            {
                firstSelectedTable = tableName;
                UpdateTableList.Add(tableName);
            }

        }
        //public List<string> LoadAllColumns(string dbName, string tableName)
       // {
        //    DbConnector dbContext = new DbConnector();
          //  List<string> columnList = new List<string>();
            
        //    try
          //  {
          //      string queryString = SqlQueryStringReader.GetQueryStringById("LoadColumnList", "QueryBuilder");
          //      List<SqlParameter> sqlParams = new List<SqlParameter>();
           //     sqlParams.Add(new SqlParameter("DbName", dbName));
           //     sqlParams.Add(new SqlParameter("Table", tableName));
            //    var dataReaders = dbContext.ExecuteQueryWithIDataReader(queryString, sqlParams);
            //    var reader = dataReaders[0];

          //      while (reader.Read())
            //    {
           //        var column = reader["ColumnName"].ToString();
           //         var dataType = reader["DataType"].ToString();
            //        columnList.Add(column);
            //    }
//
           // }
         //   catch (Exception ex)
         //   {
          //      throw;
         //   }
        //    finally
         //   {
        //        dbContext.CloseConnection();
        //    }
        //    return columnList;
       // }
       // private void CheckTableColumn(object sender, ItemCheckEventArgs e)
       // {

         //   CheckedListBox btn = (CheckedListBox)sender;
         //   string selectedTable = btn.AccessibilityObject.Name;
         //   string selectedColumn = btn.SelectedItem.ToString();
         //   string key = selectedTable + "&" + selectedColumn;
          //  if (e.NewValue == CheckState.Checked)
          //  {
          //      SelectedColumnList.Add(key, selectedColumn);
            //}
          //  else
          //  {
          //      SelectedColumnList.Remove(key);
        //    }
            
      //  }
        #endregion
        #region Query conditions
        private void btnSingleSelectCondition_Click(object sender, EventArgs e)
        {
            // this.Hide();
            if (conditionBuilder == null)
            {
                conditionBuilder = new NameConditionBuilder();
                conditionBuilder.Show();
            }
            else
            {
                conditionBuilder.LoadTableList();
                conditionBuilder.Show();
            }
            //SelectConditionBuilder selectConditionBuilder = new SelectConditionBuilder();
            //selectConditionBuilder.Show();
        }
        #endregion
        #region Query Joins
        private void AddJoins_button_Click(object sender, EventArgs e)
        {
            if (selectJoinBuilder == null)
            {
                SelectJoinBuilder.joindetailList.Clear();
                selectJoinBuilder = new SelectJoinBuilder();
                selectJoinBuilder.Show();
            }
            else
            {

                selectJoinBuilder.InitializeJoinConditions();
                selectJoinBuilder.Show();
            }
        }
        #endregion
        #region Build query 
        private void BuildQuery_button_Click(object sender, EventArgs e)
        {
            Query_richTextBox.Text = string.Empty;
            var joinDetails = SelectJoinBuilder.joindetailList;
            string UpdateFieldsString = UpdateFields.UPDATESTRING;
            string joinstring = string.Empty;
            string UpdateString = "UPDATE " + firstSelectedTable;
            Query_richTextBox.Text = UpdateString;
            Query_richTextBox.Text += Environment.NewLine + "SET " + UpdateFieldsString;
            Query_richTextBox.Text += Environment.NewLine + "FROM " + firstSelectedTable + " ";
            if (joinDetails.Count > 0)
            {
                string FromString = "FROM";
                string TableString = string.Empty;
                foreach (var join in joinDetails)
                {
                    joinstring += $"{join.JoinName} {join.TableTwo} ON {join.TableOne}.{join.TableOneColumn} = {join.TableTwo}.{join.TableTwoColumn} {Environment.NewLine}";
                }
                Query_richTextBox.Text += Environment.NewLine + joinstring;
            }
               
            string conditionstring = NameConditionBuilder.CONDITIONSTRING;
            if (!string.IsNullOrEmpty(conditionstring))
            {
                conditionstring = $"WHERE {conditionstring}";
                Query_richTextBox.Text += Environment.NewLine + conditionstring;
            }
        }
        #endregion
        #region Validate Query 
        private void ValidateQuery_button1_Click(object sender, EventArgs e)
        {
            DbConnector dbContext = new DbConnector();
            queryValidated = true;
            try
            {
                string Query = Query_richTextBox.Text;
                if (!string.IsNullOrEmpty(Query))
                {
                    string query = SqlQueryStringReader.GetQueryStringById("CheckQueryValidation", "Queries");
                    List<SqlParameter> sqlParams = new List<SqlParameter>();
                    sqlParams.Add(new SqlParameter("Query", Query));
                    sqlParams.Add(new SqlParameter("Database", Requirements.SELECTEDDATABSENAME.ToString()));
                    dbContext.ExecuteQueryWithIDataReader(query, sqlParams);

                }
                else
                {
                    MessageBox.Show("No built query available!", "Validate Query");
                }

            }
            catch (Exception ex)
            {
                queryValidated = false;
                MessageBox.Show(ex.Message.ToString(), "Validate Query");
            }
            //finally
            //{
            //    dbContext.CloseConnection();
            //}

            if (queryValidated)
            {
                MessageBox.Show("Query Successfully Validated!", "Validate Query");
            }
            dbContext.CloseConnection();
        }
        #endregion
        #region save query
        private void SaveQuerybutton_Click(object sender, EventArgs e)
        {
            string QueryString = Query_richTextBox.Text;

            if (!string.IsNullOrEmpty(QueryString))
            {
                SaveQuery(QueryString);
            }
            else
            {
                MessageBox.Show("Please build a query to save.", "Save Query");
            }
        }
        private void SaveQuery(string queryString)
        {
            DbConnector dbContext = new DbConnector();

            try
            {
                int QueryId = QueryTypeSelector.SAVEDQUERYID;
                string query = SqlQueryStringReader.GetQueryStringById("SaveQueryString", "Queries");
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("QueryId", QueryId));
                sqlParams.Add(new SqlParameter("QueryString", queryString));
                dbContext.ExecuteQueryWithIDataReader(query, sqlParams);

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                dbContext.CloseConnection();
                this.Dispose();

                Application.OpenForms["QueryTypeSelector"].Close();
                Application.OpenForms["AvailableQueries"].Close();

                AvailableQueries availableQueries = new AvailableQueries();
                availableQueries.Show();
                
            }
        }
        #endregion
        private void Clear_button_Click(object sender, EventArgs e)
        {
            firstSelectedTable = string.Empty;
            availablecheckedListBoxCount = 0;
            AddJoins_button.Enabled = false;
            AddedTableList.Clear();
            AddedTableList = new List<string>();
            UpdateTableList.Clear();
            UpdateTableList = new List<string>();
            TablesListView.Items.Clear();
            Query_richTextBox.Text = string.Empty;
        }
        private Dictionary<int, string> GetDatabaseList()
        {
            Dictionary<int, string> savedDatabasesList = new Dictionary<int, string>();
            DbConnector dbContext = new DbConnector();
            bool Status = true;
            try
            {
                string queryString = SqlQueryStringReader.GetQueryStringById("loadDatabases", "DBConnections");
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("Status", Convert.ToBoolean(Status)));
                var dataReaders = dbContext.ExecuteQueryWithIDataReader(queryString, sqlParams);
                var reader = dataReaders[0];

                while (reader.Read())
                {

                    var DatabaseId = Convert.ToInt32(reader["DB_Id"]);
                    var DatabaseName = reader["DBName"].ToString();

                    savedDatabasesList.Add(DatabaseId, DatabaseName);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                dbContext.CloseConnection();
            }
            return savedDatabasesList;
        }

        private void Updatefields_Click(object sender, EventArgs e)
        {
            if (updateFields == null)
            {
               updateFields = new UpdateFields();
                updateFields.Show();
            }
            else
            {
                updateFields.Show();
            }

            
        }
    }
}
