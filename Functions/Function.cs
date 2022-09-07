﻿using ApiVendas.Models;
namespace ApiVendas.Functions
{

    public class Function
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
        // Função que verifica a região de um vendedor antes de realizar a inserção no banco de dados
        public static bool VerificaRegiao(OportunidadeModels data)
        {
            char caracter = '\0';
            bool flag = false;

            // Códigos das cidades de uma região
            string[] codigos = { "12", "27", "16", "13", "29", "23", "53", "32", "52", "21", "51", "50", "31", "15", "25", "41", "26", "22", "24", "43", "33", "11", "14", "42", "35", "28", "17" };

            for (int i = 0; i < codigos.Length; i++)
            {

                caracter = codigos[i].ToCharArray()[0];

                caracter = (caracter == '1' || caracter == '2') ? 'N' : (caracter == '3' || caracter == '4') ? caracter = 'S' : (caracter == '5') ? 'C' : '\0';

                if (data.Vendedor != null && flag == false)
                {
                    flag = (caracter == data.Vendedor.Regiao.ToString().ToCharArray()[0]) ? true : false;
                    break;

                }

            }
            return flag;
        }
    }

}



