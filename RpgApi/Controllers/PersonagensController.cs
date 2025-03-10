using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagensController(DataContext context)
        {
            _context = context;
        }
    

    [HttpGet("{id}")]

    public async Task<IActionResult> GetSingle(int id)
    {
        try
        {
            Personagem p = await _context.TB_PERSONAGENS
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
            return Ok(p);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    } 


    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
    {
        try
        {
            List<Personagem> lista = await _context.TB_PERSONAGENS.ToListAsync();
            return Ok(lista);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
    }
}
