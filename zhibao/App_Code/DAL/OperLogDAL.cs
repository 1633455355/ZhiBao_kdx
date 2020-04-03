using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// OperLogDAL 的摘要说明
/// </summary>
public class OperLogDAL
{
	public OperLogDAL()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public string AddOperLog(int AdminId, string Module, string OpeDes)
    {
        string sql="insert into dbo.OpeLogInfo(AdminId,Module,OpeDes)values("+AdminId+",'"+Module+"','"+OpeDes+"')";
        
        int temp =SqlActuator.ExecuteNonQuery(sql,Config.ConnectionString);
        return temp.ToString();
    }
}