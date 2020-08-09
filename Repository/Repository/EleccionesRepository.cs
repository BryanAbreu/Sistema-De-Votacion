using System;
using System.Collections.Generic;
using System.Text;
using Database.Models;

using Repository.RepositoryBase;

namespace Repository.Repository
{
    public class EleccionesRepository : RepositoryBase<Elecciones, proyectoFinalContext>
    {
        public EleccionesRepository(proyectoFinalContext context) : base(context)
        {
        }
    }
}
