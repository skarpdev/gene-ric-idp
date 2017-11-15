using System.Collections.Generic;

namespace kewlthing_csharp.UI
{
    public class PickProviderInput
    {
        public string ReturnUrl { get; set; }
        public IEnumerable<ExternalProvider> ExternalProviders { get; set; }
    }
}