using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using CLRegras;
using CLData;

namespace SistemaCadastro
{
    public class Cliente: Pessoa
    {
        DAOCliente daoCliente = new DAOCliente();
        public DateTime dataDeExpiracao { get; set; }

        public Cliente() : base()
        {
        }

        public Cliente(int id, string nome, char sexo, string cpf, int rg, DateTime dataDeNascimento, string grupoSanguineo, DateTime dataDeExpiracao) : base(id, nome, sexo, cpf, rg, dataDeNascimento, grupoSanguineo)
        {
         
            this.dataDeExpiracao = dataDeExpiracao;          
        }

        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<Cliente> GetListarTodos()
        {
            foreach (List<Cliente> item in daoCliente.ListarTodos())
            {
                return item;
            }
            return null;
        }
        public void Adicionar(Cliente usuarios)
        {
            Carregar();
            daoCliente.Adicionar(usuarios);
        }
        public void Remover(Cliente usuario)
        {
            Carregar();
            daoCliente.Remover(usuario);
        }
        public void Carregar()
        {
            daoCliente.Carregar();
        }
        public void Salvar()
        {
            daoCliente.Salvar();
        }

        #region Pesquisa 
        /// <summary>
        /// Busca o cliente pelo cpf e retorna o mesmo
        /// </summary>
        /// <param name="clienteCPF"></param>
        /// <returns></returns>
        public Cliente BuscarClientePorCPF(string clienteCPF)
        {
            try
            {
                return GetListarTodos().Where(c => c.cpf.Equals(clienteCPF)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca cliente pelo cpf e retorna seu id
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public int BuscarIdPorCPF(string cpf)
        {
            try
            {
                return GetListarTodos().Where(c => c.cpf.Equals(cpf)).FirstOrDefault().id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca cliente pelo id e retorna o cliente complete
        /// </summary>
        /// <param name="buscaid"></param>
        /// <returns></returns>
        public Cliente BuscarClientePorID(int buscaid)
        {
            try
            {
                return GetListarTodos().Where(c => c.id.Equals(buscaid)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Cliente BuscarClientePorUsuario(int usuario)
        {
            try
            {
                return GetListarTodos().Where(c => c.rg.Equals(usuario)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Validações

        /// <summary>
        /// Método para criar um ID
        /// </summary>
        /// <returns></returns>
        public int ContadorID()
        {
            try
            {
                return GetListarTodos().Last().id + 1;
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }

        /// <summary>
        /// Verifica se a data de validade daquele login esta correta
        /// </summary>
        /// <param name="dataDeExpiracao"></param>
        /// <returns></returns>
        public bool ValidarExpiracao(DateTime dataDeExpiracao)
        {
            try
            {
                DateTime dataHoje = DateTime.Now.Date;
                if (dataDeExpiracao >= dataHoje)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
