namespace ApiVendas.Models
{
    public class DatabaseSettingsModels
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string VendedorCollection { get; set; } = null!;

        public string OportunidadeCollection { get; set; } = null!;

    }
}
