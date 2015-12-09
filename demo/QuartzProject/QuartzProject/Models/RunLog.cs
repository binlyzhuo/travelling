using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace QuartzProject.Models
{
    [PrimaryKey("ID",autoIncrement=true)]
    public class RunLog
    {
        public int ID { set; get; }
        public DateTime AddDate { set; get; }
    }
}