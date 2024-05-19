using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_SoccerStandings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoccerTeamController : ControllerBase
    {
        IMediator _mediator;

        public SoccerTeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllSoccerTeams(
            Application.SoccerTeamEntity.Queries.SoccerTeamGetAllRequest soccerTeamGetAllRequest)
        {
            return Ok(await _mediator.Send(soccerTeamGetAllRequest));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdSoccerTeam(int id)
        {
            var result = await _mediator.Send(new Application.SoccerTeamEntity.Queries.SoccerTeamGetByIdRquest { Id = id });

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveSoccerTeam(
            Application.SoccerTeamEntity.Commands.SoccerTeamAddRequest soccerTeamAddRequest)
        {
            try
            {
                var result = await _mediator.Send(soccerTeamAddRequest);
                return Ok($"Equipo registrado correctamente con ID = {result}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha fallado el registro del equipo. Error: {ex.Message}");
            }
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> DeleteSoccerTeam(int id)
        {
            try
            {
                var result = await _mediator.Send(new Application.SoccerTeamEntity.Commands.SoccerTeamRemoveRequest
                {
                    Id = id
                });
                if (result)
                {
                    return Ok($"Equipo eliminado correctamente con ID = {id}");
                }
                else
                {
                    throw new NotSupportedException("Ha fallado la eliminación del equipo.");
                }
            }
            catch (NotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido una excepción no esperada durante la eliminación del equipo. Error: {ex.Message}");
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateSoccerTeam(
            Application.SoccerTeamEntity.Commands.SoccerTeamUpdateRequest soccerTeamUpdateRequest)
        {
            try
            {
                var result = await _mediator.Send(soccerTeamUpdateRequest);
                if (result)
                {
                    return Ok($"Equipo actualizado correctamente con Nombre = {soccerTeamUpdateRequest.Name}");
                }
                else
                {
                    throw new NotSupportedException("Ha fallado la actualización del equipo.");
                }
            }
            catch (NotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ha ocurrido una excepción no esperada durante la actualización del equipo. Error: {ex.Message}");
            }
        }
    }
}
