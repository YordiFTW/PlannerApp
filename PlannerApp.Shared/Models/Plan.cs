using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlannerApp.Shared.Enums;

namespace PlannerApp.Shared
{
    public class Plan
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public string Detail { get; set; }

        public PlanCatagoryEnum Catagory { get; set; }



    }

}
