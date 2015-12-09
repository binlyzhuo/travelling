using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.ViewModel;

namespace Travelling.TravelInterface
{
    public interface IDataProvider<T>
        where T:class
    {
        T SingleOrDefault(int id);

        int Save(T entity);

        IEnumerable<T> Query(Sql sql);

        IEnumerable<T> Query(string sql);

        Page<T> Paging(int page,int size,Sql sql);

        void InsertBulk(IEnumerable<T> items);

        List<T> All();

        //List<int> Query();

        void Insert(T entity);

        void Truncate();

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(T entity);

        Page<T> Page(BasePageQuery query);

        /// <summary>
        /// 获取总数据条数
        /// </summary>
        /// <returns></returns>
        int Count();

        int Count(string sql);

        void InsertBulk<T1, T2>(List<T1> items1, List<T2> items2);

        void InsertBulk<T1, T2>(List<T1> items1, Func<T2,int> fun,T2 t2);

        void InsertBulk<T1, T2, T3>(List<T1> items1, List<T2> items2, List<T3> items3);

        //void InsertBulk<T1, T2, T3,T4>(List<T1> items1, List<T2> items2, List<T3> items3,Func<T4> func,T4 t4);
        void InsertBulk<T1, T2, T3, T4>(List<T1> items1, List<T2> items2, List<T3> items3, List<T4> items4);

        void InsertBulk<T1, T2, T3,T4>(List<T1> items1, List<T2> items2, List<T3> items3,Func<T4,int> action,T4 t4);

        void InsertBulk2<T1, T2, T3, T4>(List<T1> items1, List<T2> items2, List<T3> items3, Func<T4, bool> action, T4 t4);

        void InsertBulk<T1, T2, T3, T4>(List<T1> items1, List<T2> items2, Func<T4, int> action, T4 t4);

        void InsertBulk<T1, T2, T3, T4,T5>(List<T1> items1, List<T2> items2, List<T3> items3,List<T4> items4, Func<T5, int> action, T5 t5);

        List<T> Top(Sql sql);

        bool Delete(int id);

        void BulkInsertItems<T>(List<T> items,string tableName);
    }
}
