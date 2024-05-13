public interface IMedicamentsService
{
    IEnumerable<Medicament> GetMedicaments(int idMedicament);
    int DeletePatient(int idPatient);
}