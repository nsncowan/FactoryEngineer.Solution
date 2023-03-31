using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq; // allows for some List functionality - like ToList()
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachineController : Controller
  {
    private readonly FactoryContext _db;
    public MachineController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }

    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
                                      .Include(machine => machine.JoinEntities)
                                      .ThenInclude(license => license.Engineer)
                                      .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }
     
    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int engineerId)
    {
       #nullable enable
       License? joinEntity = _db.Licenses.FirstOrDefault(license => (license.EngineerId == engineerId && license.MachineId == machine.MachineId));
       #nullable disable
       if(joinEntity == null && engineerId !=0)
       {
        _db.Licenses.Add(new License() {MachineId = machine.MachineId, EngineerId = engineerId});
        _db.SaveChanges();
       }
       return RedirectToAction("Details", new { id = machine.MachineId});
    }

    public ActionResult Edit(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Machines.Update(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
    Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
    _db.Machines.Remove(thisMachine);
    _db.SaveChanges();
    return RedirectToAction("Index");
    }


  }
}