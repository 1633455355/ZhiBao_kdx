using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// CommentDAL 的摘要说明
/// </summary>
public class CommentDAL
{
    /// <summary>
    /// 添加评论
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string AddCommentInfo(CommentModel oPModel)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Add");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _CommentId = new SqlParameter("@CommentId", (Object)DBNull.Value);
        _CommentId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CommentId);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", oPModel.CompensateNo == null ? (Object)DBNull.Value : oPModel.CompensateNo);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateNo);

        SqlParameter _Content = new SqlParameter("@Content", oPModel.Content == null ? (Object)DBNull.Value : oPModel.Content);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", oPModel.CreatorId);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _Parents_CommentId = new SqlParameter("@Parents_CommentId", oPModel.Parents_CommentId);
        _Parents_CommentId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Parents_CommentId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_CommentInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }

    /// <summary>
    /// 删除评论
    /// </summary>
    /// <param name="oPModel"></param>
    /// <returns></returns>
    public string RemoveCommentInfo(int CommentId)
    {
        List<SqlParameter> sqlparameterlist = new List<SqlParameter>();
        SqlParameter _op = new SqlParameter("@op", "Del");
        _op.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_op);

        SqlParameter _CommentId = new SqlParameter("@CommentId", CommentId);
        _CommentId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CommentId);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", (Object)DBNull.Value);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CompensateNo);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Content.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Content);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_CreatorId);

        SqlParameter _Parents_CommentId = new SqlParameter("@Parents_CommentId", (Object)DBNull.Value);
        _Parents_CommentId.Direction = ParameterDirection.Input;
        sqlparameterlist.Add(_Parents_CommentId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlparameterlist.Add(_result);

        SqlActuator.ExecuteNonQuery("sp_CommentInfo", sqlparameterlist, Config.ConnectionString);

        return _result.Value.ToString();

    }
    /// <summary>
    /// 得到评论
    /// </summary>
    /// <param name="CompensateNo"></param>
    /// <returns></returns>
    public List<CommentModel> GetCommentList(string CompensateNo)
    {
        List<CommentModel> olist = new List<CommentModel>();
        SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
        SqlCommand sqlcommand = new SqlCommand("sp_CommentInfo", sqlConnection);
        sqlcommand.CommandType = CommandType.StoredProcedure;

        SqlParameter _op = new SqlParameter("@op", "Get");
        _op.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_op);


        SqlParameter _CommentId = new SqlParameter("@CommentId", (Object)DBNull.Value);
        _CommentId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CommentId);

        SqlParameter _CompensateNo = new SqlParameter("@CompensateNo", CompensateNo);
        _CompensateNo.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CompensateNo);

        SqlParameter _Content = new SqlParameter("@Content", (Object)DBNull.Value);
        _Content.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Content);


        SqlParameter _CreatorId = new SqlParameter("@CreatorId", (Object)DBNull.Value);
        _CreatorId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_CreatorId);

        SqlParameter _Parents_CommentId = new SqlParameter("@Parents_CommentId", (Object)DBNull.Value);
        _Parents_CommentId.Direction = ParameterDirection.Input;
        sqlcommand.Parameters.Add(_Parents_CommentId);


        SqlParameter _result = new SqlParameter("@result", SqlDbType.VarChar, 10);
        _result.Direction = ParameterDirection.Output;
        sqlcommand.Parameters.Add(_result);

        try
        {
            sqlConnection.Open();
            using (IDataReader idr = sqlcommand.ExecuteReader())
            {
                while (idr.Read())
                {
                    CommentModel oCModel = new CommentModel();
                    if (idr["CommentId"] != DBNull.Value) { oCModel.CommentId = (int)idr["CommentId"]; }
                    if (idr["CompensateNo"] != DBNull.Value) { oCModel.CompensateNo = (string)idr["CompensateNo"]; }
                    if (idr["Content"] != DBNull.Value) { oCModel.Content = (string)idr["Content"]; }
                    if (idr["CreatorId"] != DBNull.Value) { oCModel.CreatorId = (int)idr["CreatorId"]; }
                    if (idr["AdminName"] != DBNull.Value) { oCModel.CreatorName = (string)idr["AdminName"]; }
                    if (idr["Parents_CommentId"] != DBNull.Value) { oCModel.Parents_CommentId = (int)idr["Parents_CommentId"]; }
                    olist.Add(oCModel);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConnection.Close();
        }
        return olist;

    }
}