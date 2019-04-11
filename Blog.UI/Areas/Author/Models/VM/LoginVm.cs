using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.UI.Areas.Author.Models.VM
{
    public class LoginVm
    {
        [Required(ErrorMessage ="Kullanıcı Adı Hatası!")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Şifre Hatası!")]
        public string Password { get; set; }

    }
}