using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp.SecimGrafikSistemi
{
    public partial class FrmOyGiris : Form
    {
        const string connect = @"Data Source=.;Initial Catalog=DbSecimProje;Integrated Security=True";
        SqlConnection context = new SqlConnection(connect);
        public FrmOyGiris()
        {
            InitializeComponent();

        }

        private void btnOyGirisiYap_Click(object sender, EventArgs e)
        {

            if (txtIlceAdi.Text == "")
            {
                MessageBox.Show("Lütfen boş bırakmayınız..");
            }
            context.Open();
            SqlCommand comm = new SqlCommand("insert into TBLPARTI (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", context);
            comm.Parameters.AddWithValue("@p1", txtIlceAdi.Text);
            comm.Parameters.AddWithValue("@p2", txtPartiA.Text);
            comm.Parameters.AddWithValue("@p3", txtPartiB.Text);
            comm.Parameters.AddWithValue("@p4", txtPartiC.Text);
            comm.Parameters.AddWithValue("@p5", txtPartiD.Text);
            comm.Parameters.AddWithValue("@p6", txtPartiE.Text);
            comm.ExecuteNonQuery();
            context.Close();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            new FrmGrafik().Show();

        }

        private void FrmOyGiris_Load(object sender, EventArgs e)
        {

            string[] ilceler = { "adalar", "arnavutköy", "ataşehir", "avcılar", "bağcılar", "bahçelievler", "bakırköy", "başakşehir", "bayrampaşa", "beykoy", "beyoğlu", "büyükçekmece", "çatalca", "çekmeköy", "esenyurt", "eyüpsultan", "fatih", "güngören", "kadıköy", "küçükçekmece", "sancaktepe", "sarıyer", "silivri", "şile", "şişli", "tuzla", "ümraniye", "üsküdar", "zeytinburnu" };

            for (int i = 0; i < ilceler.Length; i++)
            {
                txtIlceAdi.Items.Add(ilceler[i].ToString().ToUpper());
            }
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
