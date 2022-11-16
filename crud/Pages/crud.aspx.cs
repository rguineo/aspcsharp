using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud.Pages
{
    public partial class crud : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener el ID

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                    tbdate.TextMode = TextBoxMode.DateTime;

                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo usuario";
                            this.btnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta usuario";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Actualizar usuario";
                            this.btnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar usuario";
                            this.btnDelete.Visible = true;
                            break;
                    }
                }
            }
        }
        void CargarDatos()
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbname.Text = row[1].ToString();
            tblastname.Text = row[2].ToString();
            DateTime d = (DateTime)row[3];
            tbdate.Text = d.ToString("dd/MM/yyyy");
            tbaddress.Text = row[4].ToString();

            con.Close();
        }


        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = tbname.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = tblastname.Text;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = tbaddress.Text;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = tbdate.Text;

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("index.aspx");
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = tbname.Text;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar).Value = tblastname.Text;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = tbaddress.Text;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = tbdate.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("index.aspx");
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("index.aspx");
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }



    }
}