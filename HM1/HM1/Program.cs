using HM1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

DbContextOptions<AcademyContext> configOptions(string DbName)
{
    var configBuilder = new ConfigurationBuilder();
    configBuilder.AddJsonFile("AppSettings.json");

    var config = configBuilder.Build();
    var connectionString = config.GetConnectionString(DbName);

    var dbContextOptionsBuilder = new DbContextOptionsBuilder<AcademyContext>();

    return dbContextOptionsBuilder.UseSqlServer(connectionString).Options;
}

var options = configOptions("Default");

using var context = new AcademyContext(options);

var people = context.People
    .Select(x => new {x.Name,x.Surname,x.Age});

foreach (var item in people)
{
    Console.WriteLine($"{item.Name} {item.Surname} {item.Age}");
}