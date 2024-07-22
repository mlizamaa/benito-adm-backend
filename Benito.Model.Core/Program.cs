// Dapper Plus
// Doc: https://dapper-plus.net/create-table

// @nuget: Dapper
// @nuget: Microsoft.Data.SqlClient
// @nuget: Z.Dapper.Plus

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

using Dapper;
using Z.Dapper.Plus;
using Z.Dapper.Plus.DapperPlusExpressionMapper;


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using Benito.Model;

public class Program
{	
	public static void Main()
	{
        /* var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("Sql");

            DbContextOptionsBuilder<BenitoDbContext> optionsBuilder = new DbContextOptionsBuilder<BenitoDbContext>()
                .UseSqlServer(connectionString);*/

	}
}

