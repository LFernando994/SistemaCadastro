using CLData;
using SistemaCadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public class Chamado
    {
        DAOChamados daoChamados = new DAOChamados();
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime dataDeSolicitacao { get; set; }
        public Cliente clienteSolicitante = new Cliente();
        public Funcionario funcionarioResponsavel = new Funcionario();

        public Chamado()
        {
        }

        public Chamado(int id, string descricao, DateTime dataDeSolicitacao, Cliente clienteSolicitante, Funcionario funcionarioResponsavel)
        {
            this.id = id;
            this.descricao = descricao;
            this.dataDeSolicitacao = dataDeSolicitacao;
            this.clienteSolicitante = clienteSolicitante;
            this.funcionarioResponsavel = funcionarioResponsavel;
        }
        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<Chamado> GetListarTodos()
        {
            foreach (List<Chamado> item in daoChamados.ListarTodos())
            {
                return item;
            }
            return null;
        }
        public void Adicionar(Chamado usuarios)
        {
            Carregar();
            daoChamados.Adicionar(usuarios);
        }
        public void Remover(Chamado usuario)
        {
            Carregar();
            daoChamados.Remover(usuario);
        }
        public void Carregar()
        {
            daoChamados.Carregar();
        }
        public void Salvar()
        {
            daoChamados.Salvar();
        }

        #region Validações

        /// <summary>
        /// Cria id
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
        #endregion

        #region Buscas

        /// <summary>
        /// Busca chamado pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Chamado BuscarChamadoPorId(int id)
        {
            try
            {
                return GetListarTodos().Where(c => c.id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}

