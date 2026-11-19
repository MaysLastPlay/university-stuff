using System;
using System.Collections.Generic;
using System.Text;

namespace WpfLab7.data
{
    public record User(string Name, string Email, string Password, DateTime? BirthDate, string Gender, LogInfo loggedFrom);
}