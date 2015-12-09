using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //RedisClient client = new RedisClient("127.0.0.1",6379);
            //client.Set<int>("pwd",11111);
            //int pwd = client.Get<int>("pwd");
            //Console.WriteLine(pwd);

            //UserInfo userInfo = new UserInfo() { UserName="binlyzhuo",UserPwd="1111" };
            //client.Set<UserInfo>("userinfo", userInfo);
            //var user = client.Get<UserInfo>("userinfo");
            //Console.WriteLine(user.UserName);

            //client.SetEntryInHash("user","userInfo","aaaaaaaaaaa");
            //List<string> list = client.GetHashKeys("user");
            //List<string> list2 = client.GetHashValues("user");
            //List<string> list3 = client.GetAllKeys();

            using (RedisClient client = new RedisClient("127.0.0.1", 6379))
            {
                //Console.WriteLine("redis project!");
                //IRedisTypedClient<Phone> phones = client.As<Phone>();
                //Phone phoneFive = phones.GetValue("5");
                //if(phoneFive==null)
                //{
                //    phoneFive = new Phone
                //    {
                //        Id = 5,
                //        Manufacturer = "apple",
                //        Model = "p6",
                //        Owner = new Person() { 
                //         Age = 20, Id=1, Name="old", Profession="sport",Surname="oldmansurname"
                //        }
                //    };
                //    phones.SetEntry(phoneFive.Id.ToString(), phoneFive);
                //}
                //client.Remove("pwd");
                client.EnqueueItemOnList("name", "zhangsan");
                client.EnqueueItemOnList("name", "lisi");
                long listCount = client.GetListCount("name");

                for (int i = 0; i < listCount; i++)
                {
                    Console.WriteLine(client.DequeueItemFromList("name"));
                }
                Console.WriteLine("list count:{0}", listCount);

                client.PushItemToList("name2", "wangwu");
                client.PushItemToList("name2", "maliu");
                client.PushItemToList("name2", "maliuxxx");
                long listCount2 = client.GetListCount("name2");
                Console.WriteLine("***************");

                for (int i = 0; i < listCount2;i++)
                {
                    Console.WriteLine(client.PopItemFromList("name2"));
                }
                    //Console.WriteLine("listcount2:{0}", listCount2);
                client.AddItemToSet("a3", "1234");
                client.AddItemToSet("a3", "12345");
                client.AddItemToSet("a3", "12346");
                client.AddItemToSet("a3", "12384");
                client.AddItemToSet("a3", "123884");
                HashSet<string> hasset = client.GetAllItemsFromSet("a3");
                long hassetCount = hasset.Count();
                Console.WriteLine(hassetCount);
            }
            Console.Read();


        }
    }
}
