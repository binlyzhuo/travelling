using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Admin
{
    /// <summary>
    /// 用户后台登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { set; get; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        public string ValidateCode { set; get; }

        /// <summary>
        /// 是否记住我
        /// </summary>
        public string IsRememberMe { set; get; }

        public bool RememberMe
        {
            get
            {
                if(!string.IsNullOrEmpty(IsRememberMe)&&IsRememberMe.ToLower()=="on")
                {
                    return true;
                }
                return false;
            }
        }
    }
}
