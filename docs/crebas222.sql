/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2014/12/9 21:43:33                           */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('T_AccountInfo')
            and   type = 'U')
   drop table T_AccountInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_AccountLog')
            and   type = 'U')
   drop table T_AccountLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_FriendLink')
            and   type = 'U')
   drop table T_FriendLink
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_HotelBookingOrder')
            and   type = 'U')
   drop table T_HotelBookingOrder
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_JobScheduler')
            and   type = 'U')
   drop table T_JobScheduler
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_JobSchedulerLog')
            and   type = 'U')
   drop table T_JobSchedulerLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_OperatingLog')
            and   type = 'U')
   drop table T_OperatingLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_SettingConfig')
            and   type = 'U')
   drop table T_SettingConfig
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_UnionDetailInfo')
            and   type = 'U')
   drop table T_UnionDetailInfo
go

/*==============================================================*/
/* Table: T_AccountInfo                                         */
/*==============================================================*/
create table T_AccountInfo (
   ID                   int                  identity,
   Name                 nvarchar(50)         not null default '',
   Email                nvarchar(50)         not null default '',
   Password             nvarchar(50)         not null default '',
   State                int                  not null default 1,
   CreateTime           datetime             not null default getdate(),
   UpdateTime           datetime             not null default '1900-1-1',
   constraint PK_T_ACCOUNTINFO primary key (ID),
   constraint AK_UNIQUENAME_T_ACCOUN unique (Name)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_AccountInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_AccountInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '管理员信息表', 
   'user', @CurrentUser, 'table', 'T_AccountInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户名',
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Email')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'Email'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户Email',
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'Email'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Password')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'Password'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '密码',
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'Password'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户状态,0-无效,1-有效,2-锁定',
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '上次修改时间',
   'user', @CurrentUser, 'table', 'T_AccountInfo', 'column', 'UpdateTime'
go

/*==============================================================*/
/* Table: T_AccountLog                                          */
/*==============================================================*/
create table T_AccountLog (
   ID                   numeric              identity,
   AccountId            int                  not null default 0,
   Content              nvarchar(4000)       not null default '',
   CreateTime           datetime             not null default getdate(),
   Creator              nvarchar(50)         not null,
   Type                 int                  not null,
   constraint PK_T_ACCOUNTLOG primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_AccountLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_AccountLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '管理员日志', 
   'user', @CurrentUser, 'table', 'T_AccountLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AccountId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'AccountId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人ID',
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'AccountId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'Content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '日志内容',
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'Content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Creator')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'Creator'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'Creator'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_AccountLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Type')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'Type'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '日志类型',
   'user', @CurrentUser, 'table', 'T_AccountLog', 'column', 'Type'
go

/*==============================================================*/
/* Table: T_FriendLink                                          */
/*==============================================================*/
create table T_FriendLink (
   ID                   int                  identity,
   Name                 nvarchar(100)        not null default '',
   LinkUrl              nvarchar(500)        not null default '',
   State                int                  not null default 1,
   AddDate              datetime             not null default getdate(),
   LinkMan              nvarchar(100)        not null default '',
   Creator              nvarchar(100)        not null default '',
   OrderIndex           int                  not null default 0,
   constraint PK_T_FRIENDLINK primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_FriendLink') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_FriendLink' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '友情链接', 
   'user', @CurrentUser, 'table', 'T_FriendLink'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '网站名称',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LinkUrl')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'LinkUrl'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '链接',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'LinkUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '有效状态',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LinkMan')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'LinkMan'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系人',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'LinkMan'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Creator')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'Creator'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加人',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'Creator'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OrderIndex')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'OrderIndex'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排序',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'OrderIndex'
go

/*==============================================================*/
/* Table: T_HotelBookingOrder                                   */
/*==============================================================*/
create table T_HotelBookingOrder (
   ID                   int                  identity,
   HotelID              int                  not null default 0,
   RoomTypeCode         int                  not null default 0,
   SerialNo             nvarchar(50)         not null default '',
   AddDate              datetime             not null default getdate(),
   Channel              int                  not null default 0,
   Flag                 int                  not null default 0,
   Amount               decimal(18,4)        not null default 0,
   UserID               int                  not null default 0,
   ContactPerson        nvarchar(100)        not null default '',
   ContactPhone         nvarchar(100)        not null default '',
   ContactEmail         nvarchar(100)        not null default '',
   LateArrivalTime      datetime             not null default getdate(),
   RoomTypeName         nvarchar(200)        not null default '',
   CheckInDate          datetime             not null default getdate(),
   CheckOffDate         datetime             not null default getdate(),
   HotelName            nvarchar(200)        not null default '',
   HotelAddress         nvarchar(200)        not null default '',
   RatePlanCategory     int                  not null default 16,
   RoomCount            int                  not null default 1,
   Customers            nvarchar(500)        not null default '',
   UnionID              int                  not null default 0,
   constraint PK_T_HOTELBOOKINGORDER primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_HotelBookingOrder') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '酒店预定记录', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HotelID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'HotelID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店ID',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'HotelID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoomTypeCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'RoomTypeCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型编码',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'RoomTypeCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SerialNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'SerialNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单号',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'SerialNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Channel')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'Channel'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '渠道0-携程',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'Channel'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Flag')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'Flag'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单状态',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'Flag'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Amount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'Amount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '订单金额',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'Amount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'UserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户ID',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'UserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ContactPerson')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'ContactPerson'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系人名称',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'ContactPerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ContactPhone')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'ContactPhone'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系手机号码',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'ContactPhone'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ContactEmail')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'ContactEmail'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系email',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'ContactEmail'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LateArrivalTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'LateArrivalTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最晚到店时间',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'LateArrivalTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoomTypeName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'RoomTypeName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房型名称',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'RoomTypeName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CheckInDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'CheckInDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '入住日期',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'CheckInDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CheckOffDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'CheckOffDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '离店日期',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'CheckOffDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HotelName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'HotelName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店名称',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'HotelName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HotelAddress')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'HotelAddress'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店地址',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'HotelAddress'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RatePlanCategory')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'RatePlanCategory'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '价格计划编码',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'RatePlanCategory'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoomCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'RoomCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '房间间数',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'RoomCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Customers')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'Customers'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '客户',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'Customers'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_HotelBookingOrder')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UnionID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'UnionID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   ' 联盟ID',
   'user', @CurrentUser, 'table', 'T_HotelBookingOrder', 'column', 'UnionID'
go

/*==============================================================*/
/* Table: T_JobScheduler                                        */
/*==============================================================*/
create table T_JobScheduler (
   ID                   int                  identity,
   JobName              nvarchar(200)        not null default '',
   JobMethodName        nvarchar(100)        not null default '',
   CronExpr             nvarchar(100)        not null default '',
   AddDate              datetime             not null default getdate(),
   GroupName            nvarchar(100)        not null default '',
   State                int                  not null default 1,
   ProjectId            int                  not null default 0,
   Remark               nvarchar(500)        not null
      constraint CKC_REMARK_T_JOBSCH check (Remark >= ''),
   constraint PK_T_JOBSCHEDULER primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_JobScheduler') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_JobScheduler' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   ' 计划任务', 
   'user', @CurrentUser, 'table', 'T_JobScheduler'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobScheduler')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobScheduler')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'JobName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'JobName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务名称',
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'JobName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobScheduler')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'JobMethodName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'JobMethodName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '方法名称',
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'JobMethodName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobScheduler')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CronExpr')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'CronExpr'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Cron表达式',
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'CronExpr'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobScheduler')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobScheduler')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GroupName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'GroupName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'GroupName',
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'GroupName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobScheduler')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务状态',
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobScheduler')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProjectId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'ProjectId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '项目id，0-酒店,1-景区',
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'ProjectId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobScheduler')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务描述 信息',
   'user', @CurrentUser, 'table', 'T_JobScheduler', 'column', 'Remark'
go

/*==============================================================*/
/* Table: T_JobSchedulerLog                                     */
/*==============================================================*/
create table T_JobSchedulerLog (
   ID                   int                  identity,
   JobId                int                  not null default 0,
   AddDate              datetime             not null default getdate(),
   StartDate            datetime             not null default '1900-1-1',
   EndDate              datetime             not null default '1900-1-1',
   JobName              nvarchar(200)        not null default '',
   Remark               nvarchar(500)        not null default '',
   constraint PK_T_JOBSCHEDULERLOG primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_JobSchedulerLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'job日志', 
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobSchedulerLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobSchedulerLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'JobId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'JobId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务ID',
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'JobId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobSchedulerLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加运行时间',
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobSchedulerLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StartDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'StartDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '开始运行时间',
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'StartDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobSchedulerLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EndDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'EndDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务结束时间',
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'EndDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobSchedulerLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'JobName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'JobName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务名称',
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'JobName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_JobSchedulerLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '任务备注信息',
   'user', @CurrentUser, 'table', 'T_JobSchedulerLog', 'column', 'Remark'
go

/*==============================================================*/
/* Table: T_OperatingLog                                        */
/*==============================================================*/
create table T_OperatingLog (
   ID                   int                  identity,
   AddDate              datetime             not null default getdate(),
   Content              nvarchar(Max)        not null default '',
   CreatorId            int                  not null default 0,
   Creator              nvarchar(100)        not null default user,
   ProjectType          int                  not null default 0,
   StartDate            datetime             not null default getdate(),
   EndDate              datetime             not null default '1900-1-1',
   IP                   nvarchar(100)        not null default '',
   constraint PK_T_OPERATINGLOG primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_OperatingLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_OperatingLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '系统操作日志', 
   'user', @CurrentUser, 'table', 'T_OperatingLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_OperatingLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_OperatingLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_OperatingLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'Content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作内容',
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'Content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_OperatingLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'CreatorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人ID',
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'CreatorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_OperatingLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Creator')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'Creator'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'Creator'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_OperatingLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProjectType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'ProjectType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '项目类型',
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'ProjectType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_OperatingLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StartDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'StartDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '开始时间',
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'StartDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_OperatingLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EndDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'EndDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '结束时间',
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'EndDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_OperatingLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IP')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'IP'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '客户端IP',
   'user', @CurrentUser, 'table', 'T_OperatingLog', 'column', 'IP'
go

/*==============================================================*/
/* Table: T_SettingConfig                                       */
/*==============================================================*/
create table T_SettingConfig (
   ID                   int                  identity,
   SettingCode          nvarchar(100)        not null default '',
   SettingValue         nvarchar(Max)        not null default '',
   LastUpdate           datetime             not null default '1900-1-1',
   AddDate              datetime             not null default getdate(),
   Remark               nvarchar(500)        not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_SettingConfig') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_SettingConfig' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '网站设置', 
   'user', @CurrentUser, 'table', 'T_SettingConfig'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_SettingConfig')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_SettingConfig')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SettingCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'SettingCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设置代码',
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'SettingCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_SettingConfig')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SettingValue')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'SettingValue'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '设置值',
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'SettingValue'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_SettingConfig')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastUpdate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'LastUpdate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '上次修改时间',
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'LastUpdate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_SettingConfig')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_SettingConfig')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Remark')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'Remark'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注信息',
   'user', @CurrentUser, 'table', 'T_SettingConfig', 'column', 'Remark'
go

/*==============================================================*/
/* Table: T_UnionDetailInfo                                     */
/*==============================================================*/
create table T_UnionDetailInfo (
   ID                   int                  not null,
   UnionName            nvarchar(100)        null,
   Hotel                nvarchar(Max)        null,
   constraint PK_T_UNIONDETAILINFO primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_UnionDetailInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_UnionDetailInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '联盟信息', 
   'user', @CurrentUser, 'table', 'T_UnionDetailInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_UnionDetailInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_UnionDetailInfo', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联盟ID',
   'user', @CurrentUser, 'table', 'T_UnionDetailInfo', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_UnionDetailInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UnionName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_UnionDetailInfo', 'column', 'UnionName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联盟名称',
   'user', @CurrentUser, 'table', 'T_UnionDetailInfo', 'column', 'UnionName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_UnionDetailInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Hotel')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_UnionDetailInfo', 'column', 'Hotel'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '酒店联系方式',
   'user', @CurrentUser, 'table', 'T_UnionDetailInfo', 'column', 'Hotel'
go

