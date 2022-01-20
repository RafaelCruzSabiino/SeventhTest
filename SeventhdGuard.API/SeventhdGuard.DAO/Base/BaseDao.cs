using MySql.Data.MySqlClient;
using SeventhdGuard.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SeventhdGuard.DAO.Base
{
    public abstract class BaseDao<TEntity>
    {
        #region "Variables"

        private static string            _strConnection;
        protected static MySqlConnection  objConnection;
        protected static MySqlTransaction transaction;

        #endregion

        #region "Constants"

        protected const string ParamId          = "pID";
        protected const string ParamDateAlter   = "pDATE_ALTER";
        protected const string ParamDateInsert  = "pDATE_INSERT";

        #endregion

        #region "Properties"

        protected Dictionary<string, string> DbNameToDtoName { get; set; }

        #endregion

        #region "Construct"

        public BaseDao() 
        {
            _strConnection = new DataConnection().StrConnection();

            DbNameToDtoName = new Dictionary<string, string>() 
                                        { 
                                            {"ID",          "Id"        }, 
                                            {"DATE_ALTER",  "DateAlter" },
                                            {"DATE_INSERT", "DateInsert"}
                                        };
        }

        #endregion

        #region "Protected Methods"

        protected static void Connect()
        {
            try
            {
                objConnection = new MySqlConnection(_strConnection);
                objConnection.Open();
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar se conectar ao banco!");
            }
        }

        protected static void CloseConnection()
        {
            objConnection.Close();
        }

        protected static void BeginTranstion()
        {
            transaction = objConnection.BeginTransaction();
        }

        protected static void RowBack()
        {

            transaction.Rollback();
        }

        protected static void Commit()
        {
            transaction.Commit();
        }

        protected static int ExecuteData(MySqlCommand cmd) 
        {
            BeginTranstion();

            try
            {
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());

                Commit();

                CloseConnection();

                return result;
            }
            catch (MySqlException ex) 
            {
                RowBack();
                CloseConnection();
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                RowBack();
                CloseConnection();
                throw new Exception(ex.Message);
            }
        }

        protected TEntity ExecuteDataReaderEntity(MySqlCommand cmd) 
        {
            using (var RetBase = cmd.ExecuteReader())
            {
                return DataReaderToEntity(RetBase);
            }
        }

        protected IEnumerable<TEntity> ExecuteDataReaderEntities(MySqlCommand cmd) 
        {
            using (var RetBase = cmd.ExecuteReader())
            {
                return DataReaderToEntities(RetBase);
            }
        }

        #endregion

        #region "Private Methods"

        private TEntity DataReaderToEntity(IDataReader idr, bool read = false)
        {
            var dto = Activator.CreateInstance<TEntity>();

            if (read || idr.Read())
            {
                var tp = dto.GetType();
                var properties = tp.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var countFields = idr.FieldCount;

                for (var i = 0; i < countFields; i++)
                {
                    var field = DbNameToDtoName.FirstOrDefault(p => p.Key == idr.GetName(i));
                    var prop = properties.FirstOrDefault(p => p.Name == field.Value);

                    if (prop != null && !string.IsNullOrWhiteSpace(field.Value) && idr[field.Key] != DBNull.Value)
                    {
                        prop.SetValue(dto, idr[field.Key], null);
                    }
                }
            }

            if (!read) 
            {
                CloseConnection();
            }

            return dto;
        }

        private IList<TEntity> DataReaderToEntities(IDataReader idr)
        {
            var result = new List<TEntity>();

            while (idr.Read())
            {
                result.Add(DataReaderToEntity(idr, true));
            }

            CloseConnection();

            return result;
        }        

        #endregion
    }
}
