public interface IMedicalRepository
{
    IEnumerable<Medicament> GetMedicaments(int idMedicament);
    int DeletePatient(int idPatient);
}