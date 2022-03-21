using KanbanApi.Filters;
using KanbanApi.Repositories;
using KanbanApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KanbanApi.Controllers
{

    [ApiController]
    [Authorize]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }


        [HttpGet]
        [Route("cards")]
        public async Task<ActionResult<dynamic>> Get()
        {

            var cards = _cardRepository.GetCards();


            return Ok(cards);
        }


        [HttpPost]
        [Route("cards")]
        public async Task<ActionResult<dynamic>> Create([FromBody] Card card)
        {
            try
            {
                _cardRepository.AddCard(card);

                return Created("",card);
            }
            catch (Exception e)
            {
               return BadRequest(e.GetBaseException().Message);
            }
        }

        [HttpPut]
        [Route("cards/{id}")]
        [LogFilter] //Adiciona o Filtro criado para informar no console as ações executadas
        public async Task<ActionResult<dynamic>> Edit([FromRoute] Guid id, [FromBody] Card card)
        {
            if (id != card.Id)
                return BadRequest();
            try
            {
                return Ok(_cardRepository.UpdateCard(id, card));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("cards/{id}")]
        [LogFilter] //Adiciona o Filtro criado para informar no console as ações executadas
        public async Task<ActionResult<dynamic>> Delete([FromRoute] Guid id)
        {
            try
            {
                return Ok(_cardRepository.DeleteCard(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
