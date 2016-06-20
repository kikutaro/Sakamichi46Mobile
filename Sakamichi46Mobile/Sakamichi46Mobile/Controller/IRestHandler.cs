using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakamichi46Mobile.Controller
{
    interface IRestHandler<T>
    {
        T GetProfile(string name);

        List<T> GetAllProfile();

        Task<string> GetOfficialBlog();
    }
}
