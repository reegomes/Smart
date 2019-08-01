using System;
using System.ComponentModel.DataAnnotations;

namespace WebCep
{
    public class Endereco
    {
        public Endereco()
        {
        }

        public Endereco(int cep, string logradouro, string bairro, string cidade, string uF)
        {
            Cep = cep;
            Logradouro = logradouro ?? throw new ArgumentNullException(nameof(logradouro));
            Bairro = bairro ?? throw new ArgumentNullException(nameof(bairro));
            Cidade = cidade ?? throw new ArgumentNullException(nameof(cidade));
            UF = uF ?? throw new ArgumentNullException(nameof(uF));
        }

        public Endereco(int id, int cep, string logradouro, string bairro, string cidade, string uF)
        {
            Id = id;
            Cep = cep;
            Logradouro = logradouro ?? throw new ArgumentNullException(nameof(logradouro));
            Bairro = bairro ?? throw new ArgumentNullException(nameof(bairro));
            Cidade = cidade ?? throw new ArgumentNullException(nameof(cidade));
            UF = uF ?? throw new ArgumentNullException(nameof(uF));
        }

        [Key]
        public int Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
