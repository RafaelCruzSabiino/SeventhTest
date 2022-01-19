using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SeventhTest.DAO.Base
{
    public abstract class BaseDao<TEntity> : Connection
    {
        #region "Constants"

        protected const string ParamReturnValue   = "RETURN_VALUE";
        protected const string ParamId            = "ID";
        protected const string ParamDataAlteracao = "DATA_ALTERACAO";
        protected const string ParamDataInsercao  = "DATA_INSERCAO";

        #endregion

        #region "Properties"

        protected Dictionary<string, string> DbNameToDtoName { get; set; }

        #endregion

        #region "Construct"

        public BaseDao() 
        {
            DbNameToDtoName = new Dictionary<string, string>() 
                                        { 
                                            {"ID",             "Id"           }, 
                                            {"DATA_ALTERACAO", "DataAlteracao"}, 
                                            {"DATA_INSERCAO",  "DataInsercao" }
                                        };
        }

        #endregion

        #region "Public Methods"

        public TEntity DataReaderToEntity(IDataReader idr, bool read = false)
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

            return dto;
        }

        public IList<TEntity> DataReaderToEntities(IDataReader idr)
        {
            var result = new List<TEntity>();

            while (idr.Read())
            {
                result.Add(DataReaderToEntity(idr, true));
            }

            return result;
        }

        #endregion
    }
}
