insert into T_SceneryHotProvince(ProvinceName,ProvinceID,State,AddDate,OrderNo)
select Name,ID,1,GETDATE(),ID from T_SceneryProvince where ParentID=0 and ID in(3,6,8,9,16,22,30,26,28,25)