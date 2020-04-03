using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Province_City_CarBLL 的摘要说明
/// </summary>
public class Province_City_CarBLL
{
    private ProvinceDAL pd = null;
    private CityDAL cd = null;
    private CarBrandDAL cbd = null;
    private CarSystemDAL csd = null;
    private CarTypeDAL ctd = null;
	public Province_City_CarBLL()
	{
        pd = new ProvinceDAL();
        cd = new CityDAL();
        cbd = new CarBrandDAL();
        csd = new CarSystemDAL();
        ctd = new CarTypeDAL();
	}
    /// <summary>
    /// 得到省信息
    /// </summary>
    /// <param name="ProvinceId"></param>
    /// <param name="Count"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetProvinceList(int? ProvinceId,out int Count, out List<ProvinceModel> olist)
    {
        olist = new List<ProvinceModel>();
        Count = 0;
        try
        {
            olist = pd.GetProvince(ProvinceId, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("Province_City_CarBLL.GetProvinceList()", ex);
            return Config.ExceptionMsg;
        }
    }
    /// <summary>
    /// 得到城市信息
    /// </summary>
    /// <param name="ProvinceId"></param>
    /// <param name="Count"></param>
    /// <param name="olist"></param>
    /// <returns></returns>
    public string GetCityList(int? ProvinceId, out int Count, out List<CityModel> olist)
    {
        olist = new List<CityModel>();
        Count = 0;
        try
        {
            olist =cd.GetCity(ProvinceId, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("Province_City_CarBLL.GetCityList()", ex);
            return Config.ExceptionMsg;
        }
    }

     /// <summary>
    /// 得到车子品牌信息 一类
    /// </summary>
    /// <param name="CarBrandCode"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public string GetCarBrandList(int? CarBrandCode, out int Count, out List<CarBrandModel> olist)
    {
        olist = new List<CarBrandModel>();
        Count = 0;
        try
        {
            olist = cbd.GetCarBrand(CarBrandCode, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("Province_City_CarBLL.GetCarBrandList()", ex);
            return Config.ExceptionMsg;
        }
    }

    /// <summary>
    ///得到车系信息 二类
    /// </summary>
    /// <param name="CarBrandCode"></param>
    /// <param name="Count"></param>
    /// <returns></returns>
    public string GetCarSystemList(int? CarBrandCode, out int Count,out List<CarSystemModel> olist)
    {
        olist = new List<CarSystemModel>();
        Count = 0;
        try
        {
            olist = csd.GetCarSystem(CarBrandCode, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("Province_City_CarBLL.GetCarSystemList()", ex);
            return Config.ExceptionMsg;
        }
    }
    /// <summary>
    /// 得到车型信息 三类
    /// </summary>
    /// <param name="CarSystemCode"></param>
    /// <param name="Count"></param>
    /// <param name="olist"></param>
    /// <returns></returns>

    public string GetCarTypeList(int? CarSystemCode, out int Count,out List<CarTypeModel>  olist)
    {
        olist = new List<CarTypeModel>();
        Count = 0;
        try
        {
            olist = ctd.GetCarType(CarSystemCode, out Count);
            return Config.Success;
        }
        catch (Exception ex)
        {
            WriteLog.WriteExceptionLog("Province_City_CarBLL.GetCarTypeList()", ex);
            return Config.ExceptionMsg;
        }
    }
}