using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom.Models;
using static Diplom.Global;

namespace Diplom.Controllers
{
    public class EducationController: Controller
    {
        static private EquipmentContext equipmentContext = new EquipmentContext();

        public ActionResult AllEducation()
        {
            IEnumerable<Section> sections = equipmentContext.Sections;
            ViewBag.Sections = sections;
            return View();
        }
        
        [HttpGet]
        public ActionResult Section(int id)
        {
            IEnumerable<User> users = equipmentContext.Users;
            IEnumerable<DoneTest> doneTests = equipmentContext.DoneTests;
            IEnumerable<Section> sections = equipmentContext.Sections;
            IEnumerable<Test> tests = equipmentContext.Tests;
            IEnumerable<TestInSection> testsInSections = equipmentContext.TestsInSections;
            int userId = 0;
            foreach (var user in users)
            {
                if (user.Name == GetUser()[0] || user.UserEmail == GetUser()[0])
                {
                    userId = user.UserId;
                }
            }
            ViewBag.UserId = userId;
            ViewBag.Section = sections; //дин свойтсво
            ViewBag.Tests = tests;
            ViewBag.TestsInSections = testsInSections;
            ViewBag.Id = id;
            ViewBag.DoneTest = doneTests;
            currentSection = id;
            return View();
        }
        [HttpGet]
        public ActionResult Test(int id)
        {
            Random rand = new Random();
            IEnumerable<Quastion> quastions = equipmentContext.Quastions;
            IEnumerable<Test> tests = equipmentContext.Tests;
            IEnumerable<Answer> answers = equipmentContext.Answers;
            //IEnumerable<QuastionsInTests> quastionsInTests = equipmentContext.QuastionsInTests;
            //int r = 0;
            //bool b = false;
            //List<int> list = new List<int>();
            //while (b == false)
            //{
            //    r = rand.Next(0, 4);
            //    if (!list.Contains(r))
            //        list.Add(r);
            //    if (list.Count() == 4) b = true;
            //}
            ViewBag.Quastions = quastions; //дин свойтсво
            ViewBag.Tests = tests;
            //ViewBag.QuastionsInTests = quastionsInTests;
            ViewBag.Id = id;
            ViewBag.Answers = answers;
            //ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Test(FormCollection coll)
        {
            IEnumerable<Quastion> quastions = equipmentContext.Quastions;
            IEnumerable<DoneTest> doneTests = equipmentContext.DoneTests;
            IEnumerable<User> users = equipmentContext.Users;
            IEnumerable<Test> tests = equipmentContext.Tests;
            IEnumerable<Answer> answers = equipmentContext.Answers;

            int userId=0;
            foreach (var user in users)
            {
                if (user.Name == GetUser()[0] || user.UserEmail == GetUser()[0])
                {
                    userId = user.UserId;
                }
            }

            var testId = 0;
            var myAnswers = new Dictionary<int, string>();
            int count = 0;
            int countRight = 0;
            var keys = coll.Keys;
            double result=0;
            string testName;
            foreach(string key in keys)
            {
                if (key == "TestId")
                {
                    testId = int.Parse(coll[key]);
                }
                else
                {
                    var questionId = int.Parse(key);
                    var answer = coll[key];
                    myAnswers[questionId] = answer;
                }
            }

            foreach(var question in quastions.Where(q => q.TestId == testId))
            {
                var answer = myAnswers[question.QuastionId];
                count++;
                foreach (var ans in answers)
                {
                    if (ans.QuastionId==question.QuastionId && ans.IsCorrect==true && answer==ans.AnswerId.ToString()) countRight++;
                }
                //if (answer == question.RightAnswer)
                //{
                //    countRight++;
                //}
                result = countRight*10 / count;
            }

            if (doneTests.Any(x => x.UserId == userId && x.TestId == testId))
            {
                foreach (var done in doneTests)
                {
                    if (done.UserId == userId && done.TestId == testId)
                    {
                        if (result > done.MaxResult) done.MaxResult = result;
                    }
                }
            }
            else
            {
                equipmentContext.DoneTests.Add(new DoneTest() { UserId = userId, TestId = testId, MaxResult = result });
                equipmentContext.SaveChanges();
            }
            

            ViewBag.count = count;
            ViewBag.countRight = countRight;
            ViewBag.UserId = userId;
            ViewBag.TestId = testId;
            ViewBag.Tests = tests;
            ViewBag.currentSection = currentSection;
            return View("TestResult");
        }
        private static readonly HttpCookieFactory cookieFactory = new HttpCookieFactory();
        public ActionResult LayoutToShow()
        {
            IEnumerable<User> users = equipmentContext.Users;
            ViewBag.User = GetUser();
            return View("LayoutToShow");
        }
        public void SetUser(string login, bool isAdmin)
        {
            var context = System.Web.HttpContext.Current;
            context.Response.Cookies.Add(cookieFactory.Create(login, isAdmin));
        }

        public string[] GetUser()
        {
            var context = System.Web.HttpContext.Current;
            var cookies = context.Request.Cookies["Diplom"];
            string[] arrUser = new[] { cookies["UserLogin"], cookies["IsAdmin"] };
            return arrUser;
        }
    }
}