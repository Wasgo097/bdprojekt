using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
public partial class prac : System.Web.UI.Page
{
    private string str = "Server=db4free.net;Port=3306;Database=cy8h8p1of1;Uid=cy8h8p1of1;pwd=0JpOagXzku;old guids=true;CharSet=utf8;";
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["log"] != null && Request.QueryString["pass"] != null) && (Request.QueryString["pesel"] == null && Request.QueryString["nr"] == null && Request.QueryString["score"] == null))
        {
            MySqlConnection connect;
            MySqlDataReader read;
            connect = new MySqlConnection();
            connect.ConnectionString = str;
            connect.Open();
            string strcom = "SELECT DISTINCT `uprawnienia`,`password` FROM `pracownicy` WHERE `uprawnienia`='" + Request.QueryString["log"] + "' and `password`=SHA2('" + Request.QueryString["pass"] + "',256)";
            MySqlCommand com = new MySqlCommand(strcom, connect);
            read = com.ExecuteReader();
            if (read.HasRows)
            {
                com.CommandText = "SELECT DISTINCT`imie`,`nazwisko` FROM pracownicy WHERE `uprawnienia`= '" + Request.QueryString["log"] + "'";
                read.Close();
                read = com.ExecuteReader();
                if (read.Read())
                {
                    Response.Write("Witaj " + read["imie"] + " " + read["nazwisko"] + "<br/>");
                    Add_form();
                }
            }
            else Response.Write("Nie udalo sie zalogowac");
            read.Close();
            connect.Close();
        }
        else if ((Request.QueryString["log"] == null || Request.QueryString["pass"] == null) && (Request.QueryString["pesel"] == null && Request.QueryString["nr"] == null && Request.QueryString["score"] == null))
        {
            Response.Write("Nie udalo sie zalogowac");
        }
        else
        {
            Response.Write("Dodano ocene<br/>");
            Add_form();
        }
    }
    public void Add_Rating()
    {
        MySqlConnection connect;
        connect = new MySqlConnection();
        //string str = "Server=db4free.net;Database=cy8h8p1of1;Uid=cy8h8p1of1;pwd=0JpOagXzku;old guids=true;CharSet=utf8";
        connect.ConnectionString = str;
        connect.Open();
        string strcom = "INSERT INTO oceny(`iducznia`,`idprzedmiotu`,`wynik`) VALUES('"+ Request.QueryString["pesel"] + "'," + Request.QueryString["nr"] + ","+ Request.QueryString["score"] + ")";
        MySqlCommand com = new MySqlCommand(strcom, connect);
        com.ExecuteNonQuery();
        connect.Close();
    }
    public void Add_form()
    {
        Response.Write("<br/><a href='praclog.aspx' class='logout'>Wyloguj</a><br/><br/>");
        Response.Write(
            "<div>" +
            "W poniższym formularzu wprowadź pesel ucznia, numer przedmiotu z listy poniżej formularza oraz wynik jaki uczeń otrzymał z egzaminu." +
            "<form id='form1' runat='server' action='prac.aspx' method='get'>" +
            "Pesel: <input type='text' name='pesel'/><br />" +
            " Nr przedmiotu: <input type='number' name='nr' /><br />" +
            " Wynik: <input type='number' name='score' /><br />" +
            "<input type='submit' value='Dodaj wynik'/>" +
            "</form>" +
            "</div><br/>" +
            "<table id='list'><tr><th colspan='2'>Lista numerow ocen</th></tr>" +
            "");
        string strcom = "SELECT idprzedmiot,nazwa FROM przedmiot";
        MySqlConnection connect = new MySqlConnection(str);
        connect.Open();
        MySqlCommand com = new MySqlCommand(strcom, connect);
        MySqlDataReader read = com.ExecuteReader();
        while (read.Read())
        {
            Response.Write("<tr><th>"+read["idprzedmiot"] + "</th><th> " + read["nazwa"] + "</th></tr>");
        }
        Response.Write("</table>");
        connect.Close();
        read.Close();
    }
}