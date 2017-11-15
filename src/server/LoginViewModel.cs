using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneRicIdp.Server
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        public IEnumerable<ExternalProvider> ExternalProviders { get; set; }
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !string.IsNullOrWhiteSpace(x.DisplayName));
    }
}