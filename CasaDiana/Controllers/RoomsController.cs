using CasaDiana.Dto;
using CasaDiana.Models;
using CasaDiana.Repository.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CasaDiana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        [Route("/addRoom")]
        public async Task<ActionResult> AddRoom(RoomDto roomDto)
        {
            try
            {
                return Ok(await _roomService.AddRoom(roomDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("/getAllRooms")]
        public async Task<ActionResult> GetAllRooms()
        {
            return Ok(await _roomService.GetAllRooms());
        }

        [HttpDelete]
        [Route("/room/delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           return Ok(await _roomService.Delete(id));
        }

        [HttpPut]
        [Route("/room/update/{id}")]
        public async Task<ActionResult> Update(RoomDto roomDto)
        {
            return Ok(await _roomService.Update(roomDto));
        }

        [HttpGet]
        [Route("/getOneRoom")]
        public async Task<ActionResult> GetOneRoom(int id)
        {
            return Ok(await _roomService.GetOne(id));
        }

        [HttpGet]
        [Route("/getAvailableRooms")]
        public async Task<ActionResult> GetAvailableRooms(DateTime check_in, DateTime check_out)
        {
            return Ok(await _roomService.GetAllAvailableRooms(check_in, check_out));
        }


    }


    }
