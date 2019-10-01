using CLData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLRegras
{
    public class AreaDeAtuacao
    {
        public int id { get; set; }
        public string nome { get; set; }
        DAOAreaDeAtuacao daoAreaDeAtuacao = new DAOAreaDeAtuacao();

        public AreaDeAtuacao()
        {
            
        }
        public AreaDeAtuacao(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<AreaDeAtuacao> GetListarTodos()
        {
            foreach (List<AreaDeAtuacao> item in daoAreaDeAtuacao.ListarTodos())
            {
                return item;
            }
            return null;
        }
        public void Adicionar(AreaDeAtuacao usuarios)
        {
            Carregar();
            daoAreaDeAtuacao.Adicionar(usuarios);
        }
        public void Remover(AreaDeAtuacao usuario)
        {
            Carregar();
            daoAreaDeAtuacao.Remover(usuario);
        }
        public void Carregar()
        {
            daoAreaDeAtuacao.Carregar();
        }
        public void Salvar()
        {
            daoAreaDeAtuacao.Salvar();
        }
        #region Validações

        /// <summary>
        /// Cria um id 
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
        /// Busca a area de atuação por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AreaDeAtuacao BuscarAreaPorId(int id)
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
