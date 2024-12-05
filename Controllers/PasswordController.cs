using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI2.Data;

namespace UserManagementAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly UserManagementDbContext _context;

        public PasswordController(UserManagementDbContext context)
        {
            _context = context;
        }
    }
}