using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Type;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddType(TypeViewModel typeViewModel)
        {
            var isExistType = await this.context.NatureTypes.FirstOrDefaultAsync(x => x.Type == typeViewModel.Type);

            if (isExistType != null)
            {
                return;
            }

            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            var user = await this.context.Users.FirstAsync(x => x.UserName == userName);

            var type = new NatureType()
            {
                Type = typeViewModel.Type,
                UserId = user.Id,
            };

            await this.context.AddAsync(type);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<TypeViewModel>> AllTypes()
        {
            var types =  await this.context.NatureTypes.Select(x => new TypeViewModel
            {
                Type = x.Type,
            }).ToListAsync();

            return types;
        }
    }
}
