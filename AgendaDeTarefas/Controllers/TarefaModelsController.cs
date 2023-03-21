using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaDeTarefas.Data;
using AgendaDeTarefas.Models;

namespace AgendaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaModelsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public TarefaModelsController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaModel>>> GetTarefaModel()
        {
            return await _context.TarefaModel.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> GetTarefaModel(int id)
        {
            var tarefaModel = await _context.TarefaModel.FindAsync(id);

            if (tarefaModel == null)
            {
                return NotFound();
            }

            return tarefaModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefaModel(int id, TarefaModel tarefaModel)
        {
            if (id != tarefaModel.id)
            {
                return BadRequest();
            }

            _context.Entry(tarefaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> PostTarefaModel(TarefaModel tarefaModel)
        {
            if (tarefaModel.data < DateTime.Now)
            {
                return BadRequest("DATA INVALIDA");
            }
            if (tarefaModel.fim - tarefaModel.inicio > 5)
            {
                return BadRequest("TEMPO MAXIMO DE TAREFA PERMITIDO = 5 horas");
            }
         
            _context.TarefaModel.Add(tarefaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefaModel", new { id = tarefaModel.id }, tarefaModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaModel(int id)
        {
            var tarefaModel = await _context.TarefaModel.FindAsync(id);
            if (tarefaModel == null)
            {
                return NotFound();
            }

            _context.TarefaModel.Remove(tarefaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaModelExists(int id)
        {
            return _context.TarefaModel.Any(e => e.id == id);
        }
    }
}
