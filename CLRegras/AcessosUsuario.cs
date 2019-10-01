﻿using CLData;
using SistemaCadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public class AcessosUsuario
    {
        DAOAcesso daoAcesso = new DAOAcesso();

        public int id { get; set; }
        public string login { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string perfil{ get; set; }

        public AcessosUsuario()
        {
        }

        public AcessosUsuario(int id, string nome,string login, string senha, string perfil)
        {
            this.id = id;
            this.login = login;
            this.nome = nome;
            this.senha = senha;
            this.perfil = perfil;              
        }

        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<AcessosUsuario> GetListarTodos()
        {
            foreach (List<AcessosUsuario> item in daoAcesso.ListarTodos())
            {
                return item;
            }
            return null;
        }
        public void Adicionar(AcessosUsuario usuarios)
        {
            Carregar();
            daoAcesso.Adicionar(usuarios);
        }
        public void Remover(AcessosUsuario usuario)
        {
            Carregar();
            daoAcesso.Remover(usuario);
        }
        public void Carregar()
        {
            daoAcesso.Carregar();
        }
        public void Salvar()
        {
            daoAcesso.Salvar();
        }

        #region Buscas
        /// <summary>
        /// Busca usuario e retorna acesso completo dele
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public AcessosUsuario Buscar(string usuario)
        {
            try
            {
                return GetListarTodos().Where(c => c.login.Equals(usuario)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca o perfil do usuario entre os acessos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string BuscarPerfil(string usuario)
        {
            try
            {
                return GetListarTodos().Where(c => c.login.Equals(usuario)).FirstOrDefault().perfil;
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
        /// Valida o Login para ver se os existe no xml
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool ValidarLogin(string login)
        {
            try
            {
                foreach (AcessosUsuario x in GetListarTodos().Where(x => x.login.Equals(login)))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Consulta a senha para ver se esta certa
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public bool ValidarSenha(string senha)
        {
            try
            {
                foreach (AcessosUsuario x in GetListarTodos().Where(x => x.senha.Equals(senha)))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Verifica se a senha esta entre os acessos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool VerificarSituacao(string usuario)
        {
            try
            {
                foreach (var item in GetListarTodos().Where(c => c.login.Equals(usuario)).TakeWhile(c => c.senha != "null"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
