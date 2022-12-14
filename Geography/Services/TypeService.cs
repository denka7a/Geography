using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Type;
using Microsoft.AspNetCore.Http;
using System;

namespace Geography.Services
{
    public class TypeService : ITypeService
    {
        private readonly GeographyDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public TypeService(GeographyDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void AddType(TypeViewModel typeViewModel)
        {
            var isExistType = this.context.NatureTypes.FirstOrDefault(x => x.Type == typeViewModel.Type);

            if (isExistType != null)
            {
                return;
            }

            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = this.context.Users.First(x => x.UserName == userName);

            var type = new NatureType()
            {
                Type = typeViewModel.Type,
                UserId = user.Id,
            };

            this.context.Add(type);
            this.context.SaveChanges();
        }

        public ICollection<TypeViewModel> AllTypes()
        {
            var types = this.context.NatureTypes.Select(x => new TypeViewModel
            {
                Type = x.Type,
            }).ToList();

            return types;
        }
    }
}
