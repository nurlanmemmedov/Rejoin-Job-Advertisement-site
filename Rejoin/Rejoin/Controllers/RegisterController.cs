using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rejoin.Data;
using Rejoin.ViewModels;
using Rejoin.Models;
using CryptoHelper;


namespace Rejoin.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RejionDBContext _context;

        public RegisterController(RejionDBContext context)
        {
            _context = context;
        }

    }
}