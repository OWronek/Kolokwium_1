using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MedicamentsController : ControllerBase
{
    IMedicamentsService _medicamentsService;

    public MedicamentsController(IMedicamentsService medicamentsService)
    {
        _medicamentsService = medicamentsService;
    }

    [HttpGet]
    public IActionResult GetMedicaments(int idMedicament)
    {
        IEnumerable<Medicament> medicaments = _medicamentsService.GetMedicaments(idMedicament);
        if (!medicaments.Any())
        {
            return NotFound();
        }
        return Ok(medicaments);
    }

    [HttpDelete("{idPatient:int}")]
    public IActionResult DeletePatient(int idPatient)
    {
        int affectedCount = _medicamentsService.DeletePatient(idPatient);
        if (affectedCount != 0)
        {
            return Ok($"Deleted: {affectedCount} patients");
        }
    
        return NotFound($"ID: {idPatient} not exists");
    }
}