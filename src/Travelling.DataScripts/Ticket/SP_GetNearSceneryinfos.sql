if object_id('SP_GetNearSceneryInfos') is not null
drop proc SP_GetNearSceneryInfos
GO
create proc SP_GetNearSceneryInfos
@lat nvarchar(100),
@lng nvarchar(100),
@distance decimal(18,4),
@topcount int
as
declare @sql nvarchar(500);
set @sql = 'select top '+cast(@topcount as nvarchar(50))+' s.* from T_SceneryInfoDetail s with(nolock) where dbo.fnGetDistance('+cast(@lat as nvarchar(50))+','+cast(@lng as nvarchar(50))+',s.Lat,s.Lon)>='+cast(@distance as nvarchar(50));
PRINT @sql
EXEC(@sql)

