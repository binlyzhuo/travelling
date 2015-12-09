using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Redis
{
    public class RedisManage
    {
        private static RedisClient redisClient; 
        static RedisManage()
        {
            redisClient = new RedisClient("127.0.0.1",6379);
        }

        static bool Set<T>(string key,T value)
        {
            return redisClient.Set<T>(key,value);
        }

        static T Get<T>(string key)
        {
            return redisClient.Get<T>(key);
        }
    }
}
