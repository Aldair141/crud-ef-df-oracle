using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class PersonaController : Controller
    {
        Entities _db = new Entities();
        // GET: Persona
        public ActionResult Index()
        {
            List<PERSONA> lstPersona = _db.PERSONA.ToList();
            List<PersonaDTO> lstPersonaDTO = new List<PersonaDTO>();

            foreach (PERSONA persona in lstPersona)
            {
                lstPersonaDTO.Add(new PersonaDTO
                {
                    apellidos = persona.APELLIDOS,
                    nombres = persona.NOMBRES,
                    fechaNacimiento = persona.FECHANACIMIENTO,
                    id = persona.ID
                });
            }

            return View(lstPersonaDTO);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonaDTO persona)
        {
            if (ModelState.IsValid)
            {
                PERSONA oPersona = new PERSONA();
                oPersona.NOMBRES = persona.nombres;
                oPersona.APELLIDOS = persona.apellidos;
                oPersona.FECHANACIMIENTO = persona.fechaNacimiento;
                _db.PERSONA.Add(oPersona);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            PERSONA persona = await _db.PERSONA.FindAsync(id);
            if(persona == null)
                return HttpNotFound();

            PersonaDTO perEditar = new PersonaDTO();
            perEditar.id = persona.ID;
            perEditar.nombres = persona.NOMBRES;
            perEditar.apellidos = persona.APELLIDOS;
            perEditar.fechaNacimiento = persona.FECHANACIMIENTO;

            return View(perEditar);
        }

        [HttpPost]
        public async Task<ActionResult> Update(PersonaDTO personaDTO)
        {
            PERSONA persona = new PERSONA();
            persona.ID = personaDTO.id;
            persona.NOMBRES = personaDTO.nombres;
            persona.APELLIDOS = personaDTO.apellidos;
            persona.FECHANACIMIENTO = personaDTO.fechaNacimiento;

            _db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            PERSONA persona = await _db.PERSONA.FindAsync(id);
            if (persona == null)
                return HttpNotFound();

            _db.PERSONA.Remove(persona);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}