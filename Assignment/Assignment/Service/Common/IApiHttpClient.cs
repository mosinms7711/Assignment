using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service.Common
{
    public interface IApiHttpClient
    {
        Task<T> GetAsyncRequest<T>(string url);
    }
}
