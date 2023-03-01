using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Repository
{
    public interface UserRepository
    {
        User GetUserByEmailOrUsername(string value);
    }
}
