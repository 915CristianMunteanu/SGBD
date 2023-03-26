using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace A1
{
    public partial class Form1 : Form
    {
        SqlConnection cs = new SqlConnection("Data Source = DESKTOP-4HVP8OJ ; Initial Catalog = HospitalDatabase ; Integrated Security = True");

        SqlDataAdapter da = new SqlDataAdapter();

        DataSet ds = new DataSet();

        DataSet ds1 = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            da.SelectCommand = new SqlCommand("Select * from Hospital", cs);
            ds.Clear();
            da.Fill(ds);
            meniuDataGrid.DataSource = ds.Tables[0];
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            da.SelectCommand = new SqlCommand("Select * from Hospital", cs);
            ds.Clear();
            da.Fill(ds);
            meniuDataGrid.DataSource = ds.Tables[0];

        }



        private void meniuDataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            da.SelectCommand = new SqlCommand("Select * from Doctor where HospitalID=@id", cs);
            int id = int.Parse(meniuDataGrid.SelectedRows[0].Cells[0].Value.ToString());
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            ds1.Clear();
            da.Fill(ds1);
            clientDataGrid.DataSource = ds1.Tables[0];
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameTextBox.Text.Length == 0 || specializationTextBox.Text.Length == 0 || emailTextBox.Text.Length == 0)
                    throw new Exception("One of the text boxes is empty!");
                da.InsertCommand = new SqlCommand("Insert into Doctor(DoctorName, DoctorSpecialization, DoctorEmail, HospitalID) values(@doctorName,@doctorSpecialization,@doctorEmail,@hospitalID)", cs);
                da.InsertCommand.Parameters.Add("@doctorName", SqlDbType.VarChar).Value = nameTextBox.Text.Trim();
                da.InsertCommand.Parameters.Add("@doctorSpecialization", SqlDbType.VarChar).Value = specializationTextBox.Text.Trim();
                da.InsertCommand.Parameters.Add("@doctorEmail", SqlDbType.VarChar).Value = emailTextBox.Text.Trim();
                int id = int.Parse(meniuDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                da.InsertCommand.Parameters.Add("@hospitalID", SqlDbType.Int).Value = id;
                cs.Open();
                da.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Inserted succesfull to the Database");
                cs.Close();
                da.SelectCommand = new SqlCommand("Select * from Doctor where HospitalID=@id", cs);
                id = int.Parse(meniuDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                ds1.Clear();
                da.Fill(ds1);
                clientDataGrid.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error!");
                cs.Close();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                da.DeleteCommand = new SqlCommand("Delete from Doctor where DoctorID=@id", cs);
                int id = int.Parse(clientDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cs.Open();
                da.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Deleted succesfull from the Database");
                cs.Close();
                da.SelectCommand = new SqlCommand("Select * from Doctor where HospitalID=@id", cs);
                id = int.Parse(meniuDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                ds1.Clear();
                da.Fill(ds1);
                clientDataGrid.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error!");
                cs.Close();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameTextBox.Text.Length == 0 || specializationTextBox.Text.Length == 0 || emailTextBox.Text.Length == 0)
                    throw new Exception("One of the text boxes is empty!");
                da.UpdateCommand = new SqlCommand("Update Doctor set DoctorName=@doctorName,DoctorSpecialization=@doctorSpecialization,DoctorEmail=@doctorEmail where DoctorID=@id", cs);
                da.UpdateCommand.Parameters.Add("@doctorName", SqlDbType.VarChar).Value = nameTextBox.Text.Trim();
                da.UpdateCommand.Parameters.Add("@doctorSpecialization", SqlDbType.VarChar).Value = specializationTextBox.Text.Trim();
                da.UpdateCommand.Parameters.Add("@doctorEmail", SqlDbType.VarChar).Value = emailTextBox.Text.Trim();
                int id = int.Parse(clientDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cs.Open();
                da.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("Updated succesfull to the Database");
                cs.Close();
                da.SelectCommand = new SqlCommand("Select * from Doctor where HospitalID=@id", cs);
                id = int.Parse(meniuDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                ds1.Clear();
                da.Fill(ds1);
                clientDataGrid.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error!");
                cs.Close();
            }
        }
    }
}