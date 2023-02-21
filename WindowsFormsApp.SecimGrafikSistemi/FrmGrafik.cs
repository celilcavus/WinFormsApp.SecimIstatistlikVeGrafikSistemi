using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp.SecimGrafikSistemi
{

    public partial class FrmGrafik : Form
    {
        const string connect = @"Data Source=.;Initial Catalog=DbSecimProje;Integrated Security=True";
        SqlConnection context = new SqlConnection(connect);
        public FrmGrafik()
        {
            InitializeComponent();
        }

        private void FrmGrafik_Load(object sender, EventArgs e)
        {
            context.Open();
            SqlCommand comm = new SqlCommand("select ILCEAD from TBLPARTI", context);
            SqlDataReader read = comm.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read[0]);
            }
            context.Close();

            context.Open();

            SqlCommand command = new SqlCommand("SELECT sum(APARTI) , SUM(BPARTI), SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLPARTI", context);
            SqlDataReader read1 = command.ExecuteReader();
            while (read1.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTI", read1[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTI", read1[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTI", read1[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTI", read1[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTI", read1[4]);
            }
            context.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            context.Open();
            SqlCommand command = new SqlCommand($"select * from TBLPARTI WHERE ILCEAD = '{comboBox1.Text}'",context);
            SqlDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                progressBar1.Value = int.Parse(read[2].ToString());
                progressBar2.Value = int.Parse(read[3].ToString());
                progressBar3.Value = int.Parse(read[4].ToString());
                progressBar4.Value = int.Parse(read[5].ToString());
                progressBar5.Value = int.Parse(read[6].ToString());


                lblPartiA.Text = read[2].ToString();
                lblPartiB.Text = read[3].ToString();
                lblPartiC.Text = read[4].ToString();
                lblPartiD.Text = read[5].ToString();
                lblPartiE.Text = read[6].ToString();

            }

            context.Close();
        }
    }
}
