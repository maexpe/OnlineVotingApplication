using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OnlineVotingApplication.Areas.Identity.Data;

// Add profile data for application users by adding properties to the OnlineVotingApplicationUser class
public class OnlineVotingApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string AddressComplement { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public bool IsVoter { get; set; }
}

