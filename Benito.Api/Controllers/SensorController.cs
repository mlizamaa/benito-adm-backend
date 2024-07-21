
using Benito.Negocio;
using Benito.Datos;
using Benito.Datos.Dto;
using Benito.Model.Entities.IOT;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Benito.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : BenitoControllerBase<Sensor>
    {
        private readonly IBenitoBaseRepository<Sensor> _benitoBaseRepository;

        public SensorController(IBenitoBaseRepository<Sensor> benitoBaseRepository) : base(benitoBaseRepository)
        {
            _benitoBaseRepository = benitoBaseRepository;
        }
       
    }
}
      