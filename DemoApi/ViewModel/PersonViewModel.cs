
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.ViewModel
{
    public class PersonViewModel
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
