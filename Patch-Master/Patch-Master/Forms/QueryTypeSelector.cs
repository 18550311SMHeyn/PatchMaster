using Patch_Master.DbContext.Database;
using Patch_Master.DbContext.QueryReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Patch_Master.Forms
{
    public partial class QueryTypeSelector : Form
    {
        public static int SAVEDQUERYID = 0;

        bool userLogged = false;
        int loggedUserId = 0;
        string loggedUserName = string.Empty;
        string roleName = string.Empty;
        int roleId = 0;

        public static string QueryType =string.Empty;
        public static string QueryName = string.Empty;
        public static string QueryDes = string.Empty;
        //int SavedQueryId = 0;
        public QueryTypeSelector()
        {
            InitializeComponent();
            QueryName_textBox.Text = Requirements.REQUIREMENTNAME;
            QueryDecription_richTextBox.Text = Requirements.REQUIREMENTDES;

            CheckLogin();

        }
        private void CheckLogin()
        {
            userLogged = Home.Userlogged;
            loggedUserId = Home.loggedUserId;
            loggedUserName = Home.UserName;
            roleId = Home.RoleId;
            roleName = Home.Role;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void QueryTypeSelector_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            QueryName = QueryName_textBox.Text;
            QueryDes = QueryDecription_richTextBox.Text;
            
            SaveQueryDetails();
            
        }

        private void SaveQueryDetails()
        {
            DbConnector dbContext = new DbConnector();
            SAVEDQUERYID = 0;
            try
            {
                string RequirementId = Requirements.REQUIREMENTID;
                string RequirementName = Requirements.REQUIREMENTNAME;
                string SelectedDatabaseId = Requirements.SELECTEDDATABASEID;

                string QueryName = QueryName_textBox.Text;
                string QueryDescription = QueryDecription_richTextBox.Text;
                int ExecutionOrder = Convert.ToInt32(textBoxExecutionOrder.Text);
                

                if (string.IsNullOrEmpty(QueryName))
                {
                    MessageBox.Show("Query name cannot be empty", "Add Query");
                    return;

                }
                if (string.IsNullOrEmpty(QueryDescription))
                {
                    MessageBox.Show("Query description cannot be empty", "Add Query");
                    return;
                }
                if (string.IsNullOrEmpty(QueryType))
                {
                    MessageBox.Show("Please select a query type to proceed", "Add Query");
                    return;
                }
                if (ExecutionOrder==0)
                {
                    MessageBox.Show("Please Enter the Order in which this Query to be Executed", "Add Query");
                    return;
                }

                string queryString = SqlQueryStringReader.GetQueryStringById("SaveQueryDetails", "Queries");
                List<SqlParameter> sqlParams = new List<SqlParameter>();
                sqlParams.Add(new SqlParameter("RequirementId", RequirementId));
                sqlParams.Add(new SqlParameter("QueryName", QueryName));
                sqlParams.Add(new SqlParameter("QueryDescription", QueryDescription));
                sqlParams.Add(new SqlParameter("QueryType", QueryType));
                sqlParams.Add(new SqlParameter("CreatedBy", loggedUserId));
                sqlParams.Add(new SqlParameter("ExecutionOrder", ExecutionOrder));
                var dataReaders = dbContext.ExecuteQueryWithIDataReader(queryString, sqlParams);
                var reader = dataReaders[0];

                //int RequirementId = 0;
                while (reader.Read())
                {
                    SAVEDQUERYID = Convert.ToInt32(reader["QueryId"]);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dbContext.CloseConnection();

                if (SAVEDQUERYID > 0)
                {
                    switch (QueryType){
                        case "1":
                            SelectQueryBuilder selectQueryBuilder = new SelectQueryBuilder();
                            SelectQueryBuilder.AddedTableList.Clear();
                            selectQueryBuilder.Show();
                            break;
                        case "3":
                            UpdateQueryBuilder updateQueryBuilder = new UpdateQueryBuilder();
                            UpdateQueryBuilder.firstSelectedTable = string.Empty;
                                UpdateQueryBuilder.AddedTableList.Clear();
                            updateQueryBuilder.Show();
                            break;
                    }
                }
            }

        }
        private void selectQueryType(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RadioButton rb = (RadioButton)sender;
                QueryType = rb.TabIndex.ToString();
            }
        }
    }
}
