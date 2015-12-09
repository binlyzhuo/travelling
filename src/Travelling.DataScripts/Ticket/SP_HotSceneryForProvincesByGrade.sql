if object_id('SP_HotSceneryForProvincesByGrade') is not null
drop proc SP_HotSceneryForProvincesByGrade
GO
create proc SP_HotSceneryForProvincesByGrade
as
WITH ct as
(
  select ROW_NUMBER() over(PARTITION by sf.ProvinceId order by sf.GradeInt desc) as num,sf.SceneryName,sf.SceneryId,sf.Imgs,sf.ImgBaseUrl,sf.ProvinceId,sf.AmountAdvice from T_SceneryInfoDetail sf
  inner join T_SceneryProvinceDetailInfo sp on sf.ProvinceId = sp.ID
  where sp.ParentID=0 and sp.IsHot=1 
)
SELECT SceneryName,SceneryId,ImgBaseUrl,Imgs,ProvinceId,AmountAdvice from ct where num<=15;
select ID,Name,SyncState from T_SceneryProvinceDetailInfo where ParentID=0 and IsHot=1;
