using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace jr_repo.DAL
{
   internal class PessoaDal
    {
        SCon _scon = new SCon();
        internal int Incluir(Pessoa pessoa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("Nome", pessoa.Nome));
            parametros.Add(new SqlParameter("Email", pessoa.Email));
            parametros.Add(new SqlParameter("Mensagem", pessoa.Mensagem));      


            using (SqlConnection con = new SqlConnection(_scon.GetScon()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.CommandText = "sp_Incluir_Pessoa";                      
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        foreach (var item in parametros)
                        {
                            cmd.Parameters.Add(item);
                        }

                        con.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar());

                    }
                    catch (SqlException ex)
                    {
                       throw ex;
                    }
                }           
            }
        }
    }
}
