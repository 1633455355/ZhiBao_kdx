USE [BJG_DB]
GO
/****** Object:  StoredProcedure [dbo].[sp_User_T_Info]    Script Date: 2020/5/15 15:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_User_T_Info]
@op varchar(20),
@UserId int,
@UserName varchar(100),
@CarBrandCode int,
@CarSystemCode int,
@CarTypeCode int,
@Licence varchar(100),
@ProvinceId int,
@CityId int,
@Price numeric(18,2),
@Mobile varchar(100),
@Email varchar(100),
@StoreId int,
@ProductCode varchar(100),
@ProductFirstLevelId int,
@ProductSecondLevelId int,
@ImageList varchar(200),
@MechanicId int,
@Type int,
@Meter float,
@Address varchar(100),
@result varchar(10) output
as
begin
   set @result='0'
   if @op='Add'
   begin
       if @StoreId=0
       or @ProductFirstLevelId=0 or @ProductSecondLevelId=0
       begin
             set @result='-1'  return
       end

       insert into UserInfo(UserName,CarBrandCode,CarSystemCode,CarTypeCode,Licence,ProvinceId,CityId,Price,Mobile,Email,StoreId,ProductCode,ProductFirstLevelId,ProductSecondLevelId,ImageList,MechanicId,Type,Meter,Address)
       values(@UserName,@CarBrandCode,@CarSystemCode,@CarTypeCode,@Licence,@ProvinceId,@CityId,@Price,@Mobile,@Email,@StoreId,@ProductCode,@ProductFirstLevelId,@ProductSecondLevelId,@ImageList,@MechanicId,@Type,@Meter,@Address)
       
       declare @Id int
       set @Id=@@IDENTITY
       set @result=Convert(varchar(10),@Id)
       return
      
      
   end
   
   
end
