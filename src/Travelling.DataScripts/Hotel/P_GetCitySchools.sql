if object_id('P_GetCitySchools') is not null
drop proc P_GetCitySchools
go

create proc P_GetCitySchools
as

select s.name as SchoolName,cf.CityID,cf.CityName,cf.ABCD as PinYin,cf.ProvinceId,cf.ProvinceName from OTA_TCHotel.dbo.Zhuna_SchoolInfo s
inner join T_CityInfo cf on cf.ZhunaCityID = s.ecityid
select DISTINCT(s.ecityid),cf.CityID,cf.CityName,cf.ABCD as PinYin from OTA_TCHotel.dbo.Zhuna_SchoolInfo s
inner join T_CityInfo cf on cf.ZhunaCityID = s.ecityid
order by cf.ABCD asc


