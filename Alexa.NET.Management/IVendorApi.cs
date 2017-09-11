using Alexa.NET.Management.Vendors;
using Refit;

namespace Alexa.NET.Management
{
    [Headers("Authorization: Bearer")]
    public interface IVendorApi
    {
        Vendor[] Get();
    }
}
