if object_ID('SP_SceneryInfoSyncRecordInit') is not null
drop PROC SP_SceneryInfoSyncRecordInit
GO
create proc SP_SceneryInfoSyncRecordInit
as
insert into T_SceneryInfoSyncRecord(CityID,SyncState,LastSyncDate,SceneryCount)
select ID,0,'1900-1-1',0 from T_SceneryProvince where ParentID>0;