﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using WebApplication1.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices() {}

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }
     


    //---------------------------------------------------------------------------------
    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

    

 

    public List<Country> getCountrys()
    {
        List<Country> countryInList = new List<Country>();
        SqlConnection con = null;


        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        try
        {
            String selectSTR = "SELECT * FROM Countries1";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr2 = cmd.ExecuteReader();// (CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr2.Read())
            {   // Read till the end of the data into a row
                Country c1 = new Country();


                c1.Name = (string)dr2["name1"];
                c1.Lang = (string)dr2["lang"];
                c1.Continent= (string)dr2["continent"];


                countryInList.Add(c1);
            }
            dr2.Close();
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
        return countryInList;
    }


    //public int InsertDiscount(Discounts discount1)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("DBConnectionString"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {
    //        write to log
    //        throw (ex);
    //    }

    //    String cStr = BuildInsertCommandDiscount(discount1);      // helper method to build the insert string

    //    cmd = CreateCommand(cStr, con);             // create the command

    //    try
    //    {
    //        int numEffected = cmd.ExecuteNonQuery(); // execute the command

    //        return numEffected;

    //    }
    //    catch (Exception ex)
    //    {
    //        return 0;
    //        write to log
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            close the db connection
    //            con.Close();
    //        }
    //    }

    //}


    public int PutCountry(Country cPut)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String cStr = BuildPutCommandDiscount(cPut);      // helper method to build the insert string
        cmd = CreateCommand(cStr, con);             // create the command
        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                //close the db connection
                con.Close();
            }
        }
    }

    //--------------------------------------------------------------------
    // 17.  Build PUT Sale Command
    //--------------------------------------------------------------------
    private String BuildPutCommandDiscount(Country cPut)
    {
        String command;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}')", cPut.Lang, cPut.Continent);

        String prefix = "UPDATE Countries1" +
       " SET lang = '" + cPut.Lang + "', continent = '" + cPut.Continent + "'" + " WHERE name1 ='" + cPut.Name+"'";
            


        command = prefix;
        return command;
    }
}


