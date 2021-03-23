using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServerProj.Models;

namespace ServerProj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CentaarController : ControllerBase
    {
        public CentaarContext Context { get; set; }
        public CentaarController(CentaarContext context)
        {
            Context = context;
        }

        //metoda koja vraca sve biblioteke
        [Route("PreuzmiBiblioteke")]
        [HttpGet]
        public async Task<List<Biblioteka>> PreuzmiBiblioteke()
        {
            return await Context.Biblioteke.Include(p => p.Police).ToListAsync();
        }

        
        [Route("PreuzmiPolice/{idBiblioteke}")]
        [HttpGet]
        public async Task<List<Polica>> PreuzmiPolice(int idBiblioteke)
        {
            return await Context.Police.Where(polica=> polica.Biblioteka.ID == idBiblioteke).Include(polica => polica.Knjige ).ToListAsync();
        }

        //metoda koja upisuje nesto u bazu
        [Route("UpisiBiblioteku")]
        [HttpPost]
        public async Task UpisiBiblioteku([FromBody] Biblioteka biblioteka)
        {
            Context.Biblioteke.Add(biblioteka);
            await Context.SaveChangesAsync();
        }

        //metoda za promenu biblioteke
        [Route("IzmeniBiblioteku")]
        [HttpPut]
        public async Task IzmeniBiblioteku([FromBody] Biblioteka biblioteka)
        {
           // var staraBiblioteka = await Context.Biblioteke.FindAsync(biblioteka.ID);
            //staraBiblioteka.NazivBiblioteke = biblioteka.NazivBiblioteke;

            Context.Update<Biblioteka>(biblioteka);
            await Context.SaveChangesAsync();
        }

        //upisemo id vrta i vrt sa tim id se obrise
        [Route("IzbrisiBiblioteku/{idBib}")]
        [HttpDelete]
        public async Task IzbrisiBiblioteku(int idBib)
        {
            //var bib = await Context.FindAsync<Biblioteka>(idBib);
            var bib = await Context.Biblioteke.FindAsync(idBib);
            Context.Remove(bib);
            await Context.SaveChangesAsync();
        }

        //metoda koja upisuje neke police
        [Route("UpisPolice/{idBiblioteke}")]
        [HttpPost]
        public async Task<IActionResult> UpisiPolicu(int idBiblioteke, [FromBody] Polica pol)
        {
            var bibl = await Context.Biblioteke.FindAsync(idBiblioteke);
            pol.Biblioteka = bibl;
            //uslov
            if(pol.ImePolice == "")
            {
                return StatusCode(406);
            }
            else{
                Context.Police.Add(pol);
                await Context.SaveChangesAsync();
                return Ok();
            }
            
        }

        [Route("IzbrisiPolicu")]
        [HttpDelete]
        public async Task IzbrisiPolicu(int id)
        {
            var polica = await Context.Police.FindAsync(id);
            Context.Remove(polica);
            await Context.SaveChangesAsync();
        }


        [Route("UpisKnjige/{idPolice}")]
        [HttpPost]
        public async Task<IActionResult> UpisKnjige(int idPolice, [FromBody] Knjiga knjiga)
        {
            var polica = await Context.Police.FindAsync(idPolice);
            knjiga.Polica = polica;
            //uslov
            if(knjiga.ImeAutora == "" || knjiga.ImeKnjige == "")
            {
                return StatusCode(406);
            }
            else{
                Context.Knjige.Add(knjiga);
                await Context.SaveChangesAsync();
                return Ok();
            }
        }


        [Route("IzbrisiKnjigu/{idKnjige}")]
        [HttpDelete]
        public async Task IzbrisiKnjigu(int idKnjige)
        {
            var knjiga = await Context.Knjige.FindAsync(idKnjige);
            Context.Remove(knjiga);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniKnjigu/{idPolice}")]
        [HttpPut]
        public async Task IzmeniKnjigu(int idPolice, [FromBody] Knjiga knjiga)
        {
            var polica = await Context.Police.FindAsync(idPolice);
            knjiga.Polica = polica;
            // if(knjiga.ImeAutora == "")
            // {

            // }
            Context.Update<Knjiga>(knjiga);
            await Context.SaveChangesAsync();
        }
    }
}
