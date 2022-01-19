using SeventhTest.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SeventhTest.DAO.Base
{
    public abstract class BaseDao<TEntity> : Connection
    {
        #region "Variables"

        protected int rowsAffected = 0;
        protected int lastInsertId = 0;

        #endregion

        #region "Constants"

        protected const string ParamReturnValue = "pRETURN_VALUE";
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
            DbNameToDtoName = new Dictionary<string, string>() 
                                        { 
                                            {"ID",          "Id"        }, 
                                            {"DATE_ALTER",  "DateAlter" },
                                            {"DATE_INSERT", "DateInsert"}
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

            if (!read) 
            {
                CloseConnection();
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

            CloseConnection();

            return result;
        }        

        #endregion
    }
}
