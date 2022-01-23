using Microsoft.AspNetCore.Mvc;

namespace SeventhdGuard.API.Interfaces
{
    public interface IReciclarController
    {
        StatusCodeResult RecyclerVideo(int days);
        ObjectResult Verify();
    }
}
