using BEndClientes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEndClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AplicationDbContext _Context;
        public ClienteController(AplicationDbContext context)
        {
            _Context = context;

        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
            {

                var ListClientes =await _Context.Clientes.ToListAsync();

                return Ok(ListClientes);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                _Context.Add(cliente);
                await _Context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if (id!=cliente.identificacion)
                {
                    return NotFound();

                }
                _Context.Update(cliente);
                await _Context.SaveChangesAsync();
                return Ok(new { msg= "Cliente Actualizado (Correcto)" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var item = await _Context.Clientes.FindAsync(id);
               
                    if(item!=null)
                      {
                        _Context.Clientes.Remove(item);
                        await _Context.SaveChangesAsync();
                        return Ok(new { msg = "Cliente Eliminado (Correcto)" });
                      }
                      else
                         {
                            return NotFound();
                         }

         
             }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "Error: " + ex.Message });
            }
        }


        // GET: api/<ClienteController>
        [HttpGet ]
        [Route("GetTiposDocumentosInit")]

        public async Task<IActionResult> GetTiposDocumentosInit()
        {
            try
            {

                var tipodoc = await _Context.TipoDocumentos.ToListAsync();

                if (tipodoc != null && tipodoc.Count <= 0) {

                    IList<TipoDocumento> tiposdoc= new List<TipoDocumento>(){
                        new TipoDocumento { idtipodoc = "-1",descripcion = "Seleccionar el tipo de documento..."},
                        new TipoDocumento { idtipodoc = "CC",descripcion = "(CC) Cédula Ciudadanía"},
                        new TipoDocumento { idtipodoc = "NIT",descripcion = "(NIT) Identificación Tributa..."},
                        new TipoDocumento { idtipodoc = "CE",descripcion = "(CE) Cédula Extranjeria"},
                        new TipoDocumento { idtipodoc = "TI", descripcion = "(TI) Tarjeta Identidad" },     
                    };

                     _Context.AddRange(tiposdoc);
                    await _Context.SaveChangesAsync();

                }


                 tipodoc = await _Context.TipoDocumentos.ToListAsync();

                return Ok(tipodoc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
