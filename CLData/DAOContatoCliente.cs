using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CLData
{
    public class DAOContatoCliente
    {
        public List<object> contatos;
        string path = ConfigurationManager.AppSettings["Contatos"].ToString();
        string diretorio = ConfigurationManager.AppSettings["Diretorio"].ToString();

        public DAOContatoCliente()
        {
            this.contatos = new List<object>();
        }

        #region Crud
        /// <summary>
        /// Adiciona determinado cliente
        /// </summary>
        /// <param name="contatos"></param>
        public void Adicionar(object contatos)
        {
            this.contatos.Add(contatos);
        }

        /// <summary>
        /// Remove determinado contato 
        /// </summary>
        /// <param name="contato"></param>
        public void Remover(object contato)
        {
            try
            {
                this.contatos.Remove(contato);
                XmlSerializer ser = new XmlSerializer(typeof(List<object>));
                FileStream fs = new FileStream(path, FileMode.Create);
                ser.Serialize(fs, contatos);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista todos os contatos do xml
        /// </summary>
        /// <returns></returns>
        public List<object> ListarTodos()
        {
            Carregar();
            return this.contatos;
        }

        /// <summary>
        /// Salva no arquivo xml as informações 
        /// </summary>
        public void Salvar()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<object>));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                ser.Serialize(fs, this.contatos);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Carregar arquivo xml
        /// </summary>
        public void Carregar()
        {
            if (Directory.Exists(diretorio))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<object>));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                try
                {
                    this.contatos = ser.Deserialize(fs) as List<object>;
                }
                catch (InvalidOperationException)
                {
                    ser.Serialize(fs, this.contatos);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                DirectoryInfo dic = new DirectoryInfo(diretorio);
                dic.Create();
                Carregar();
            }
        }
        #endregion

    }
}
