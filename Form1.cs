using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;

namespace A1
{
    public partial class Form1 : Form
    {


        SqlDataAdapter da = new SqlDataAdapter();

        DataSet ds = new DataSet();

        DataSet ds1 = new DataSet();
        int pFKid, id;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> ColumnNames = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));

            int pointX = 30;

            int pointY = 40;


            panel1.Controls.Clear();

            foreach (string column in ColumnNames)

            {

                System.Windows.Forms.TextBox a = new System.Windows.Forms.TextBox();

                a.Text = column;

                a.Name = column;

                a.Location = new Point(pointX, pointY);

                a.Visible = true;

                a.Parent = panel1;

                panel1.Show();

                pointY += 30;

            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            SqlConnection cs = new SqlConnection(con);
            da.SelectCommand = new SqlCommand(ConfigurationManager.AppSettings["selectParent"], cs);

            ds.Clear();
            da.Fill(ds);
            meniuDataGrid.DataSource = ds.Tables[0];

        }


        private void meniuDataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            SqlConnection cs = new SqlConnection(con);
            da.SelectCommand = new SqlCommand(ConfigurationManager.AppSettings["selectChild"], cs);
            pFKid = int.Parse(meniuDataGrid.SelectedRows[0].Cells[0].Value.ToString());
            da.SelectCommand.Parameters.Add("@pFKid", SqlDbType.Int).Value = pFKid;
            ds1.Clear();
            da.Fill(ds1);
            clientDataGrid.DataSource = ds1.Tables[0];

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            SqlConnection cs = new SqlConnection(con);

            try

            {

                string ChildTableName = ConfigurationManager.AppSettings["ChildTableName"];

                string ChildColumnNames = ConfigurationManager.AppSettings["ChildColumnNames"];

                List<string> ColumnNamesList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));

                string InsertQuery = ConfigurationManager.AppSettings["InsertQuery"];

                SqlCommand cmd = new SqlCommand(InsertQuery, cs);

                cmd.Parameters.AddWithValue("@pFKid", pFKid);

                foreach (string column in ColumnNamesList)

                {

                    System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox)panel1.Controls[column];

                    cmd.Parameters.AddWithValue("@" + column, textbox.Text);

                }

                cs.Open();

                cmd.ExecuteNonQuery();

                ds1.Clear();

                da.Fill(ds1);

                clientDataGrid.DataSource = ds1.Tables[0];

                MessageBox.Show("Inserted succesfully!");

                cs.Close();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

                cs.Close();

            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            SqlConnection cs = new SqlConnection(con);

            try

            {

                string ChildTableName = ConfigurationManager.AppSettings["ChildTableName"];



                string DeleteQuery = ConfigurationManager.AppSettings["DeleteQuery"];

                SqlCommand cmd = new SqlCommand(DeleteQuery, cs);

                cmd.Parameters.AddWithValue("@id", id);

                cs.Open();

                cmd.ExecuteNonQuery();

                ds1.Clear();

                da.Fill(ds1);

                clientDataGrid.DataSource = ds1.Tables[0];

                MessageBox.Show("Removed succesfully!");

                cs.Close();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

                cs.Close();

            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;

            SqlConnection cs = new SqlConnection(con);

            try

            {

                string ChildTableName = ConfigurationManager.AppSettings["ChildTableName"];

                string ChildColumnNames = ConfigurationManager.AppSettings["ChildColumnNames"];

                List<string> ColumnNamesList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));

                string UpdateQuery = ConfigurationManager.AppSettings["UpdateQuery"];

                SqlCommand cmd = new SqlCommand(UpdateQuery, cs);

                cmd.Parameters.AddWithValue("@id", id);

                foreach (string column in ColumnNamesList)

                {

                    System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox)panel1.Controls[column];

                    cmd.Parameters.AddWithValue("@" + column, textbox.Text);

                }

                cs.Open();

                cmd.ExecuteNonQuery();

                ds1.Clear();

                da.Fill(ds1);

                clientDataGrid.DataSource = ds1.Tables[0];

                MessageBox.Show("Updated succesfully!");

                cs.Close();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

                cs.Close();

            }
        }

        private void clientDataGrid_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<string> ColumnNames = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));

            id = int.Parse(clientDataGrid.CurrentRow.Cells[0].Value.ToString());

            int i = int.Parse(ConfigurationManager.AppSettings["index"]);

            foreach (string column in ColumnNames)

            {

                System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)panel1.Controls[column];

                textBox.Text = clientDataGrid.CurrentRow.Cells[i].Value.ToString();

                i++;

            }
        }
    }
}