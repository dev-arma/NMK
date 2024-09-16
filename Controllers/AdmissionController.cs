using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMK.Data;
using NMK.Models;
using DinkToPdf;
using DinkToPdf.Contracts;



namespace NMK.Controllers;

public class AdmissionController : Controller
{
    private readonly NMKDbContext _context;
    private readonly IConverter _converter;

    public AdmissionController(NMKDbContext context, IConverter converter)
    {
        _context = context;
        _converter = converter;
    }
    public async Task<IActionResult> Index()
    {   
        
        
        var admissions = await _context.Admissions
                        .Include(a => a.Patient)
                        .Include(a => a.Doctor)
                        .Where(a => !a.IsDeleted)
                        .ToListAsync();
        return View(admissions);
        

    }
    
    public async Task <IActionResult> FilterAdmissions(DateTime? DateFrom, DateTime? DateTo)
    {   
        
        var admissionsQuery = _context.Admissions
                        .Include(a => a.Patient)
                        .Include(a => a.Doctor)
                        .Where(a => !a.IsDeleted);

    if (DateFrom != null)
    {
        admissionsQuery = admissionsQuery.Where(a => a.DateAdmitted >= DateFrom);
    }

    if (DateTo != null)
    {
        admissionsQuery = admissionsQuery.Where(a => a.DateAdmitted <= DateTo);
    }

    var admissions = await admissionsQuery.ToListAsync();
    
    
    return PartialView("_AdmissionsTable", admissions);
        
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
            admission.DateAdded = DateTime.Now;
            _context.Admissions.Add(admission);
            _context.SaveChanges();
            
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

    public async Task<IActionResult> GeneratePDF(int? id)
    {
        var admission = await _context.Admissions
                                .Include(a => a.Patient)
                                .Include(a => a.Doctor)
                                .FirstOrDefaultAsync(a => a.Id == id);
        
        var htmlContent = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset='utf-8'>
            <title>NMK Nalaz</title>
            <style>
                body {{ font-family: Arial, sans-serif; margin: 0; padding: 0; }}
                h1 {{ color: #333; }}
                table {{ width: 100%; border-collapse: collapse; }}
                th, td {{ padding: 8px; border: 1px solid #ddd; }}
            </style>
        </head>
        <body>
            <h1>Medicinski nalaz</h1>
            <h3>Informacije o pacijentu</h3>
            <p><strong>Ime:</strong> {admission.Patient.NameAndSurname}</p>
            <p><strong>Datum rođenja:</strong> {admission.Patient.DateOfBirth:dd/MM/yyyy}</p>

            <h3>Informacije o liječniku</h3>
            <p><strong>Ime:</strong> {admission.Doctor.Name}</p>
            <p><strong>Prezime:</strong> dr {admission.Doctor.Surname}</p>
            <p><strong>Šifra:</strong> {admission.Doctor.DoctorCode}</p>

            <h3>Detalji nalaza</h3>
            <p><strong>Datum:</strong> {admission.ReportDate:dd/MM/yyyy}</p>
            
            <table>
                <thead>
                    <tr>
                        <th>Dijagnoza</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>{admission.ReportText}</td>
                    </tr>
                </tbody>
            </table>
            <h1>Naša Mala Klinika</h1>
        </body>
        </html>";

        var pdfDocument = new HtmlToPdfDocument
        {
            GlobalSettings = {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4
            },
            Objects = {
                new ObjectSettings
                {
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
        };

        var pdf = _converter.Convert(pdfDocument);

        return File(pdf, "application/pdf", $"NMK_NalazSpecijaliste_{admission.Patient.NameAndSurname}.pdf");
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
        admission.ReportDate = DateTime.Now;
        admission.DateModified = DateTime.Now;
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