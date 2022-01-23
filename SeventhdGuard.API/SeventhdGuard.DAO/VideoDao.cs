using SeventhdGuard.DAO.Base;
using SeventhdGuard.DAO.Interfaces;
using SeventhdGuard.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;

namespace SeventhdGuard.DAO
{
    public class VideoDao : BaseDao<Video>, IVideoDao
    {
        #region "Constants"

        #region "Procedures"

        private const string Sdg00020001 = "SP_SDG_0002_0001";
        private const string Sdg00020003 = "SP_SDG_0002_0003";
        private const string Sdg00020004 = "SP_SDG_0002_0004";
        private const string Sdg00020005 = "SP_SDG_0002_0005";
        private const string Sdg00020006 = "SP_SDG_0002_0006";
        private const string Sdg00020007 = "SP_SDG_0002_0007";

        #endregion

        #region "Parameters"

        protected const string ParamIdServer    = "pID_SERVER";
        protected const string ParamDescription = "pDESCRIPTION";
        protected const string ParamSizeInBytes = "pSIZEINBYTES";
        protected const string ParamDate        = "pDATE";

        #endregion

        #endregion

        #region "Construct"

        public VideoDao()
        {
            DbNameToDtoName.Add("ID_SERVER", "IdServer");
            DbNameToDtoName.Add("DESCRIPTION", "Description");
            DbNameToDtoName.Add("SIZEINBYTES", "SizeInBytes");
        }

        #endregion

        #region "Public Methods"

        public int Add(Video entity)
        {
            Connect();

            using (var cmd = objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020001;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId,          entity.Id);
                cmd.Parameters.AddWithValue(ParamIdServer,    entity.IdServer);
                cmd.Parameters.AddWithValue(ParamDescription, entity.Description);
                cmd.Parameters.AddWithValue(ParamSizeInBytes, entity.SizeInBytes);
                cmd.Parameters.AddWithValue(ParamDateAlter,   entity.DateAlter);
                cmd.Parameters.AddWithValue(ParamDateInsert,  entity.DateInsert);

                return ExecuteData(cmd);
            }
        }

        public int Delete(string serverId, string videoId)
        {
            Connect();

            using (var cmd = objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020003;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId,       videoId);
                cmd.Parameters.AddWithValue(ParamIdServer, serverId);

                return ExecuteData(cmd);
            }
        }

        public Video Get(string serverId, string videoId)
        {
            Connect();

            using (var cmd = objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020004;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamId,       videoId);
                cmd.Parameters.AddWithValue(ParamIdServer, serverId);

                return ExecuteDataReaderEntity(cmd);
            }
        }

        public IEnumerable<Video> GetAll()
        {
            Connect();

            using (var cmd = objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020005;
                cmd.CommandTimeout = 0;

                return ExecuteDataReaderEntities(cmd);
            }
        }

        public IEnumerable<Video> GetVideoByServer(string idServer)
        {
            Connect();

            using (var cmd = objConnection.CreateCommand())
            {                      
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020006;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamIdServer, idServer);

                return ExecuteDataReaderEntities(cmd);
            }
        }

        public IEnumerable<Video> GetVideoByDate(DateTime date)
        {
            Connect();

            using (var cmd = objConnection.CreateCommand())
            {
                cmd.CommandType    = CommandType.StoredProcedure;
                cmd.CommandText    = Sdg00020007;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue(ParamDate, date);

                return ExecuteDataReaderEntities(cmd);
            }
        }

        #endregion
    }
}
