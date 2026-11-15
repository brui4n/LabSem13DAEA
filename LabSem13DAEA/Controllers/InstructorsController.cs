using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabSem13DAEA.Models;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public InstructorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/InstructorModel
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InstructorModel>>> GetInstructorModel()
    {
        return await _context.Instructores.ToListAsync();
    }

    // GET: api/InstructorModel/5
    [HttpGet("{idinstructor}")]
    public async Task<ActionResult<InstructorModel>> GetInstructorModel(int idinstructor)
    {
        var instructormodel = await _context.Instructores.FindAsync(idinstructor);

        if (instructormodel == null)
        {
            return NotFound();
        }

        return instructormodel;
    }

    // PUT: api/InstructorModel/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idinstructor}")]
    public async Task<IActionResult> PutInstructorModel(int? idinstructor, InstructorModel instructormodel)
    {
        if (idinstructor != instructormodel.IdInstructor)
        {
            return BadRequest();
        }

        _context.Entry(instructormodel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InstructorModelExists(idinstructor))
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

    // POST: api/InstructorModel
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<InstructorModel>> PostInstructorModel(InstructorModel instructormodel)
    {
        _context.Instructores.Add(instructormodel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInstructorModel", new { idinstructor = instructormodel.IdInstructor }, instructormodel);
    }

    // DELETE: api/InstructorModel/5
    [HttpDelete("{idinstructor}")]
    public async Task<IActionResult> DeleteInstructorModel(int? idinstructor)
    {
        var instructormodel = await _context.Instructores.FindAsync(idinstructor);
        if (instructormodel == null)
        {
            return NotFound();
        }

        _context.Instructores.Remove(instructormodel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InstructorModelExists(int? idinstructor)
    {
        return _context.Instructores.Any(e => e.IdInstructor == idinstructor);
    }
}
