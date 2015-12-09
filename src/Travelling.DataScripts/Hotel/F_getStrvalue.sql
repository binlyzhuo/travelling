drop function getStrvalue
go
CREATE function getStrvalue(@SID int)
returns varchar(2000)
as
begin
declare @str varchar(2000)
set @str=''
select @str=@str+','+rtrim(Name) from T_CityAreaInfo where HotelID=@SID
select @str=right(@str,len(@str)-1) where @str<>''
return @str
end