using System.Data.SqlClient;

public class MedicamentRepository : IMedicalRepository
{
    private IConfiguration _configuration;

    public MedicamentRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Medicament> GetMedicaments(int idMedicament)
    {
        using SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = $"SELECT * FROM medicament JOIN prescription_medicament ON medicament.idmedicament = prescription_medicament.idmedicament JOIN prescription ON prescription_medicament.idprescription = prescription.idprescription WHERE medicament.idmedicament = {idMedicament} ORDER BY DATE DESC";

        SqlDataReader dataReader = command.ExecuteReader();
        List<Medicament> medicaments = new List<Medicament>();
        while (dataReader.Read())
        {
            Medicament medicament = new Medicament
            {
                IdMedicament = (int)dataReader["IdMedicament"],
                Name = dataReader["Name"].ToString(),
                Description = dataReader["Description"].ToString(),
                Type = dataReader["Type"].ToString(),
                IdPrescription = (int)dataReader["IdPrescription"],
                Dose = (int)dataReader["Dose"],
                Details = dataReader["Details"].ToString(),
                Date = dataReader["Date"].ToString()
            };
            medicaments.Add(medicament);
        }

        return medicaments;
    }
    
    public int DeletePatient(int idPatient)
    {
        using SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = $"DELETE FROM prescription WHERE idpatient = {idPatient}";
        command.CommandText = $"DELETE FROM patient WHERE idpatient = {idPatient}";
        
        int affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }
}