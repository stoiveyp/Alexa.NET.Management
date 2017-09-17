using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management
{
    public interface IVendorApi
    {
        [Get("/vendors")]
        Task<VendorResponse> Get();
    }
}
