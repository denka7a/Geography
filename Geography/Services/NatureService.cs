using Geography.Contracts;
using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Models.Nature;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Xml.Linq;
using System;
using Geography.Models.Type;

namespace Geography.Services
{
    public class NatureService : INatureService
    {
        private readonly GeographyDbContext contex;
        public NatureService(GeographyDbContext contex)
        {
            this.contex = contex;
        }

        public ICollection<NatureViewModel> All()
        {
            var objects = this.contex.NatureObjects.Select(x => new NatureViewModel
            {
                Id = x.Id,
                Name = x.Name,
                NatureType = x.NatureType.Type,
                URL = x.URL,
                Information = x.Information
            }).ToList();

            return objects;
        }

        public void Add(NatureViewModel natureModel)
        {
            var natureType = this.contex.NatureTypes.FirstOrDefault(x => x.Type.ToLower() == natureModel.NatureType.ToLower());

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

            this.contex.Add(natureObject);
            this.contex.SaveChanges();
        }

        public bool Edit(NatureViewModel model)
        {
            var natureObj = contex.NatureObjects.FirstOrDefault(x => x.Id == model.Id);

            if (natureObj == null)
            {
                return false; 
            }

            var natureType = contex.NatureTypes.FirstOrDefault(x => x.Type == model.NatureType);

            if (natureType == null)
            {
                return false;
            }

            natureObj.Name = model.Name;
            natureObj.NatureType = natureType;
            natureObj.URL = model.URL;
            natureObj.Information = model.Information;

            this.contex.Update(natureObj);
            this.contex.SaveChanges();
            return true;
        }

        public NatureViewModel natureById(int id)
            => contex.NatureObjects
            .Where(i => i.Id == id)
            .Select(n => new NatureViewModel
            {
                Id = n.Id,
                Name = n.Name,
                URL = n.URL,
                Information = n.Information,
                NatureType = n.NatureType.Type
            }).FirstOrDefault();

        public TypeViewModel typeByNature(string type) =>
            contex.NatureTypes
            .Where(t => t.Type == type)
            .Select(nt => new TypeViewModel
            {
                Type = nt.Type,
                User = nt.User,
            }).FirstOrDefault();

        public void Delete(int id)
        {
            var nature = contex.NatureObjects.Find(id);
            contex.NatureObjects.Remove(nature);
            contex.SaveChanges();
        }
    }
}
