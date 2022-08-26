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
    public static bool VerifcaRegiao(OportunidadeModels data)
    {
        bool flag = false;


            string[] codigos = { "12", "27", "16", "13", "29", "23", "53", "32", "52", "21", "51", "50", "31", "15", "25", "41", "26", "22", "24", "43", "33", "11", "14", "42", "35", "28", "17" };

            for (int i = 0; i < codigos.Length; i++){

                char caracter = codigos[i].ToCharArray()[0];

                flag = (caracter.ToString() == data.Vendedor.Regiao.ToString() && data.Vendedor == null) ?  true : false;
            

            }

            return flag;
        }
    }

