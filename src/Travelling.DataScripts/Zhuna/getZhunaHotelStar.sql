if object_id('getZhunaHotelStar') is not null
drop FUNCTION getZhunaHotelStar
go

create function getZhunaHotelStar(@xingji int)
returns int
as
begin
declare @star int = 0;
if (@xingji>6 and @xingji<17)
begin
set @star=2
end
else if(@xingji>4 and @xingji<7)
begin
set @star=3
end
else if(@xingji>2 and @xingji<5)
begin
   set @star=4
end
else if(@xingji>0 and @xingji<3)
begin
set @star=5
end
ELSE
BEGIN
 set @star=0
end
return @star;
end
