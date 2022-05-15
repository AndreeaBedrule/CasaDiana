using CasaDiana.Dto;
using CasaDiana.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CasaDiana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        [Route("/addReservation")]
        public async Task<ActionResult> AddReservation(ReservationDto reservationDto)
        {
            return Ok(await _reservationService.AddReservation(reservationDto));
        }

        [HttpGet]
        [Route("/getAllReservations")]
        public async Task<ActionResult> GetAllReservations()
        {
            return Ok(await _reservationService.GetAllReservations());
        }


    }
}
