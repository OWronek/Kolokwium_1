public class MedicamentsService : IMedicamentsService
{
    IMedicalRepository _medicalRepository;

    public MedicamentsService(IMedicalRepository medicalRepository)
    {
        _medicalRepository = medicalRepository;
    }

    public IEnumerable<Medicament> GetMedicaments (int idMedicament)
    {
        return _medicalRepository.GetMedicaments(idMedicament);
    }
    
    public int DeletePatient(int idPatient)
    {
        return _medicalRepository.DeletePatient(idPatient);
    }
}