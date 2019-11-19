using Jering.Javascript.NodeJS;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace NodeJSServiceTest
{
    class Program
    {
        static void Main()
        {
            string javascriptModule = @"
module.exports = (callback, x, y) => {  // Module must export a function that takes a callback as its first parameter
    var result = x + y; // Your javascript logic
    callback(null /* If an error occurred, provide an error object or message */, result); // Call the callback when you're done.
}";

            // Create INodeJSService instance
            var services = new ServiceCollection();
            services.AddNodeJS();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            INodeJSService nodeJSService = serviceProvider.GetRequiredService<INodeJSService>();

            // Invoke javascript
            int result = nodeJSService.InvokeFromStringAsync<int>(javascriptModule, args: new object[] { 3, 5 }).Result;

            Console.WriteLine(result);
        }
    }
}
