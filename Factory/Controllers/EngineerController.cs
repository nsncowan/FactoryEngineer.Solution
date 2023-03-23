using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq; // allows for some List functionality - like ToList()
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class EngineerController : Controller
  {
    private readonly FactoryContext _db;
    public EngineerController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
    }

    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
                                  .Include(engineer => engineer.JoinEntities)
                                  .ThenInclude(join =>join.Machine)
                                  .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }
  }
}