using System;

namespace WebCep
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int CepBR = 10000000;
            Console.WriteLine("Gostaria de rodar a rotina de CEP? S/N");
            if (Console.ReadLine() == "S")
            {
                for (int i = 0000000; i < CepBR; i++)
                {
                    string fmt = "0000-000";
                    string formatString = "{0:0" + fmt + "}";
                    string valor = String.Format(formatString, i);

                    Console.WriteLine(valor);
                    try
                    {
                        var ws = new WSCorreios.AtendeClienteClient();
                        var resposta = ws.consultaCEP(valor);
                        Console.WriteLine();
                        Console.WriteLine("Adicionado no BD > L: {0}, B: {1}, C: {2}, E: {3}.", resposta.end, resposta.bairro, resposta.cidade, resposta.uf);
                        if(resposta.cep.Length >= 0)
                        {
                            Console.WriteLine("Adicionando no Banco");
                            using (var ctx = new Contexto())
                            {
                                Endereco ende = new Endereco() { Cep = int.Parse(resposta.cep), Logradouro = resposta.end, Bairro = resposta.bairro, Cidade = resposta.cidade, UF = resposta.uf } ;
                                ctx.Enderecos.Add(ende);
                                ctx.SaveChanges();
                            }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao efetuar busca do CEP: {0}", ex.Message);
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Pressione qualquer botão para fechar o programa.");
            }
        }
    }
}