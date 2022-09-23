using Library.Core.Abstractions;
using Library.Core.Abstractions.Services;
using Library.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public static class CoreModule
    {
        public static void RegisterCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IRentalEntryService, RentalEntryService>();
            services.AddScoped<IQueueService, QueueService>();
            services.AddScoped<IMessagingService, MessagingService>();

        }
    }
}
