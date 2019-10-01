using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CLData
{
    public class DAOUsuariosSistema 
    {

        public List<object> usuariossistema;
        string path = ConfigurationManager.AppSettings["UsuariosSistema"].ToString();
        string diretorio = ConfigurationManager.AppSettings["Diretorio"].ToString();

        public DAOUsuariosSistema()
        {
            this.usuariossistema = new List<object>();
        }

        #region Crud
        /// <summary>
        /// Adiciona determinado cliente
        /// </summary>
        /// <param name="secretaria"></param>
        public void Adicionar(object secretaria)
        {
            this.usuariossistema.Add(secretaria);
        }

        /// <summary>
        /// Remove determinado contato 
        /// </summary>
        /// <param name="secretaria"></param>
        public void Remover(object secretaria)
        {
            try
            {
                this.usuariossistema.Remove(secretaria);
                XmlSerializer ser = new XmlSerializer(typeof(List<object>));
                FileStream fs = new FileStream(path, FileMode.Create);
                ser.Serialize(fs, usuariossistema);
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
            return this.usuariossistema;
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
                ser.Serialize(fs, this.usuariossistema);
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
                    this.usuariossistema = ser.Deserialize(fs) as List<object>;
                }
                catch (InvalidOperationException)
                {
                    ser.Serialize(fs, this.usuariossistema);
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
