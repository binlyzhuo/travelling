if object_id('SP_SceneryInfoQuery') is not null
drop proc SP_SceneryInfoQuery
GO
create proc SP_SceneryInfoQuery
@provinceid int,
@themeid int,
@startlevel int,
@keyword nvarchar(100),
@page int,
@pagesize int
as
select top 10 SceneryID,SceneryName,AmountAdvice,CityID,CityName,ImgBaseUrl,Imgs,AmountAdvice,Themes from T_SceneryInfoDetail where SceneryName like '%'+@keyword+'%' or ProvinceName like '%'+@keyword+'%' or CityName like '%'+@keyword+'%';
