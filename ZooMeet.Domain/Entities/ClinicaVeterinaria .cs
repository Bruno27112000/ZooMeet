namespace ZooMeet.Domain.Entities
{
    public class ClinicaVeterinaria
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Cidade { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public ClinicaVeterinaria(Guid id, string nome, string endereco, string cidade, double latitude, double longitude)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void AtualizarLocalizacao(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}