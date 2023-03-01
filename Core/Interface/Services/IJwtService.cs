using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;

namespace Core.Interface.Services;

public interface IJwtService
{
    string GetAccessToken(string firstName, string LastName, string email, Role role);
}
