using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;

namespace Travelling.ViewModel.Admin
{
    public class UserUpdatePasswordModel
    {
        [Required]
        public string NewPassword { set; get; }

         [Required]
        public string OldPassword { set; get; }

         [Required]
        public string ConfirmPassword { set; get; }
    }
}
