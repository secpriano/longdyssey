using BLL.Entity;
using IL.Interface.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Container
{
    public class PointOfInterestContainer
    {
        private readonly IPointOfInterestDAL db;

        public PointOfInterestContainer(IPointOfInterestDAL data)
        {
            db = data;
        }

        public List<PointOfInterest> GetAll()
        {
            List<PointOfInterest> DTOs = new();

            db.GetAll().ForEach(pointOfInterestDTO =>
            {
                DTOs.Add(new(pointOfInterestDTO));
            });

            return DTOs;
        }
    }
}
