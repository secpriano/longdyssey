﻿using IL.DTO;

namespace IL.Interface.BLL
{
    public interface ISpaceshipBLL
    {
        public IEnumerable<SpaceshipDTO> GetAll();
        public SpaceshipDTO GetById(long id);
        public bool Insert(SpaceshipDTO entity);
        public bool Update(SpaceshipDTO entity);
        public bool Delete(long id);
    }
}
