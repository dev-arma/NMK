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

public class AdmissionController : Controller
{
    private readonly NMKDbContext _context;

    public AdmissionController(NMKDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var admissions = await _context.Admissions.Include(a => a.Patient).Include(a => a.Doctor).Where(a => !a.IsDeleted).ToListAsync();
        return View(admissions);
    }
    public IActionResult AddAdmission()
    {
        ViewBag.Patients = _context.Patients.Where(p => !p.IsDeleted).ToList();
        ViewBag.Doctors = _context.Doctors.Where(d => !d.IsDeleted && d.Title == "Specijalista").ToList();
        return View();
    }

    [HttpPost]
    public IActionResult AddAdmission(Admission admission)
    {
        if (ModelState.IsValid)
        {
            
            _context.Admissions.Add(admission);
            _context.SaveChanges();
            admission.DateAdded = DateTime.Now;
            return RedirectToAction("Index");
        }

        ViewBag.Patients = _context.Patients.Where(p => !p.IsDeleted).ToList();
        ViewBag.Doctors = _context.Doctors.Where(d => !d.IsDeleted && d.Title == "Specijalista").ToList();
        return View("Error");
    }


    public IActionResult ViewAdmission(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var admission = _context.Admissions
                                .Include(a => a.Patient)
                                .Include(a => a.Doctor)
                                .FirstOrDefault(a => a.Id == id);
        
        if (admission == null)
        {
            return NotFound(); 
        }

        return View(admission); 
    }

    public IActionResult AddReport(int? id)
    {
       
        if (id == null)
        {
            return NotFound();
        }

        var admission =  _context.Admissions.Include(m => m.Patient).Include(m => m.Doctor).FirstOrDefault(m => m.Id == id);
        ViewBag.Patients = _context.Patients.Where(p => !p.IsDeleted).ToList();
        ViewBag.Doctors = _context.Doctors.Where(d => !d.IsDeleted && d.Title == "Specijalista").ToList();
               
        
        if (admission == null)
        {
            return NotFound();
        }
       
        return View(admission);
    }

    [HttpPost]
    public IActionResult AddReport(int? id, string ReportText)
    {
        var admission = _context.Admissions.Find(id);

        if (admission == null)
            {
                return NotFound();
            }
        admission.ReportText = ReportText;
        _context.Admissions.Update(admission);
        _context.SaveChanges();
        return RedirectToAction("ViewAdmission", new { id });

    }
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admission = await _context.Admissions.Include(m => m.Patient).Include(m => m.Doctor).FirstOrDefaultAsync(m => m.Id == id);
        ViewBag.Patients = _context.Patients.Where(p => !p.IsDeleted).ToList();
        ViewBag.Doctors = _context.Doctors.Where(d => !d.IsDeleted && d.Title == "Specijalista").ToList();
        
        
        if (admission == null)
        {
            return NotFound();
        }
       
        return View(admission);
    }

    private string ToString(string name)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,DateAdmitted,PatientId,Patient,DoctorId,Doctor,Emergency")] Admission admission)
    {
        if (id != admission.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {   
                admission.DateModified= DateTime.Now;
                _context.Update(admission);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmissionExists(admission.Id))
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
        return View(admission);
    }

    



    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var admission = await _context.Admissions.FindAsync(id);
        if (admission != null)
        {   
            admission.IsDeleted = true;
            admission.DateModified= DateTime.Now;
            _context.Admissions.Update(admission);
            await _context.SaveChangesAsync();
        }

        
        return RedirectToAction(nameof(Index));
    }

    private bool AdmissionExists(int id)
    {
        return _context.Admissions.Any(e => e.Id == id);
    }

    }