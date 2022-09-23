using ApiVendas.Models;
namespace ApiVendas.Functions
{

    public class FuncoesOportunidadeController
    {
        // Função que verifica a região de um vendedor antes de realizar a inserção no banco de dados
        public static bool VerificaRegiao(OportunidadeModels data)
        {
            char caracter = '\0';
            bool flag = false;

            // Códigos das cidades de uma região
            string[] codigos = { "12", "27", "16", "13", "29", "23", "53", "32", "52", "21", "51", "50", "31", "15", "25", "41", "26", "22", "24", "43", "33", "11", "14", "42", "35", "28", "17" };

            for (int i = 0; i < codigos.Length; i++)
            {

                // verifica se os codigos dos estados estão correpondente a regiao do vendedor
                caracter = codigos[i].ToCharArray()[0];
               

                caracter = (caracter == '1' || caracter == '2') ? 'N' : (caracter == '3' || caracter == '4') ? caracter = 'S' : (caracter == '5') ? 'C' : '\0';
                
                // atribui o valor da Flag para continuar o inserção de dados
                if (data.Seller != null && flag == false)
                {
                    flag = (caracter == data.Seller.Region.ToString().ToCharArray()[0]) ? true : false;
                   
                }
                else
                {
                    break;
                }

            }
            return flag;
        }
    }

}



