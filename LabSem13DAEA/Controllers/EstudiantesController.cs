using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSem13DAEA.Models;

[Route("api/[controller]")]
[ApiController]
public class EstudiantesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public EstudiantesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/EstudianteModel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstudianteModel>>> GetEstudianteModel()
    {
        return await _context.Estudiantes.ToListAsync();
    }

    // GET: api/EstudianteModel/5
    [HttpGet("{idestudiante}")]
    public async Task<ActionResult<EstudianteModel>> GetEstudianteModel(int idestudiante)
    {
        var estudiantemodel = await _context.Estudiantes.FindAsync(idestudiante);

        if (estudiantemodel == null)
        {
            return NotFound();
        }

        return estudiantemodel;
    }

    // PUT: api/EstudianteModel/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idestudiante}")]
    public async Task<IActionResult> PutEstudianteModel(int? idestudiante, EstudianteModel estudiantemodel)
    {
        if (idestudiante != estudiantemodel.IdEstudiante)
        {
            return BadRequest();
        }

        _context.Entry(estudiantemodel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EstudianteModelExists(idestudiante))
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

    // POST: api/EstudianteModel
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<EstudianteModel>> PostEstudianteModel(EstudianteModel estudiantemodel)
    {
        _context.Estudiantes.Add(estudiantemodel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEstudianteModel", new { idestudiante = estudiantemodel.IdEstudiante }, estudiantemodel);
    }

    // DELETE: api/EstudianteModel/5
    [HttpDelete("{idestudiante}")]
    public async Task<IActionResult> DeleteEstudianteModel(int? idestudiante)
    {
        var estudiantemodel = await _context.Estudiantes.FindAsync(idestudiante);
        if (estudiantemodel == null)
        {
            return NotFound();
        }

        _context.Estudiantes.Remove(estudiantemodel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EstudianteModelExists(int? idestudiante)
    {
        return _context.Estudiantes.Any(e => e.IdEstudiante == idestudiante);
    }
}
