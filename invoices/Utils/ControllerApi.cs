using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using EntityFrameworkPaginateCore;
using AutoMapper;
using invoices.Models;
using Microsoft.EntityFrameworkCore;
using invoices.interfaces;
using System.Reflection;
using invoices.DTOs;

namespace invoices.Utils
{
    public class ControllerApi : CrudMethods
    {

        public ControllerApi(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
