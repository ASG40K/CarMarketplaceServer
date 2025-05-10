using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewDatabaseModel;
using NewProjectServer.Data;

namespace NewProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController(AppDbContext context, IHostEnvironment environment, 
        UserManager<CarUser> userManager) : ControllerBase
    {
        string pathname = Path.Combine(environment.ContentRootPath, "Data/Cars.csv");


        [HttpPost("Users")]
        public async Task  ImportUsersAsync()
        {
            CarUser user = new()
            {
                UserName = "user",
                Email = "user@email.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };


            IdentityResult x = await userManager.CreateAsync(user, "Passw0rd!");
           int y = await context.SaveChangesAsync();
        }

        }
    }

