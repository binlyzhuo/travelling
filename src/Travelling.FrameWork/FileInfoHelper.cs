using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.FrameWork
{
    /// <summary>
    /// 文件相关的扩展
    /// </summary>
    public static class FileInfoHelper
    {
        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileExtends(this string fileName)
        {

            return fileName.Substring(fileName.LastIndexOf(".")+1, fileName.Length - fileName.LastIndexOf(".")-1).ToLower();
        }
    }
}
