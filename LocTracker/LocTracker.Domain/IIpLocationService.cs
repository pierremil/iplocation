using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocTracker.Domain.Service
{
    public static interface IIpLocationService
    {
        static async Task GetIpLocation();
    }
}
