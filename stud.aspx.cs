using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
public partial class stud : System.Web.UI.Page
{
    private string str = "Server=db4free.net;Port=3306;Database=cy8h8p1of1;Uid=cy8h8p1of1;pwd=0JpOagXzku;old guids=true;CharSet=utf8;Allow User Variables=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["log"] != null && Request.QueryString["pass"] != null)
        {
            MySqlConnection connect;
            MySqlDataReader read;
            connect = new MySqlConnection();
            connect.ConnectionString = str;
            connect.Open();
            string strcom = "SELECT DISTINCT `pesel`,`password` FROM `uczniowie` WHERE `pesel`='" + Request.QueryString["log"] + "' and `password`=SHA2('" + Request.QueryString["pass"] + "',256)";
            MySqlCommand com = new MySqlCommand(strcom, connect);
            read = com.ExecuteReader();
            if (read.HasRows)
            {
                com.CommandText = "SELECT DISTINCT`imie`,`nazwisko` FROM uczniowie WHERE `pesel`= '" + Request.QueryString["log"] + "'";
                read.Close();
                read = com.ExecuteReader();
                if (read.Read())
                {
                    Response.Write("Witaj " + read["imie"] + " " + read["nazwisko"] + "<br/>");
                    Response.Write("<br/><a href='studlog.aspx' class='logout'>Wyloguj</a><br/><br/>");
                    com.CommandText = "Select p.nazwa,o.wynik from oceny o join uczniowie u on u.pesel=o.iducznia JOIN przedmiot p on p.idprzedmiot=o.idprzedmiotu WHERE u.pesel = '" + Request.QueryString["log"] + "'";
                    read.Close();
                    read = com.ExecuteReader();
                    Response.Write("<table id='mark'><tr><th>Przedmiot</th><th>Wynik</th></tr>");
                    while (read.Read())
                    {
                        Response.Write("<tr><th> " + read["nazwa"] + " </th><th> " + read["wynik"] + "</th></tr>");
                    }
                    Response.Write("</table>");
                }
            }
            else Response.Write("Nie udalo sie zalogowac");
            read.Close();
            connect.Close();
        }
    }
}