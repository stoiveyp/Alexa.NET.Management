using System.Threading.Tasks;
using Alexa.NET.Management.Vendors;
using Refit;

namespace Alexa.NET.Management
{
    [Headers("Authorization: Bearer")]
    public interface IVendorApi
    {
        [Get("/vendors")]
        Task<Vendor[]> Get();
    }
}
