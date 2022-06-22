using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HttpHandlerConfigBug
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            builder.Services.AddHttpClient("foo")
                .ConfigurePrimaryHttpMessageHandler(() =>
                   throw new Exception("This won't actually throw because this code is not run.")
                    );
        }
    }
}
