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
        [HttpDelete]
        [Route("/reservation/delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _reservationService.Delete(id));
        }

        [HttpGet]
        [Route("/reservation/getAllUsersReservations")]
        public async Task<ActionResult> GetAllUsersReservations(int id)
        {
            return Ok(await _reservationService.GetAllUsersReservations(id));
        }  

        [HttpPut]
        [Route("/reservation/update/{id}")]
        public async Task<ActionResult> UpdateReservation(ReservationDto reservationDto)
        {
            try
            {
                return Ok(await _reservationService.UpdateReservation(reservationDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
