/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2015/1/21 14:59:32                           */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('TC_HotelBrand')
            and   type = 'U')
   drop table TC_HotelBrand
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TC_HotelCityInfo')
            and   type = 'U')
   drop table TC_HotelCityInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TC_HotelList')
            and   type = 'U')
   drop table TC_HotelList
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TC_HotelProvinceInfo')
            and   type = 'U')
   drop table TC_HotelProvinceInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TC_HotelRegionInfo')
            and   type = 'U')
   drop table TC_HotelRegionInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TC_HotelSectionInfo')
            and   type = 'U')
   drop table TC_HotelSectionInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Zhuna_CityAreaInfo')
            and   type = 'U')
   drop table Zhuna_CityAreaInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Zhuna_CityInfo')
            and   type = 'U')
   drop table Zhuna_CityInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Zhuna_CityLable')
            and   type = 'U')
   drop table Zhuna_CityLable
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Zhuna_HotelChain')
            and   type = 'U')
   drop table Zhuna_HotelChain
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Zhuna_HotelInfo')
            and   type = 'U')
   drop table Zhuna_HotelInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Zhuna_SchoolInfo')
            and   type = 'U')
   drop table Zhuna_SchoolInfo
go

/*==============================================================*/
/* Table: TC_HotelBrand                                         */
/*==============================================================*/
create table TC_HotelBrand (
   ID                   int                  not null,
   Name                 nvarchar(100)        not null default '',
   SName                nvarchar(100)        not null default '',
   Logo                 nvarchar(200)        not null default '',
   AddDate              datetime             not null default getdate(),
   constraint PK_TC_HOTELBRAND primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TC_HotelBrand') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TC_HotelBrand' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '酒店品牌信息', 
   'user', @CurrentUser, 'table', 'TC_HotelBrand'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelBrand')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '品牌ID',
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelBrand')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '品牌名称',
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelBrand')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'SName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '品牌缩写',
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'SName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelBrand')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Logo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'Logo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店Logo',
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'Logo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelBrand')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加日期',
   'user', @CurrentUser, 'table', 'TC_HotelBrand', 'column', 'AddDate'
go

/*==============================================================*/
/* Table: TC_HotelCityInfo                                      */
/*==============================================================*/
create table TC_HotelCityInfo (
   ID                   int                  not null,
   Name                 nvarchar(100)        not null default '',
   Pinyin               nvarchar(100)        not null default '',
   "Index"              nvarchar(100)        not null default '',
   ProvinceId           int                  not null default 0,
   constraint PK_TC_HOTELCITYINFO primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TC_HotelCityInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '酒店城市信息', 
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelCityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市ID',
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelCityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市名称',
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelCityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Pinyin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'Pinyin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '拼音',
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'Pinyin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelCityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Index')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'Index'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '索引',
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'Index'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelCityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProvinceId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'ProvinceId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '省份ID',
   'user', @CurrentUser, 'table', 'TC_HotelCityInfo', 'column', 'ProvinceId'
go

/*==============================================================*/
/* Table: TC_HotelList                                          */
/*==============================================================*/
create table TC_HotelList (
   HotelID              int                  not null,
   HotelName            nvarchar(100)        not null default '',
   Flag                 int                  not null default 1,
   AddDate              datetime             not null default '1900-1-1',
   ModifyDate           datetime             not null default '1900-1-1',
   constraint PK_TC_HOTELLIST primary key (HotelID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TC_HotelList') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TC_HotelList' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '酒店信息列表', 
   'user', @CurrentUser, 'table', 'TC_HotelList'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelList')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HotelID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'HotelID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店ID',
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'HotelID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelList')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HotelName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'HotelName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店名称',
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'HotelName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelList')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Flag')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'Flag'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '状态',
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'Flag'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelList')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelList')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ModifyDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'ModifyDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'TC_HotelList', 'column', 'ModifyDate'
go

/*==============================================================*/
/* Table: TC_HotelProvinceInfo                                  */
/*==============================================================*/
create table TC_HotelProvinceInfo (
   ID                   int                  not null,
   Name                 nvarchar(100)        not null default '',
   Pinyin               nvarchar(100)        not null default '',
   "Index"              nvarchar(100)        not null default '',
   constraint PK_TC_HOTELPROVINCEINFO primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TC_HotelProvinceInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '同程酒店城市信息', 
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelProvinceInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '省份ID',
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelProvinceInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '省份名称',
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelProvinceInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Pinyin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo', 'column', 'Pinyin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '拼音',
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo', 'column', 'Pinyin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelProvinceInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Index')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo', 'column', 'Index'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '索引',
   'user', @CurrentUser, 'table', 'TC_HotelProvinceInfo', 'column', 'Index'
go

/*==============================================================*/
/* Table: TC_HotelRegionInfo                                    */
/*==============================================================*/
create table TC_HotelRegionInfo (
   ID                   int                  identity,
   Name                 nvarchar(100)        not null default '',
   Pinyin               nvarchar(100)        not null default '',
   CityId               int                  not null default 0,
   ProvinceId           int                  not null default 0,
   RegionID             int                  not null,
   constraint PK_TC_HOTELREGIONINFO primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TC_HotelRegionInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '行政区域信息', 
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelRegionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '行政区域id',
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelRegionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '名称',
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelRegionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Pinyin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'Pinyin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '拼音',
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'Pinyin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelRegionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CityId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'CityId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市Id',
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'CityId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelRegionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProvinceId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'ProvinceId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '省份id',
   'user', @CurrentUser, 'table', 'TC_HotelRegionInfo', 'column', 'ProvinceId'
go

/*==============================================================*/
/* Table: TC_HotelSectionInfo                                   */
/*==============================================================*/
create table TC_HotelSectionInfo (
   ID                   int                  identity,
   Name                 nvarchar(100)        not null default '',
   CityId               int                  not null default 0,
   ProvinceId           int                  not null default 0,
   SectionID            int                  not null,
   constraint PK_TC_HOTELSECTIONINFO primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TC_HotelSectionInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '热门区域信息', 
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelSectionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelSectionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市名称',
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelSectionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CityId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo', 'column', 'CityId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市ID',
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo', 'column', 'CityId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TC_HotelSectionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProvinceId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo', 'column', 'ProvinceId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '省份Id',
   'user', @CurrentUser, 'table', 'TC_HotelSectionInfo', 'column', 'ProvinceId'
go

/*==============================================================*/
/* Table: Zhuna_CityAreaInfo                                    */
/*==============================================================*/
create table Zhuna_CityAreaInfo (
   areaid               nvarchar(100)        not null,
   cityid               nvarchar(100)        not null default '',
   areaname             nvarchar(100)        not null default '',
   hotelNum             int                  not null default 0,
   ctripareaid          int                  not null default 0,
   adddate              datetime             not null default getdate(),
   id                   int                  identity,
   constraint PK_ZHUNA_CITYAREAINFO primary key (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Zhuna_CityAreaInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '城市行政区域', 
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityAreaInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'cityid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'cityid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市id',
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'cityid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityAreaInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'areaname')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'areaname'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '行政区域名称',
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'areaname'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityAreaInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'hotelNum')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'hotelNum'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店个数',
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'hotelNum'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityAreaInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ctripareaid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'ctripareaid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '携程对应的行政区域id',
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'ctripareaid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityAreaInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'adddate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'adddate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加日期',
   'user', @CurrentUser, 'table', 'Zhuna_CityAreaInfo', 'column', 'adddate'
go

/*==============================================================*/
/* Table: Zhuna_CityInfo                                        */
/*==============================================================*/
create table Zhuna_CityInfo (
   cid                  nvarchar(100)        not null,
   pid                  nvarchar(100)        not null default '',
   pName                nvarchar(100)        not null default '',
   cName                nvarchar(100)        not null default '',
   areaid               int                  not null default 0,
   abcd                 nvarchar(100)        not null default '',
   suoxie               nvarchar(100)        not null default '',
   pinyin               nvarchar(100)        not null default '',
   hotelNum             int                  not null default 0,
   baidu_lat            nvarchar(100)        not null default '',
   baidu_lng            nvarchar(100)        not null default '',
   syncstate            int                  not null default 0,
   adddate              datetime             not null default getdate(),
   ctripcityid          int                  not null default 0,
   constraint PK_ZHUNA_CITYINFO primary key (cid)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Zhuna_CityInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '住哪城市信息', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'cid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'cid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市Id',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'cid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'pid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'pid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '省名称',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'pid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'pName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'pName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '省份名称',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'pName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'cName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'cName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市名称',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'cName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'areaid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'areaid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '行政区域id',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'areaid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'abcd')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'abcd'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '首字母',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'abcd'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'suoxie')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'suoxie'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '缩写',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'suoxie'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'pinyin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'pinyin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '拼音',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'pinyin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'hotelNum')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'hotelNum'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店个数',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'hotelNum'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'baidu_lat')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'baidu_lat'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经度',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'baidu_lat'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'baidu_lng')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'baidu_lng'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '纬度',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'baidu_lng'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'syncstate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'syncstate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店同步状态',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'syncstate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'adddate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'adddate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'adddate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ctripcityid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'ctripcityid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '携程城市id',
   'user', @CurrentUser, 'table', 'Zhuna_CityInfo', 'column', 'ctripcityid'
go

/*==============================================================*/
/* Table: Zhuna_CityLable                                       */
/*==============================================================*/
create table Zhuna_CityLable (
   id                   int                  not null,
   ecityid              nvarchar(100)        not null,
   name                 nvarchar(200)        not null default '',
   classid              int                  not null default 0,
   classname            nvarchar(100)        not null default '',
   roundhotel           nvarchar(Max)        not null default '',
   x                    nvarchar(100)        not null default '',
   y                    nvarchar(100)        not null,
   pinyin               nvarchar(200)        not null,
   adddate              datetime             not null default getdate(),
   cityname             nvarchar(200)        not null default '',
   constraint PK_ZHUNA_CITYLABLE primary key (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Zhuna_CityLable') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Zhuna_CityLable' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '城市地标信息', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ecityid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'ecityid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市ID',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'ecityid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '名称',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'classid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'classid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地标分类id',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'classid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'classname')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'classname'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地标分类名称 ',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'classname'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'roundhotel')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'roundhotel'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'string 附近酒店id',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'roundhotel'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'x')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'x'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经度',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'x'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'y')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'y'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '纬度',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'y'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'pinyin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'pinyin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '拼音',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'pinyin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'adddate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'adddate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'adddate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_CityLable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'cityname')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'cityname'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市名称',
   'user', @CurrentUser, 'table', 'Zhuna_CityLable', 'column', 'cityname'
go

/*==============================================================*/
/* Table: Zhuna_HotelChain                                      */
/*==============================================================*/
create table Zhuna_HotelChain (
   id                   int                  not null,
   lsname               nvarchar(100)        not null default '',
   liansuo              nvarchar(100)        not null default '',
   tupian               nvarchar(200)        not null default '',
   hotelnum             int                  not null default 0,
   ls                   nvarchar(100)        not null default '',
   jibie                int                  not null default 0,
   lsid                 int                  not null default 0,
   adddate              datetime             not null default getdate(),
   ctripbrandid         int                  not null default 0,
   constraint PK_ZHUNA_HOTELCHAIN primary key (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Zhuna_HotelChain') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '酒店连锁品牌', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键Id',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'lsname')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'lsname'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '连锁名称',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'lsname'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'liansuo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'liansuo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '连锁名称',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'liansuo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'tupian')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'tupian'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '图片',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'tupian'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'hotelnum')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'hotelnum'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店个数',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'hotelnum'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ls')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'ls'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '连锁品牌名称',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'ls'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'jibie')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'jibie'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '级别',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'jibie'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'lsid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'lsid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '连锁ID',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'lsid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'adddate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'adddate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'adddate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelChain')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ctripbrandid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'ctripbrandid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '携程酒店品牌id',
   'user', @CurrentUser, 'table', 'Zhuna_HotelChain', 'column', 'ctripbrandid'
go

/*==============================================================*/
/* Table: Zhuna_HotelInfo                                       */
/*==============================================================*/
create table Zhuna_HotelInfo (
   id                   int                  not null,
   hotelname            nvarchar(100)        not null default '',
   address              nvarchar(200)        not null default '',
   picture              nvarchar(500)        not null default '',
   x                    nvarchar(100)        not null default '',
   y                    nvarchar(100)        not null default '',
   min_jiage            int                  not null default 0,
   max_jiangjin         nvarchar(100)        not null default '0',
   liansuo              nvarchar(100)        not null default '',
   xingji               int                  not null default 0,
   fuwu                 nvarchar(Max)        not null default '',
   kaiye                nvarchar(100)        not null default '',
   zhuangxiu            nvarchar(100)        not null default '',
   zaocanPrice          nvarchar(100)        not null default '',
   traffic              nvarchar(Max)        not null default '',
   service              nvarchar(Max)        not null default '',
   canyin               nvarchar(Max)        not null default '',
   card                 nvarchar(500)        not null default '',
   ecityid              nvarchar(100)        not null default '',
   cityname             nvarchar(100)        not null default '',
   df_scores            nvarchar(500)        not null default '',
   df_haoping           nvarchar(500)        not null default '',
   content              nvarchar(Max)        not null default '',
   lng                  nvarchar(100)        not null default '',
   lat                  nvarchar(100)        not null default '',
   baidu_lng            nvarchar(100)        not null default '',
   baidu_lat            nvarchar(100)        not null default '',
   tags                 nvarchar(200)        not null default '',
   esdid                nvarchar(500)        not null default '',
   liansuoid            int                  not null default 0,
   eareaid              nvarchar(100)        not null default '0',
   esdname              nvarchar(500)        not null default '',
   juli                 int                  not null default 0,
   yulejianshen         nvarchar(Max)        not null default '',
   traffic_zhinan       nvarchar(Max)        not null default '',
   jianshu              nvarchar(Max)        not null default '',
   teshe                nvarchar(Max)        not null default '',
   is_kezhan            int                  not null default 0,
   adddate              datetime             not null default getdate(),
   ctriphotelid         int                  not null default 0,
   unionid              int                  not null default 1,
   isindex              int                  not null default 0,
   constraint PK_ZHUNA_HOTELINFO primary key (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Zhuna_HotelInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '酒店信息', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店id ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'hotelname')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'hotelname'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店名称 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'hotelname'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'address')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'address'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店地址 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'address'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'picture')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'picture'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店代表图 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'picture'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'x')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'x'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经度 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'x'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'y')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'y'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '纬度 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'y'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'min_jiage')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'min_jiage'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最低价格 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'min_jiage'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'max_jiangjin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'max_jiangjin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   ' 最大价格 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'max_jiangjin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'liansuo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'liansuo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '连锁酒店名称 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'liansuo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'xingji')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'xingji'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店星级 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'xingji'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'fuwu')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'fuwu'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店服务(以|分隔，如：adsl|card，推荐使用service字段) ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'fuwu'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'kaiye')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'kaiye'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   ' 开业时间 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'kaiye'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'zhuangxiu')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'zhuangxiu'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '装修时间 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'zhuangxiu'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'zaocanPrice')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'zaocanPrice'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '早餐价格 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'zaocanPrice'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'traffic')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'traffic'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '交通位置 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'traffic'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'service')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'service'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '服务 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'service'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'canyin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'canyin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '餐饮信息 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'canyin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'card')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'card'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所支持的银行卡((以|分隔，如：牡丹卡,金穗卡,长城卡,龙卡,太平洋卡,东方卡) ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'card'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ecityid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'ecityid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   ' 城市id ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'ecityid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'cityname')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'cityname'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市名称 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'cityname'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'df_scores')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'df_scores'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '评分（好评+中评-差评=总分） ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'df_scores'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'df_haoping')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'df_haoping'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '评价（以$分隔，如：37$13$2，代表好评$中评$差评） ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'df_haoping'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   ' 酒店简介 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'lng')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'lng'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '经度 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'lng'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'lat')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'lat'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '纬度 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'lat'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'baidu_lng')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'baidu_lng'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '百度地图经度 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'baidu_lng'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'baidu_lat')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'baidu_lat'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '百度地图纬度 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'baidu_lat'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'tags')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'tags'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店tags（以，分隔，如：安静,经济,出行方便,繁华地区,优质服务） ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'tags'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'esdid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'esdid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商业区id ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'esdid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'liansuoid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'liansuoid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '连锁酒店id ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'liansuoid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'eareaid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'eareaid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '行政区域id ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'eareaid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'esdname')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'esdname'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '商业区名称 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'esdname'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'juli')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'juli'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '距离（单位米，如果经纬度不为空，则显示此字段） ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'juli'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'yulejianshen')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'yulejianshen'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '娱乐信息 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'yulejianshen'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'traffic_zhinan')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'traffic_zhinan'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '交通指南 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'traffic_zhinan'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'jianshu')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'jianshu'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店简述 ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'jianshu'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'teshe')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'teshe'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店荣誉（特色） ',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'teshe'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'is_kezhan')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'is_kezhan'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '1为客栈 0为酒店',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'is_kezhan'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'adddate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'adddate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加日期',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'adddate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ctriphotelid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'ctriphotelid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '携程酒店id',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'ctriphotelid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'unionid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'unionid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联盟id',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'unionid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_HotelInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'isindex')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'isindex'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否索引',
   'user', @CurrentUser, 'table', 'Zhuna_HotelInfo', 'column', 'isindex'
go

/*==============================================================*/
/* Table: Zhuna_SchoolInfo                                      */
/*==============================================================*/
create table Zhuna_SchoolInfo (
   id                   int                  identity,
   name                 nvarchar(200)        not null default '',
   ecityid              nvarchar(100)        not null default '',
   classid              int                  not null default 0,
   adddate              datetime             not null default getdate(),
   constraint PK_ZHUNA_SCHOOLINFO primary key (id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Zhuna_SchoolInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '国内学校信息', 
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_SchoolInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_SchoolInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学校名称',
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_SchoolInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ecityid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'ecityid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '城市名称',
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'ecityid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_SchoolInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'classid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'classid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '地标分类',
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'classid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Zhuna_SchoolInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'adddate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'adddate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'Zhuna_SchoolInfo', 'column', 'adddate'
go

