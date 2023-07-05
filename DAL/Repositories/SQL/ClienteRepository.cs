using DAL.Contracts;
using DAL.Tools;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SL.Services.Extension;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SL.Services;
using SL.Domain;

namespace DAL
{
    internal class ClienteRepository : IGenericRepository<Cliente>
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Clientes] (IdCliente,FirstName,LastName,Adress,BirthDate) VALUES (@IdCliente,@FirstName,@LastName,@Adress,@BirthDate)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Cliente] SET (IdCliente,FirstName,LastName,Adress,BirthDate) WHERE  = @";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Cliente] WHERE  = @";
        }

        private string SelectOneStatement
        {
            get => "SELECT  IdCliente,FirstName,LastName,Adress FROM [dbo].[Cliente] WHERE  = @";
        }

        private string SelectAllStatement
        {
            get => "SELECT  IdCliente,FirstName,LastName,Adress,BirthDate FROM [dbo].[Cliente]";
        }
        #endregion


        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cliente obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text,
                new SqlParameter[] {
                    new SqlParameter("@IdCliente",Guid.NewGuid()),
                    new SqlParameter("@FirstName",obj.Nombre),
                    new SqlParameter("@LastName",obj.Apellido),
                    new SqlParameter("@adress",obj.Direccion),
                    new SqlParameter("@BirthDate",obj.FechaNacimiento)
                });
            }
            catch (Exception ex)
            {
                ex.ExceptionHandle(this);  
            
            }
            
        }

        public void Update(Guid id, Cliente obj)
        {
            throw new NotImplementedException();
        }
    }
}
