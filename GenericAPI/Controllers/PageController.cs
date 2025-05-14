using DataLayer;
using GenericAPI.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericAPI.Controllers;
[Route("api/pages")]
[ApiController]
public class PageController : GenericController<Page>
{
    public PageController(IGenericRepository<Page> repo) : base(repo) { }
}
