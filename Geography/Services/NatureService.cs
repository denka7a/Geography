using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Nature;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using System;
using Geography.Models.Type;
using Microsoft.EntityFrameworkCore;

namespace Geography.Services
{
    public class NatureService : INatureService
    {
        private readonly GeographyDbContext contex;
        public NatureService(GeographyDbContext contex)
        {
            this.contex = contex;
        }

        public async Task<ICollection<NatureViewModel>> All()
        {
            var objects = await this.contex.NatureObjects.Select(x => new NatureViewModel
            {
                Id = x.Id,
                Name = x.Name,
                NatureType = x.NatureType.Type,
                URL = x.URL,
                Information = x.Information
            }).ToListAsync();

            return objects;
        }

        public async Task Add(NatureViewModel natureModel)
        {
            var natureType = await this.contex.NatureTypes
                .FirstOrDefaultAsync(x => x.Type.ToLower() == natureModel.NatureType.ToLower());

            if (natureType == null)
            {
                return; 
            }

            var natureObject = new NatureObject()
            {
                Name = natureModel.Name,
                Information = natureModel.Information,
                URL = natureModel.URL,
                NatureType = natureType
            };

            await this.contex.AddAsync(natureObject);
            await this.contex.SaveChangesAsync();
        }

        public async Task<bool> Edit(NatureViewModel model)
        {
            var natureObj = await contex.NatureObjects.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (natureObj == null)
            {
                return false; 
            }

            var natureType = await contex.NatureTypes.FirstOrDefaultAsync(x => x.Type == model.NatureType);

            if (natureType == null)
            {
                return false;
            }

            natureObj.Name = model.Name;
            natureObj.NatureType = natureType;
            natureObj.URL = model.URL;
            natureObj.Information = model.Information;

            this.contex.Update(natureObj);
            await this.contex.SaveChangesAsync();
            return true;
        }

        public async Task<NatureViewModel> natureById(int id)
            => await contex.NatureObjects
            .Where(i => i.Id == id)
            .Select(n => new NatureViewModel
            {
                Id = n.Id,
                Name = n.Name,
                URL = n.URL,
                Information = n.Information,
                NatureType = n.NatureType.Type
            }).FirstOrDefaultAsync();

        public async Task<TypeViewModel> typeByNature(string type) =>
             await contex.NatureTypes
            .Where(t => t.Type == type)
            .Select(nt => new TypeViewModel
            {
                Type = nt.Type,
                User = nt.User,
            }).FirstOrDefaultAsync();

        public async Task Delete(int id)
        {
            var nature = await contex.NatureObjects.FindAsync(id);
            contex.NatureObjects.Remove(nature);
            await contex.SaveChangesAsync();
        }
    }
}
