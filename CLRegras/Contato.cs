using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using CLData;

namespace SistemaCadastro
{
    public class Contato
    {       
        public int id { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public string uf { get; set; }
        DAOContatoCliente daoContatoCliente = new DAOContatoCliente();
        DAOContatoFuncionario daoContatoFuncionario = new DAOContatoFuncionario();

        public Contato()
        {
        }

        public Contato(int id, string cep, string endereco, string cidade, string bairro, int numero, string uf, string email, string telefone)
        {
            this.id = id;
            this.cep = cep;
            this.endereco = endereco;
            this.cidade = cidade;
            this.bairro = bairro;
            this.numero = numero;
            this.uf = uf;
            this.email = email;
            this.telefone = telefone;
        }

        #region Cliente
        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<Contato> GetListarTodos()
        {
            foreach (List<Contato> item in daoContatoCliente.ListarTodos())
            {
                return item;
            }
            return null;
        }
        public void Adicionar(Contato usuarios)
        {
            Carregar();
            daoContatoCliente.Adicionar(usuarios);
        }
        public void Remover(Contato usuario)
        {
            Carregar();
            daoContatoCliente.Remover(usuario);
        }
        public void Carregar()
        {
            daoContatoCliente.Carregar();
        }
        public void Salvar()
        {
            daoContatoCliente.Salvar();
        }
        #region Buscas

        /// <summary>
        /// Método que busca contato pelo endereco
        /// </summary>
        /// <param name="buscaEndereco"></param>
        /// <returns></returns>
        public Contato Buscar(string buscaEndereco)
        {
            try
            {
                return GetListarTodos().Where(c => c.endereco.Equals(buscaEndereco)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lista todos os contatos relacionados ao cliente por meio do id (Excluir contatos)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contato> BuscarPorID(int id)
        {
            try
            {
                return GetListarTodos().Where(c => c.id.Equals(id)).TakeWhile(c => c.id.Equals(id)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca contato para editar as informações
        /// </summary>
        /// <param name="id"></param>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public Contato BuscaContatoEditar(int id, string endereco)
        {
            try
            {
                return GetListarTodos().Where(c => c.id.Equals(id)).TakeWhile(c => c.endereco.Equals(endereco)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca todos os emails de determinada pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> EmailsContato(int id)
        {
            try
            {
                Carregar();
                return GetListarTodos().Where(c => c.id.Equals(id)).TakeWhile(c => c.id.Equals(id)).Select(x => x.email).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Funcionario
        #region Buscas
        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<Contato> GetListarTodosFunc()
        {
            foreach (List<Contato> item in daoContatoFuncionario.ListarTodos())
            {
                return item;
            }
            return null;
        }
        public void AdicionarFunc(Contato usuarios)
        {
            CarregarFunc();
            daoContatoFuncionario.Adicionar(usuarios);
        }
        public void RemoverFunc(Contato usuario)
        {
            CarregarFunc();
            daoContatoFuncionario.Remover(usuario);
        }
        public void CarregarFunc()
        {
            daoContatoFuncionario.Carregar();
        }
        public void SalvarFunc()
        {
            daoContatoFuncionario.Salvar();
        }

        /// <summary>
        /// Busca contato do funciorario pelo numero e endereço
        /// </summary>
        /// <param name="contatoEndereco"></param>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Contato BuscarFuncionario(string contatoEndereco, int numero)
        {
            try
            {
                return GetListarTodosFunc().Where(c => c.endereco.Equals(contatoEndereco) && c.numero.Equals(numero)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca os contatos relacionados ao funcionario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contato> BuscarPorIDFuncionario(int id)
        {
            try
            {
                return GetListarTodosFunc().Where(c => c.id.Equals(id)).TakeWhile(c => c.id.Equals(id)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

    }
}
