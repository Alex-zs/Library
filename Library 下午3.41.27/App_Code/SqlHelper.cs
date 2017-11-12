using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// SqlHelper 的摘要说明
/// </summary>
public class SqlHelper
{
    static string str = @"server=.;Integrated Security=SSPI;database=Library;";

    public SqlHelper()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public DataTable SqlSelect(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        System.Data.DataTable dt = new DataTable();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    public DataSet DataSet(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        System.Data.DataSet dt = new System.Data.DataSet();
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    public SqlCommand Update(string sql)
    {
        
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        return cmd;

    }
    public SqlCommand InsertInto(string sql)
    {
        
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        return cmd;
    }
    public SqlCommand Delete(string sql)
    {
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        return cmd;
    }

}