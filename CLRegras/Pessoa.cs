using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public char sexo { get; set; }
        public string cpf { get; set; }
        public int rg { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public string grupoSanguineo { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(int id, string nome, char sexo, string cpf, int rg, DateTime dataDeNascimento, string grupoSanguineo)
        {
            this.id = id;
            this.nome = nome;
            this.sexo = sexo;
            this.cpf = cpf;
            this.rg = rg;
            this.dataDeNascimento = dataDeNascimento;
            this.grupoSanguineo = grupoSanguineo;
        }
    }
}
