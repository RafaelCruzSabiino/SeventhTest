using SeventhdGuard.ENTITY;
using SeventhdGuard.ENTITY.Base;
using System;
using System.Threading.Tasks;

namespace SeventhdGuard.BO.Interfaces
{
    public interface IReciclarBo
    {
        Task RecyclerVideo(Reciclar entity, int days);
        bool Process(Reciclar entity, int days);
        ResultInfo BeginProcess(Reciclar entity);
        ResultInfo EndProcess(string id, DateTime dataFinished);
        ResultInfo<Reciclar> Verify();
    }
}
