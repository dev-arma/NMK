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

public class PatientController : Controller

{
    private readonly NMKDbContext _context;

    public PatientController(NMKDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var patients = _context.Patients.Where(p => !p.IsDeleted).ToList();
        return View(patients);
    }

    public IActionResult AddPatient()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddPatient(Patient patient)
    {
        if (ModelState.IsValid)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            patient.DateAdded=DateTime.Now;
            return RedirectToAction("Index");
        }
        return View(patient);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);
        if (patient == null)
        {
            return NotFound();
        }
        return View(patient);
    }
           
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NameAndSurname,DateOfBirth,Gender,Address,PhoneNumber")] Patient patient)
    {
        if (id != patient.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                patient.DateModified=DateTime.Now;
                _context.Update(patient);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(patient.Id))
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
        return View(patient);
    }

    
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        if (patient != null)
        {   
            patient.DateModified = DateTime.Now;
            patient.IsDeleted = true;
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        
        return RedirectToAction(nameof(Index));
    }

    private bool PatientExists(int id)
    {
        return _context.Patients.Any(e => e.Id == id);
    }
}

