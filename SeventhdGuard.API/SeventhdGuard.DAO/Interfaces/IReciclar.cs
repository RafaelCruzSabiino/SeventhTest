using SeventhdGuard.ENTITY;
using System;

namespace SeventhdGuard.DAO.Interfaces
{
    public interface IReciclar
    {
        int BeginProcess(Reciclar entity);
        int EndProcess(string id, DateTime dataFinished);
        Reciclar Verify();
    }
}
