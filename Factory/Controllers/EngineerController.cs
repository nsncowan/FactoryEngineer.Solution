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

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int machineId)
    {
      #nullable enable
      License? joinEntity = _db.Licenses.FirstOrDefault(license => (license.MachineId == machineId && license.EngineerId == engineer.EngineerId));
      #nullable disable
      if(joinEntity == null && machineId != 0)
      {
        
        _db.Licenses.Add(new License() {EngineerId = engineer.EngineerId, MachineId = machineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new {id = engineer.EngineerId});
    }










  }
}