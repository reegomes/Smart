using System;

namespace WebCep
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Gostaria de rodar a rotina de CEP?");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Digite o CEP: ");
                var valor = Console.ReadLine();
                try
                {
                    var ws = new WSCorreios.AtendeClienteClient();
                    var resposta = ws.consultaCEP(valor);
                    Console.WriteLine();
                    Console.WriteLine("Endereço: {0}", resposta.end);
                    /*Console.WriteLine("Complemento: {0}", resposta.complemento);*/
                    Console.WriteLine("Complemento 2: {0}", resposta.complemento2);
                    Console.WriteLine("Bairro: {0}", resposta.bairro);
                    Console.WriteLine("Cidade: {0}", resposta.cidade);
                    Console.WriteLine("Estado: {0}", resposta.uf);
                    Console.WriteLine("Unidades de Postagem: {0}", resposta.unidadesPostagem);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao efetuar busca do CEP: {0}", ex.Message);
                }
                Console.ReadLine();
            }


        }
    }
}
