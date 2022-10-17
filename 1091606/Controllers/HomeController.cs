using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using _1091606.Models;
using PagedList;

namespace _1091606.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ProjectModelEntities db = new ProjectModelEntities();   
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); //登出
            return RedirectToAction("../index.html");
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string txtUid, string txtPwd)
        {
            var result = db.TableStudents1091606
                .Where(m => m.sLogin == txtUid && m.sPwd == txtPwd)
                .FirstOrDefault();
            if (result == null)
            {
                ViewBag.Err = "帳密錯誤!";
            }
            else
            {
                //表單驗證服務，授權指定的帳號
                FormsAuthentication.RedirectFromLoginPage(result.sLogin, true);
                return RedirectToAction("LoginAllpageIndex");
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(TableStudents1091606 stu)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;
                var temp = db.TableStudents1091606
                    .Where(m => m.sLogin == stu.sLogin)
                    .FirstOrDefault();
                if (temp != null)
                {
                    ViewBag.Error = true;
                    return View(stu);
                }
                db.TableStudents1091606.Add(stu);
                db.SaveChanges();
                return RedirectToAction("../index.html");
            }
            return View(stu);
        }
        [AllowAnonymous]
        public ActionResult TeacherIndex(int cId = 1)
        {

            ViewBag.cName = db.TableClasss1091606
                .Where(m => m.cId == cId)
                .FirstOrDefault().cName;
            Project project = new Project()
            {
                Class = db.TableClasss1091606.ToList(),
                Teacher = db.TableTeachers1091606
                    .Where(m => m.cId == cId).ToList()
            };
            return View(project);

        }
        [AllowAnonymous]
        public ActionResult AllpageIndex(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page;
            ViewBag.cName = "全部";
            int pageSize = 10;
            ViewBag.count = db.TableClasss1091606.Count();
            ViewBag.class01 = db.TableClasss1091606.ToList();
            var teacher = db.TableTeachers1091606.OrderBy(m => m.cId).ToList();
            var result = teacher.ToPagedList(currentPage, pageSize);

            return View(result);
        }
        public ActionResult LoginTeacherIndex(int cId = 1)
        {

            ViewBag.cName = db.TableClasss1091606
                .Where(m => m.cId == cId)
                .FirstOrDefault().cName;
            Project project = new Project()
            {
                Class = db.TableClasss1091606.ToList(),
                Teacher = db.TableTeachers1091606
                    .Where(m => m.cId == cId).ToList()
            };
            return View(project);

        }
        public ActionResult LoginAllpageIndex(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page;
            ViewBag.cName = "全部";
            int pageSize = 10;
            ViewBag.count = db.TableClasss1091606.Count();
            ViewBag.class01 = db.TableClasss1091606.ToList();
            var teacher = db.TableTeachers1091606.OrderBy(m => m.cId).ToList();
            var result = teacher.ToPagedList(currentPage, pageSize);

            return View(result);
        }
        public ActionResult Cart()
        {
            string sLogin = User.Identity.Name;
            var cart = db.TableCarts1091606
                .Where(m => m.sLogin == sLogin)
                .ToList();
            int total = 0;
            foreach(var item in cart)
            {
                total += item.TableTeachers1091606.tPrice.Value;
            }
            ViewBag.total = total;
            return View(cart);
        }
        public ActionResult CartDelete(int carId = 1)
        {
            var cart = db.TableCarts1091606
                .Where(m => m.cartId == carId)
                .FirstOrDefault();
            db.TableCarts1091606.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Cart");
        }
        public ActionResult CartAdd(int tId = 1)
        {
            string UserId = User.Identity.Name;
            var temp = db.TableCarts1091606
                .Where(m => m.tId == tId && m.sLogin == User.Identity.Name)
                .FirstOrDefault();
            if(temp != null)
            {
                ViewBag.Err = "已經將此老師加到購物車";
            }
            else
            {
                TableCarts1091606 tableCarts = new TableCarts1091606();
                tableCarts.sLogin = UserId;
                tableCarts.tId = tId;
                db.TableCarts1091606.Add(tableCarts);
                db.SaveChanges();
            }
            return RedirectToAction("Cart");
        }
        public ActionResult StudentIndex(string login)
        {
            login = User.Identity.Name;
            var student = db.TableStudents1091606
                .Where(m => m.sLogin == login)
                .FirstOrDefault();
            return View(student);
        }
        public ActionResult StudentEdit(string login)
        {
            var student = db.TableStudents1091606
                .Where(m => m.sLogin == login)
                .FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult StudentEdit(TableStudents1091606 tableStudents)
        {
            if(ModelState.IsValid)
            {
                var temp = db.TableStudents1091606
                    .Where(m => m.sLogin == tableStudents.sLogin)
                    .FirstOrDefault();
                temp.sName = tableStudents.sName;
                temp.sPwd = tableStudents.sPwd;
                temp.sEmail = tableStudents.sEmail;
                temp.sPhone = tableStudents.sPhone;
                db.SaveChanges();
                return RedirectToAction("StudentIndex");
            }
            return View(tableStudents);
        } 
    }
}