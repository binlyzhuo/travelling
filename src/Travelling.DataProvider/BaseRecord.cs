using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.DataLayer.Linq;
using Travelling.DataLayer.Expressions;
using Travelling.ViewModel;
using System.Data;
using System.Data.SqlClient;
using Travelling.FrameWork;


namespace Travelling.DataProvider
{
    /// <summary>
    /// 数据访问基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRecord<T>
        where T:class
    {
        /// <summary>
        /// 默认数据库
        /// </summary>
        protected Database defaultDatabase;

        /// <summary>
        /// 景区数据库
        /// </summary>
        protected Database sceneryDb;

        /// <summary>
        /// 酒店同步数据库
        /// </summary>
        //protected Database hotelSyncRecordDatabase;

        protected Database OTA_HotelDatabase;

        protected Database TravelDatabase;

        protected Database OTA_TCHotelDatabase;
        

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseRecord()
        {
            defaultDatabase = new Database("OTA_HOTEL");
            sceneryDb = new Database("SceneryTicket");
            //hotelSyncRecordDatabase = new Database("HotelSyncRecord");
            OTA_HotelDatabase = new Database("OTA_HOTEL");
            OTA_HotelDatabase.CommandTimeout = 999999999;

            TravelDatabase = new Database("Default");
            //hotelSyncRecordDatabase.CommandTimeout = 999999999;
            defaultDatabase.EnableAutoSelect = true;
            defaultDatabase.CommandTimeout = 999999999;

            OTA_TCHotelDatabase = new Database("OTA_TCHotel");
            OTA_TCHotelDatabase.EnableAutoSelect = true;
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionName"></param>
        public BaseRecord(string connectionName)
        {
            defaultDatabase = new Database(connectionName);
            defaultDatabase.EnableAutoSelect = true;
        }

        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T SingleOrDefault(int id)
        {
            T entity = defaultDatabase.SingleOrDefaultById<T>(id);
            return entity;
        }

        /// <summary>
        /// 计算总个数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            string sql = string.Format("select count(1) from {0}",typeof(T).Name);
            int obj = defaultDatabase.ExecuteScalar<int>(sql);
            return obj;
        }

        /// <summary>
        /// 保存返回主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(T entity)
        {
            int id = Convert.ToInt32(defaultDatabase.Insert(entity));
            return id;
        }

        /// <summary>
        /// 保存不返回主键
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            defaultDatabase.Insert(entity);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IEnumerable<T> Query(Sql sql)
        {
            var items = defaultDatabase.Query<T>(sql);
            return items;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Page<T> Paging(int page,int size,Sql sql)
        {
            return defaultDatabase.Page<T>(page,size,sql);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="items"></param>
        public void InsertBulk(IEnumerable<T> items)
        {
            defaultDatabase.InsertBulk(items);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        public void DeleteMany()
        {
            defaultDatabase.DeleteMany<T>();
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        public List<T> All()
        {
            return defaultDatabase.Query<T>().ToList();
        }

        /// <summary>
        /// 清除表数据
        /// </summary>
        public void Truncate()
        {
            defaultDatabase.Truncate<T>();
        }

        /// <summary>
        /// 修改数据实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            return defaultDatabase.Update(entity);
        }

        public int Update(string tableName)
        {
            defaultDatabase.Update<T>("","");
            return 0;
        }

        public virtual Page<T> Page(BasePageQuery query)
        {
            return null;
        }

        public virtual IEnumerable<T> Query(string sql)
        {
            //throw new Exception("null execute!!");
            return defaultDatabase.Query<T>(sql);
        }

        public virtual int Count(string sql)
        {
            throw new Exception("null execute!!");
        }

        /// <summary>
        /// 统计个数
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <returns></returns>
        public virtual int Count(Sql sqlWhere)
        {
            Sql countSql = Sql.Builder.Select("count(1)").From(typeof(T).Name).Append(sqlWhere);
            return defaultDatabase.ExecuteScalar<int>(countSql);
        }

        /// <summary>
        /// 事务处理
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="items1"></param>
        /// <param name="fun"></param>
        /// <param name="t2"></param>
        public void InsertBulk<T1, T2>(List<T1> items1, Func<T2, int> fun, T2 t2)
        {
            try
            {
                defaultDatabase.BeginTransaction();
                defaultDatabase.InsertBulk(items1);
                fun(t2);
                defaultDatabase.CompleteTransaction();
            }
            catch(Exception ex)
            {
                defaultDatabase.AbortTransaction();
                throw ex;
            }
        }

        public void InsertBulk<T1, T2, T3>(List<T1> items1, List<T2> items2, List<T3> items3)
        {
            try
            {
                defaultDatabase.BeginTransaction();
                defaultDatabase.InsertBulk<T1>(items1);
                defaultDatabase.InsertBulk<T2>(items2);
                defaultDatabase.InsertBulk<T3>(items3);
                defaultDatabase.CompleteTransaction();
            }
            catch(Exception ex)
            {
                defaultDatabase.AbortTransaction();
                throw ex;
            }

        }

        public void InsertBulk<T1, T2, T3,T4>(List<T1> items1, List<T2> items2, List<T3> items3,Func<T4,int> action,T4 t4)
        {
            try
            {
                defaultDatabase.BeginTransaction();

                defaultDatabase.InsertBulk<T1>(items1);
                defaultDatabase.InsertBulk<T2>(items2);
                defaultDatabase.InsertBulk<T3>(items3);
                action(t4);
                defaultDatabase.CompleteTransaction();
            }
            catch (Exception ex)
            {
                defaultDatabase.AbortTransaction();
                
                throw ex;
            }

        }

        public void InsertBulk2<T1, T2, T3, T4>(List<T1> items1, List<T2> items2, List<T3> items3, Func<T4, bool> action, T4 t4)
        {
            try
            {
                defaultDatabase.BeginTransaction();

                //defaultDatabase.InsertBulk<T1>(items1);
                //defaultDatabase.InsertBulk<T2>(items2);
                //defaultDatabase.InsertBulk<T3>(items3);
                this.BulkInsertItems<T1>(items1,typeof(T1).Name);
                this.BulkInsertItems<T2>(items2, typeof(T2).Name);
                this.BulkInsertItems<T3>(items3, typeof(T3).Name);
                action(t4);
                defaultDatabase.CompleteTransaction();
            }
            catch (Exception ex)
            {
                defaultDatabase.AbortTransaction();

                throw ex;
            }

        }

        public void InsertBulk<T1, T2, T3, T4,T5>(List<T1> items1, List<T2> items2, List<T3> items3,List<T4> items4, Func<T5, int> action, T5 t5)
        {
            try
            {
                defaultDatabase.BeginTransaction();
                defaultDatabase.InsertBulk<T1>(items1);
                defaultDatabase.InsertBulk<T2>(items2);
                defaultDatabase.InsertBulk<T3>(items3);
                defaultDatabase.InsertBulk<T4>(items4);
                action(t5);
                defaultDatabase.CompleteTransaction();
            }
            catch (Exception ex)
            {
                defaultDatabase.AbortTransaction();

                throw ex;
            }

        }

        public void InsertBulk<T1, T2, T3, T4>(List<T1> items1, List<T2> items2, List<T3> items3, List<T4> items4)
        {
            try
            {
                defaultDatabase.BeginTransaction();
                defaultDatabase.InsertBulk<T1>(items1);
                defaultDatabase.InsertBulk<T2>(items2);
                defaultDatabase.InsertBulk<T3>(items3);
                defaultDatabase.InsertBulk<T4>(items4);
                
                defaultDatabase.CompleteTransaction();
            }
            catch (Exception ex)
            {
                defaultDatabase.AbortTransaction();

                throw ex;
            }

        }
        public void InsertBulk<T1, T2>(List<T1> items1, List<T2> items2)
        {
            try
            {
                defaultDatabase.BeginTransaction();
                defaultDatabase.InsertBulk<T1>(items1);
                defaultDatabase.InsertBulk<T2>(items2);
                defaultDatabase.CompleteTransaction();
            }
            catch (Exception ex)
            {
                defaultDatabase.AbortTransaction();
                throw ex;
            }

        }

        public virtual List<T> Top(Sql sql)
        {
           
            throw new Exception("null execution!!");
        }

        public virtual IEnumerable<T> Top(int top ,Sql sql)
        {
            return defaultDatabase.Query<T>(top, sql);
        }

        public void InsertBulk<T1, T2, T3, T4>(List<T1> items1, List<T2> items2, Func<T4, int> action, T4 t4)
        {
            throw new Exception("null refernece!!!");
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName"></param>
        public void ExecuteProc(string procName)
        {
            string executeSql = string.Format("execute {0}", procName);
            defaultDatabase.Execute(executeSql);
        }

        public int Execute(string sql)
        {
            return defaultDatabase.Execute(sql);
        }

        public bool Delete(int id)
        {
            return defaultDatabase.Delete<T>(id)>0;
        }

        public string GetQuerySQL(Type type,string tableName)
        {
            StringBuilder querySQL = new StringBuilder("select top 500 ");
            foreach(var p in type.GetProperties())
            {
                querySQL.AppendFormat("{0},",p.Name);
            }
            querySQL.ToString().TrimEnd(',');
            querySQL.AppendFormat(" 1 from {0} ",tableName);
            return querySQL.ToString();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="items"></param>
        /// <param name="tableName"></param>
        public void BulkInsertItems<T>(List<T> items, string tableName)
        {
            DataTable dt = new DataTable();

            dt = items.ToDataTable();
            BulkToDB(dt, tableName);
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tableName"></param>
        public void BulkToDB(DataTable dt, string tableName)
        {
            SqlConnection sqlConn = new SqlConnection(defaultDatabase.ConnectionString);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConn);
            bulkCopy.DestinationTableName = tableName;
            bulkCopy.BatchSize = dt.Rows.Count;

            try
            {
                sqlConn.Open();
                if (dt != null && dt.Rows.Count != 0)
                    bulkCopy.WriteToServer(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                if (bulkCopy != null)
                    bulkCopy.Close();
            }
        }
    }
}
