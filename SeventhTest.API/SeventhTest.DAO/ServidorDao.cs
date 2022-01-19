using SeventhTest.DAO.Base;
using SeventhTest.DAO.Interfaces;
using SeventhTest.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;

namespace SeventhTest.DAO
{
    public class ServidorDao : BaseDao<Servidor>, IBaseDao<Servidor>
    {
        #region "Constants"

        #region "Procedures"

        private const string Sdg00010001 = "SP_SGD_0001_0001";
        private const string Sdg00010002 = "SP_SGD_0001_0002";
        private const string Sdg00010003 = "SP_SGD_0001_0003";
        private const string Sdg00010004 = "SP_SGD_0001_0004";
        private const string Sdg00010005 = "SP_SGD_0001_0005";

        #endregion

        #region "Parameters"

        protected const string ParamName = "pNAME";
        protected const string ParamIp   = "pIP";
        protected const string ParamPort = "pPORT";

        #endregion

        #endregion

        #region "Contruct"

        public ServidorDao() 
        {
            DbNameToDtoName.Add("NAME", "Name");
            DbNameToDtoName.Add("IP",   "Ip");
            DbNameToDtoName.Add("PORT", "Port");
        }

        #endregion

        #region "Public Methods"

        public int Add(Servidor entity)
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand()) 
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00010001;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId,         entity.Id);
                cmd.Parameters.AddWithValue(ParamName,       entity.Name);
                cmd.Parameters.AddWithValue(ParamIp,         entity.Ip);
                cmd.Parameters.AddWithValue(ParamPort,       entity.Port);
                cmd.Parameters.AddWithValue(ParamDateAlter,  entity.DateAlter);
                cmd.Parameters.AddWithValue(ParamDateInsert, entity.DateInsert);

                using (var RetBase = cmd.ExecuteReader())
                {
                    while (RetBase.Read())
                    {
                        lastInsertId = Convert.ToInt32(RetBase[ParamReturnValue]);
                    }
                }
            }

            CloseConnection();

            return lastInsertId;
        }

        public int Update(Servidor entity)
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00010002;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId,        entity.Id);
                cmd.Parameters.AddWithValue(ParamName,      entity.Name);
                cmd.Parameters.AddWithValue(ParamIp,        entity.Ip);
                cmd.Parameters.AddWithValue(ParamPort,      entity.Port);
                cmd.Parameters.AddWithValue(ParamDateAlter, entity.DateAlter);

                using (var RetBase = cmd.ExecuteReader())
                {
                    while (RetBase.Read())
                    {
                        rowsAffected = Convert.ToInt32(RetBase[ParamReturnValue]);
                    }
                }
            }

            CloseConnection();

            return rowsAffected;
        }

        public int Delete(int id)
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00010003;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId, id);

                using (var RetBase = cmd.ExecuteReader())
                {
                    while (RetBase.Read())
                    {
                        rowsAffected = Convert.ToInt32(RetBase[ParamReturnValue]);
                    }
                }
            }

            CloseConnection();

            return rowsAffected;
        }

        public Servidor Get(int id)
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00010004;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId, id);

                using (var RetBase = cmd.ExecuteReader()) 
                {
                    return DataReaderToEntity(RetBase);
                }
            }
        }

        public IEnumerable<Servidor> GetAll()
        {
            Connect();

            using (var cmd = _objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00010005;
                cmd.CommandTimeout = 0;

                using (var RetBase = cmd.ExecuteReader())
                {
                    return DataReaderToEntities(RetBase);
                }
            }
        }

        #endregion

    }
}
