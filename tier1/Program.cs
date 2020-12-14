using System;
using System.Collections.Generic;
using System.Text.Json;
using tier1.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace tier1 {
public class Program {
    public static void Main(string[] args) {
        // FileContext fileContext = new FileContext();
        // fileContext.Adults.Clear();
        // IList<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(ClientModel.getInstance().GetAdultJson());
        // for (int i = 0; i < adults.Count; i++)
        // {
        //     fileContext.Adults.Add(adults[i]);
        // }
        // Console.WriteLine(
        //     JsonSerializer.Deserialize<List<Adult>>(ClientModel.getInstance().GetAdultJson()).ToString());
        // fileContext.SaveChanges();
        // Console.WriteLine(ClientModel.getInstance().GetAdultJson());
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}



}








