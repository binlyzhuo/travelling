if object_id('P_UpdateAreaInfoCodeType') is not null
drop proc P_UpdateAreaInfoCodeType
GO
create proc P_UpdateAreaInfoCodeType
as
update T_XC_HotelAreaInfo set typecode=0;
update T_XC_HotelAreaInfo set typecode=501 where name in(select DISTINCT(name) from [dbo].[T_XC_HotelAreaInfo] where (name like '%地区' or name like '%商贸%' or name like '%商业区%'));
update T_XC_HotelAreaInfo set typecode=502 where name in(select DISTINCT(name) from [dbo].[T_XC_HotelAreaInfo] where (name like '%机场'));
update T_XC_HotelAreaInfo set typecode=506 where name in(select DISTINCT(name) from [dbo].[T_XC_HotelAreaInfo] where (name like '%大学' or name like '%学院'))
update T_XC_HotelAreaInfo set typecode=503 where name in(select DISTINCT(name) from [dbo].[T_XC_HotelAreaInfo] where (name like '%站' or name like '%火车%'))
update T_XC_HotelAreaInfo set typecode=501 where name in(select DISTINCT(name) from [dbo].[T_XC_HotelAreaInfo] where (name like '%中心'))
update T_XC_HotelAreaInfo set typecode=505 where typecode=0;

create table ##tp 
(
 id int identity primary key,
 name nvarchar(200),
 cityid int not null default 0
)

insert into ##tp(name,cityid)
SELECT distinct(Name),CityID from T_XC_HotelAreaInfo where name is not null or name !=''
ORDER by CityID asc

update T_XC_HotelAreaInfo set AreaID = ##tp.id
from ##tp where ##tp.name = T_XC_HotelAreaInfo.Name and ##tp.cityid = T_XC_HotelAreaInfo.CityID
DROP TABLE ##tp