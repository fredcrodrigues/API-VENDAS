using ApiVendas.Models;

namespace ApiVendas.Functions
{
    public class FuncoesVendedorController
    {

        // Função Roleta que verifica se o o vendedor já está cadastrado em uma oportunidade ou não
        public static VendedorModels Roleta(VendedorModels vendedor, List<OportunidadeModels> oportunidades)
        {

            foreach (var item in oportunidades)
            {

                if (item.Vendedor.Id == vendedor.Id)
                {
                    vendedor = null;
                    break;
                }
            }

            return vendedor;
        }
    }
}
