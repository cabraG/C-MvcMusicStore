using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    public class MuUsers
    {
        [Key]
        public int MuUserId { get; set; }

        public string MuUserName { get; set; }


        public string MuPassWord { get; set; }


        public string MuUserType { get; set; }


    }
}