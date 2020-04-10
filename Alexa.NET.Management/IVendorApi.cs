using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management
{
    public interface IVendorApi
    {
        [Get("/v1/vendors")]
        Task<VendorResponse> Get();
    }
}
