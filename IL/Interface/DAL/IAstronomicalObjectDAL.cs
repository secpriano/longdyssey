﻿using IL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL.Interface.DAL
{
    public interface IAstronomicalObjectDAL
    {
        public List<AstronomicalObjectDTO> GetAll();
    }
}
