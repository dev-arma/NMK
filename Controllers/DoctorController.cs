using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMK.Data;
using NMK.Models;

namespace NMK.Controllers;

public class DoctorController : Controller
{
    private readonly NMKDbContext _context;

    public DoctorController(NMKDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var doctors = _context.Doctors.Where(d => !d.IsDeleted).ToList();
        return View(doctors);
    }
    public IActionResult AddDoctor()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddDoctor(Doctor doctor)
    {
        if (ModelState.IsValid)
        {
            
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            doctor.DateAdded=DateTime.Now;
            return RedirectToAction("Index");
        }
        return View(doctor);
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var doctor = await _context.Doctors.FirstOrDefaultAsync(m => m.Id == id);
        if (doctor == null)
        {
            return NotFound();
        }
        return View(doctor);
    }
           
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Title,DoctorCode")] Doctor doctor)
    {
        if (id != doctor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {   
                doctor.DateModified=DateTime.Now;
                _context.Update(doctor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(doctor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(doctor);
    }

  

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(p => p.Id == id);
        if (doctor != null)
        {   
            doctor.IsDeleted = true;
            doctor.DateModified=DateTime.Now;
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        
        return RedirectToAction(nameof(Index));
    }

    private bool DoctorExists(int id)
    {
        return _context.Doctors.Any(e => e.Id == id);
    }
}