using CLData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public class UsuariosSistema: Usuarios
    {
        DAOUsuariosSistema daoUsuarioSistema = new DAOUsuariosSistema();
        public UsuariosSistema() : base()
        {
        }

        public UsuariosSistema(int id, string nome, string cpf, int rg) : base(id, nome, cpf, rg)
        {
          
        }

        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<UsuariosSistema> GetListarTodos()
        {
            foreach (List<UsuariosSistema> item in daoUsuarioSistema.ListarTodos())
            {
                return item;
            }
            return null;
        }
        public void Adicionar(UsuariosSistema usuarios)
        {
            Carregar();
            daoUsuarioSistema.Adicionar(usuarios);
        }
        public void Remover(UsuariosSistema usuario)
        {
            Carregar();
            daoUsuarioSistema.Remover(usuario);
        }
        public void Carregar()
        {
            daoUsuarioSistema.Carregar();
        }
        public void Salvar()
        {
            daoUsuarioSistema.Salvar();
        }

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
        #endregion

        #region Buscas

        /// <summary>
        /// Busca Secretaria pelo usuario (usuario == rg)
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public UsuariosSistema BuscarPorUsuarioSistema(int usuario)
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

        /// <summary>
        /// Busca Secretaria pelo CPF
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public UsuariosSistema BuscarSecretariaPorCPF(string cpf)
        {
            try
            {
                return GetListarTodos().Where(c => c.cpf.Equals(cpf)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
