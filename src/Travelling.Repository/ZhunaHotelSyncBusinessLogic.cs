using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Travelling.TravelInterface.Data.Zhuna;
using Travelling.TravelInterface.Repository;
using Ninject;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.OpenApiLogic;
using Travelling.OpenApiEntity.Zhuna;
using Travelling.CommonLibrary;
using Travelling.FrameWork;

namespace Travelling.Repository
{
    public class ZhunaHotelSyncBusinessLogic : BaseZhunaHotelLogic, IZhunaHotelSyncBusinessLogic
    {
        private readonly IZhuna_CityInfoDataProvider zhunaCityData;
        private readonly IZhuna_HotelChainDataProvider zhunaHotelChainData;
        private readonly IZhuna_HotelInfoDataProvider zhunaHotelinfoData;
        private readonly IZhuna_CityAreaInfoDataProvider zhunaCityAreaData;
        private readonly IZhuna_CityLableDataProvider zhunaCityLableData;
        private readonly IZhuna_SchoolInfoDataProvider zhunaSchoolData;
        private readonly IZhuna_RefPointDataProvider refpointData;
        private readonly IZhuna_CBDDataProvider cbdData;
        private readonly IZhuna_CityLableInfoDataProvider zhunacitylableinfoData;

        public ZhunaHotelSyncBusinessLogic()
        {
            zhunaCityData = kernel.Get<IZhuna_CityInfoDataProvider>();
            zhunaHotelChainData = kernel.Get<IZhuna_HotelChainDataProvider>();
            zhunaHotelinfoData = kernel.Get<IZhuna_HotelInfoDataProvider>();
            zhunaCityAreaData = kernel.Get<IZhuna_CityAreaInfoDataProvider>();
            zhunaCityLableData = kernel.Get<IZhuna_CityLableDataProvider>();
            zhunaSchoolData = kernel.Get<IZhuna_SchoolInfoDataProvider>();
            refpointData = kernel.Get<IZhuna_RefPointDataProvider>();
            cbdData = kernel.Get<IZhuna_CBDDataProvider>();
            zhunacitylableinfoData = kernel.Get<IZhuna_CityLableInfoDataProvider>();
        }

        public void ImportZhunaCity(List<Zhuna_CityInfo> items)
        {
            zhunaCityData.Truncate();
            zhunaCityData.InsertBulk(items);
        }

        public void ImportZhunaChains(List<Zhuna_HotelChain> items)
        {
            zhunaHotelChainData.Truncate();
            zhunaHotelChainData.InsertBulk(items);
        }

        public void ImportZhunaCityAreaInfo(Action<string> action)
        {
            action("开始导入行政区域信息");
            ZhunaCityareaReturnEntity repdata;
            var cityinfos = zhunaCityData.All();
            List<Zhuna_CityAreaInfo> areaList = new List<Zhuna_CityAreaInfo>();
            List<Zhuna_CityAreaInfo> areas;
            int total = cityinfos.Count;
            foreach (var city in cityinfos)
            {
                action(string.Format("正在同步:{0},剩余:{1}", city.cName, total));
                repdata = ZhunaHotelServiceLogic.GetCityarea(city.cid);
                if (repdata.retHeader.totalput == 0)
                {
                    continue;
                }
                areas = AutoMapper.Mapper.Map<List<ZhunaCityareaInfo>, List<Zhuna_CityAreaInfo>>(repdata.reqdata);
                areaList.AddRange(areas);
                total = total - 1;
            }

            zhunaCityAreaData.BulkInsertItems<Zhuna_CityAreaInfo>(areaList, typeof(Zhuna_CityAreaInfo).Name);
            action("导入完成");
        }

        public void ImportHotelInfo(bool isDelete, Action<string> action)
        {
            if (isDelete)
            {
                zhunaHotelinfoData.Truncate();
                zhunaCityData.InitSyncState();
            }
            action("开始执行");

            try
            {
                ImportHotelInfos(action);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                action("出错了，正在重启，请稍等");
                Thread.Sleep(5000);
                ImportHotelInfos(action);
            }
        }


        private void ImportHotelInfos(Action<string> action)
        {
            ZhunaHotelSearchCallEntity search = new ZhunaHotelSearchCallEntity();
            var cityinfo = zhunaCityData.GetToSyncHotelInfo();
            ZhunaHotelSearchReturnEntity apiData;
            int totalCount = 0;
            List<Zhuna_HotelInfo> hotelinfos;

            while (cityinfo != null && !string.IsNullOrEmpty(cityinfo.cid))
            {
                action(string.Format("正在同步{0},剩余:{1}", cityinfo.cName, zhunaCityData.GetSyncStateCount(0)));

                search.cityid = cityinfo.cid;
                search.pagesize = 1;
                search.pg = 1;
                apiData = ZhunaHotelServiceLogic.HotelSearch(search);
                totalCount = apiData.retHeader.totalput;

                search.pagesize = totalCount;
                apiData = ZhunaHotelServiceLogic.HotelSearch(search);
                hotelinfos = AutoMapper.Mapper.Map<List<ZhunaHotelInfo>, List<Zhuna_HotelInfo>>(apiData.reqdata);

                zhunaHotelinfoData.BulkInsertItems(hotelinfos, typeof(Zhuna_HotelInfo).Name);

                cityinfo.syncstate = 1;
                zhunaCityData.Update(cityinfo);
                Thread.Sleep(10);
                cityinfo = zhunaCityData.GetToSyncHotelInfo();

            }
            action("同步完成");
        }

        public void ImportCityLables(bool isDelete, Action<string> action)
        {
            if (isDelete)
            {
                zhunaCityData.InitSyncState();
                zhunaCityLableData.Truncate();
            }

            try
            {
                CityLableSyncAction(action);
            }
            catch(Exception ex)
            {
                action("出错了，请稍等，重启中");
                Thread.Sleep(2000);
                CityLableSyncAction(action);
            }
        }

        private void CityLableSyncAction(Action<string> action)
        {
            var cityinfo = zhunaCityData.GetToSyncHotelInfo();
            while (cityinfo != null && !string.IsNullOrEmpty(cityinfo.cid))
            {
                action(string.Format("正在同步{0},剩余:{1}", cityinfo.cName, zhunaCityData.GetSyncStateCount(0)));
                var repData = ZhunaHotelServiceLogic.GetLable(cityinfo.cid.ToString(), 1, 1);


                if (repData.reqdata != null && repData.reqdata.Count > 0)
                {
                    int pageSize = 2000;
                    int pageCount = repData.retHeader.totalput % pageSize == 0 ? repData.retHeader.totalput / pageSize : repData.retHeader.totalput / pageSize + 1;
                    int totalCount = repData.retHeader.totalput;

                    for (int p = 1; p <= pageCount; p++)
                    {
                        repData = ZhunaHotelServiceLogic.GetLable(cityinfo.cid.ToString(), (p - 1) * pageSize + 1, pageSize);

                        var lables = repData.reqdata.Select(u =>
                        {
                            return new Zhuna_CityLable()
                            {
                                classid = u.classid,
                                classname = u.classname.Join(","),
                                ecityid = u.ecityid,
                                adddate = DateTime.Now,
                                lableid = u.id,
                                name = u.name.Join(","),
                                pinyin = u.pinyin,
                                roundhotel = u.roundhotel.Join(","),
                                x = u.x,
                                y = u.y,
                                cityname = cityinfo.cName
                            };
                        }).ToList();
                        zhunaCityLableData.BulkInsertItems(lables, typeof(Zhuna_CityLable).Name);
                        Thread.Sleep(50);
                    }

                }

                cityinfo.syncstate = 1;
                zhunaCityData.Update(cityinfo);
                cityinfo = zhunaCityData.GetToSyncHotelInfo();
                //Thread.Sleep(10);
            }
            action("同步完成");
        }

        public void ImportSchoolInfos(bool isDelete,Action<string> action)
        {
            if(isDelete)
            {
                zhunaCityData.InitSyncState();
                zhunaSchoolData.Truncate();
            }

            var cityinfo = zhunaCityData.GetToSyncHotelInfo();
            while(cityinfo!=null&&!string.IsNullOrEmpty(cityinfo.cid))
            {
                action(string.Format("正在同步{0},剩余:{1}", cityinfo.cName, zhunaCityData.GetSyncStateCount(0)));
                var rep = ZhunaHotelServiceLogic.GetSchool(cityinfo.cid);
                if(rep!=null&&rep.reqdata!=null)
                {
                    var schools = rep.reqdata.Select(u => {
                        return new Zhuna_SchoolInfo() { 
                          adddate = DateTime.Now,
                           classid = u.classid,
                            ecityid = u.ecityid, name = u.name, schoolid = 0
                        };
                    }).ToList();
                    zhunaSchoolData.BulkInsertItems<Zhuna_SchoolInfo>(schools, typeof(Zhuna_SchoolInfo).Name);

                }
                cityinfo.syncstate = 1;
                zhunaCityData.Update(cityinfo);
                cityinfo = zhunaCityData.GetToSyncHotelInfo();
            }

            action("同步完成");
        }

        public void ImportHotelRefpoints(bool isDelete,Action<string> action)
        {
            action("开始同步酒店附近区域信息");
            if(isDelete)
            {
                refpointData.Truncate();
            }

            var records = zhunaCityLableData.GetLablesToIndex();
            List<Zhuna_RefPoint> refpoints;
            Zhuna_RefPoint refpoint;
            while(records!=null&&records.Count>0)
            {
                refpoints = new List<Zhuna_RefPoint>();
                foreach(var r in records)
                {
                    if (string.IsNullOrEmpty(r.roundhotel))
                        continue;
                    r.roundhotel.Split(',').ToList().ForEach(u => {
                        refpoint = new Zhuna_RefPoint() { 
                         ClassName = r.classname, ClassID = r.classid, HotelID = u.ToInt32(), RefPoint = r.name, ZhunaCityId = r.ecityid
                        };
                        refpoints.Add(refpoint);
                    });
                }
                refpointData.BulkInsertItems<Zhuna_RefPoint>(refpoints, typeof(Zhuna_RefPoint).Name);
                zhunaCityLableData.UpdateIndexState(records.Select(u=>u.id).ToList());

                action(string.Format("已同步:{0},剩余:{1}", zhunaCityLableData.GetIndexStateCount(1),zhunaCityLableData.GetIndexStateCount(0)));
                records = zhunaCityLableData.GetLablesToIndex();

                
            }

            action("同步完成");
        }

        public void ImportCityCBD(bool isDelete, Action<string> action)
        {
            if(isDelete)
            {
                cbdData.Truncate();
                zhunaCityData.InitSyncState();
            }

            var cityinfo = zhunaCityData.GetToSyncHotelInfo();
            while (cityinfo != null && !string.IsNullOrEmpty(cityinfo.cid))
            {
                action(string.Format("正在同步{0},剩余:{1}", cityinfo.cName, zhunaCityData.GetSyncStateCount(0)));
                var rep = ZhunaHotelServiceLogic.GetCBD(cityinfo.cid);
                if (rep != null && rep.reqdata != null)
                {
                    var cbds = rep.reqdata.Select(u =>
                    {
                        return new Zhuna_CBD()
                        {
                            cityid = cityinfo.cid, cbdid = u.cbd_id, cbdname = u.CBD_Name, cityname = cityinfo.cName, hotelcount = u.hotelnum, hotelidstring = ""  
                        };
                    }).ToList();
                    zhunaSchoolData.BulkInsertItems<Zhuna_CBD>(cbds, typeof(Zhuna_CBD).Name);

                }
                cityinfo.syncstate = 1;
                zhunaCityData.Update(cityinfo);
                cityinfo = zhunaCityData.GetToSyncHotelInfo();
            }

            action("同步完成");
        }

        public void ImportCityLableInfos(bool isDelete, Action<string> action)
        {
            if (isDelete)
            {
                zhunaCityData.InitSyncState();
                zhunacitylableinfoData.Truncate();
            }

            try
            {
                CityLableInfoSyncAction(action);
            }
            catch (Exception ex)
            {
                action("出错了，请稍等，重启中");
                Thread.Sleep(2000);
                CityLableInfoSyncAction(action);
            }
        }

        public void CityLableInfoSyncAction(Action<string> action)
        {
            var cityinfo = zhunaCityData.GetToSyncHotelInfo();
            while (cityinfo != null && !string.IsNullOrEmpty(cityinfo.cid))
            {
                action(string.Format("正在同步{0},剩余:{1}", cityinfo.cName, zhunaCityData.GetSyncStateCount(0)));
                var repData = ZhunaHotelServiceLogic.GetLable(cityinfo.cid.ToString(), 1, 1);

                if (repData!=null&&repData.reqdata != null && repData.reqdata.Count > 0)
                {
                    int pageSize = 2500;
                    int pageCount = repData.retHeader.totalput % pageSize == 0 ? repData.retHeader.totalput / pageSize : repData.retHeader.totalput / pageSize + 1;
                    int totalCount = repData.retHeader.totalput;

                    for (int p = 1; p <= pageCount; p++)
                    {
                        repData = ZhunaHotelServiceLogic.GetLable(cityinfo.areaid.ToString(), (p - 1) * pageSize + 1, pageSize);
                        if(repData!=null&&repData.reqdata!=null)
                        {
                            var lables = repData.reqdata.Select(u =>
                            {
                                return new Zhuna_CityLableInfo()
                                {
                                    classid = u.classid,
                                    classname = u.classname.Join(","),
                                    ecityid = u.ecityid,
                                    adddate = DateTime.Now,
                                    labelid = u.id,
                                    name = u.name.Join(","),
                                    pinyin = u.pinyin,
                                    roundhotel = u.roundhotel.Join(","),
                                    x = u.x,
                                    y = u.y,
                                    cityname = cityinfo.cName
                                };
                            }).ToList();
                            zhunacitylableinfoData.BulkInsertItems(lables, typeof(Zhuna_CityLableInfo).Name);
                        }
                        Thread.Sleep(100);
                    }

                }

                cityinfo.syncstate = 1;
                zhunaCityData.Update(cityinfo);
                cityinfo = zhunaCityData.GetToSyncHotelInfo();
                //Thread.Sleep(10);
            }
            action("同步完成");
        }
    }
}
