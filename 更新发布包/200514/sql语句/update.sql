
  delete from ProductFirstLevelInfo where ProductFirstLevelId in (5,6,7);
  SET IDENTITY_INSERT ProductFirstLevelInfo  ON;
  insert into ProductFirstLevelInfo (ProductFirstLevelId,ProductFirstLevelName,CreateTime) values (6,'建筑膜',GETDATE());
  insert into ProductFirstLevelInfo (ProductFirstLevelId,ProductFirstLevelName,CreateTime) values (7,'改色膜',GETDATE());
  SET IDENTITY_INSERT ProductFirstLevelInfo  OFF;