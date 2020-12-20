using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HousePartyManagement.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        [PersonalData]
        [Column(TypeName =("varchar(45)"))]
        public string Name { get; set; }
        [PersonalData]
        [Column(TypeName = ("varchar(20)"))]
        public string Gender { get; set; }
        [PersonalData]
        [Column(TypeName = ("date"))]
        public DateTime BirthDate { get; set; }
    }
}
