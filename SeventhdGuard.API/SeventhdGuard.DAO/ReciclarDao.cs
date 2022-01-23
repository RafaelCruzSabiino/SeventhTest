using SeventhdGuard.DAO.Base;
using SeventhdGuard.DAO.Interfaces;
using SeventhdGuard.ENTITY;
using System;
using System.Data;

namespace SeventhdGuard.DAO
{
    public class ReciclarDao : BaseDao<Reciclar>, IReciclar
    {
        #region "Constants"

        #region "Procedures"

        private const string Sdg00030001 = "SP_SDG_0003_0001";
        private const string Sdg00030002 = "SP_SDG_0003_0002";
        private const string Sdg00030003 = "SP_SDG_0003_0003";

        #endregion

        #region "Parameters"

        protected const string ParamType = "pTYPE";

        #endregion

        #endregion

        #region "Contruct"

        public ReciclarDao()
        {
            DbNameToDtoName.Add("TYPE", "Type");
        }

        #endregion

        #region "Public Methods"

        public int BeginProcess(Reciclar entity)
        {
            Connect();

            using (var cmd = objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00030001;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId,         entity.Id);
                cmd.Parameters.AddWithValue(ParamType,       entity.Type);
                cmd.Parameters.AddWithValue(ParamDateAlter,  entity.DateAlter);
                cmd.Parameters.AddWithValue(ParamDateInsert, entity.DateInsert);

                return ExecuteData(cmd);
            }
        }

        public int EndProcess(string id, DateTime dataFinished)
        {
            Connect();

            using (var cmd = objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00030002;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId,        id);
                cmd.Parameters.AddWithValue(ParamDateAlter, dataFinished);

                return ExecuteData(cmd);
            }
        }

        public Reciclar Verify()
        {
            Connect();

            using (var cmd = objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00030003;
                cmd.CommandTimeout = 0;

                return ExecuteDataReaderEntity(cmd);
            }
        }

        #endregion
    }
}
