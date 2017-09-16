using System.Threading.Tasks;
using Alexa.NET.Management.Vendors;
using Refit;

namespace Alexa.NET.Management
{
    [Headers("Authorization")]
    public interface IVendorApi
    {
        [Get("/vendors")]
        Task<Vendor[]> Get();
    }
}
