using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Courses.Models;

namespace Courses.Controllers
{
    public class EnrollmentsController : Controller
    {
        private CoursesDbContext db = new CoursesDbContext();

        // GET: Enrollments
        public ActionResult Index()
        {
            var enrollment = db.Enrollment.Include(e => e.Admission).Include(e => e.Course).Include(e => e.Major);
            return View(enrollment.ToList());
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            { 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.AdmissionTermCode = new SelectList(db.Admission, "TermCode", "TermCode");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.MajorId = new SelectList(db.Major, "Id", "Id");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentsId,CourseId,MajorId,AdmissionTermCode,Grade,EnrolledIndicator,PaymentIndicator")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollment.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdmissionTermCode = new SelectList(db.Admission, "TermCode", "TermCode", enrollment.AdmissionTermCode);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", enrollment.CourseId);
            ViewBag.MajorId = new SelectList(db.Major, "Id", "Id", enrollment.MajorId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdmissionTermCode = new SelectList(db.Admission, "TermCode", "TermCode", enrollment.AdmissionTermCode);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", enrollment.CourseId);
            ViewBag.MajorId = new SelectList(db.Major, "Id", "Id", enrollment.MajorId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentsId,CourseId,MajorId,AdmissionTermCode,Grade,EnrolledIndicator,PaymentIndicator")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdmissionTermCode = new SelectList(db.Admission, "TermCode", "TermCode", enrollment.AdmissionTermCode);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", enrollment.CourseId);
            ViewBag.MajorId = new SelectList(db.Major, "Id", "Id", enrollment.MajorId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollment.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Enrollment enrollment = db.Enrollment.Find(id);
            db.Enrollment.Remove(enrollment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowStudentsEnrolled(int Id)
        {
            var coursesRegistered = db.Enrollment.Include(x => x.Students).Where(s => s.StudentsId == Id).ToList();
            return View();
        }
      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
