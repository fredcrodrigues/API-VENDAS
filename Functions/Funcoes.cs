using ApiVendas.Models;
namespace ApiVendas.Functions;


    public class Funcoes
    {
        public static VendedorModels Roleta(VendedorModels vendedor, List<OportunidadeModels> oportunidades){
        Console.WriteLine(vendedor);
            foreach (var item in oportunidades)
            {

                if (item.Vendedor.Id == vendedor.Id)
                {
                    vendedor = null;
                }
            }
               
            return vendedor;
        }
    }

