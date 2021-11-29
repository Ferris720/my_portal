using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom.Models;
using System.Net.Http.Headers;

namespace Diplom.Controllers
{
    public class HomeController : Controller
    {
        private static Dictionary<int, Dictionary<int, int>> categoriesCache = new Dictionary<int, Dictionary<int, int>>();

        private static readonly HttpCookieFactory cookieFactory = new HttpCookieFactory();

        private EquipmentContext equipmentContext = Global.equipmentContext;

       // HttpCookie cookie = new HttpCookie("name", "password");
        User currentUser = null;
        public ActionResult First()
        {
            IEnumerable<User> users = equipmentContext.Users;
            ViewBag.Users = users; //дин свойтсво
            ViewBag.CurrentUser = currentUser;
            return View();
        }

        [HttpPost]
        public ActionResult First(string name, string password)
        {
            IEnumerable<User> users = equipmentContext.Users;
            ViewBag.Users = users; //дин свойтсво
            ViewBag.name = name;
            ViewBag.password = password;
            return View();
        }
        

        public ActionResult DoFirst(string name, string password)
        {
            IEnumerable<User> users = equipmentContext.Users;
            if (name == null && password == null)
                return PartialView("IncorrectUser");

            foreach (var user in users)
            {
                if ((user.Name == name || user.UserEmail == name) && user.UserPassword == password)
                {
                    SetUser(user.Name, user.IsAdmin);
                    ViewBag.User = user.Name;
                    return View("CorrectUser");
                }
            }

            return PartialView("IncorrectUser");
        }



        public void SetUser(string login, bool isAdmin)
        {
            var context = System.Web.HttpContext.Current;
            context.Response.Cookies.Add(cookieFactory.Create(login,isAdmin));
        }

        public string[] GetUser()
        {
            var context = System.Web.HttpContext.Current;
            var cookies = context.Request.Cookies["Diplom"];
            string[] arrUser = new[] { cookies["UserLogin"], cookies["IsAdmin"] };
            return arrUser;
        }

        public ActionResult Index()
        {
            IEnumerable<Category> categories = equipmentContext.Categories;
            ViewBag.Categories = categories; //дин свойтсво
            return View();
        }
        public ActionResult MyRooms()
        {
            IEnumerable<Room> rooms  = equipmentContext.Rooms;
            IEnumerable<UserInRoom> usersInRooms = equipmentContext.UsersInRooms;
            IEnumerable<User> users = equipmentContext.Users;
            ViewBag.Rooms = rooms;
            ViewBag.UsersInRooms = usersInRooms;
            ViewBag.User = GetUser();
            ViewBag.Users = users;
            return View();
        }

        [HttpGet]
        public ActionResult Chat(int id)
        {
            IEnumerable<User> users = equipmentContext.Users;
            IEnumerable<Room> rooms = equipmentContext.Rooms;
            ViewBag.Users = users; //дин свойтсво
            ViewBag.CurrentUser = currentUser;
            ViewBag.User = GetUser();
            ViewBag.RoomId = id;
            ViewBag.Rooms = rooms;
            return View();
        }

        [HttpGet]
        public ActionResult Products(int id)
        {
            ViewBag.Id = id;
            IEnumerable<Category> categories = equipmentContext.Categories;
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            ViewBag.Categories = categories; //дин свойтсво
            ViewBag.Equipments = equipments;
            return View();
        }
        public ActionResult LayoutToShow()
        {
            IEnumerable<User> users = equipmentContext.Users;
            ViewBag.User = GetUser();
            return View("LayoutToShow");
        }

        [HttpGet]
        public ActionResult MyProduct(int id)
        {
            ViewBag.Id = id;
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            ViewBag.Equipments = equipments;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page";

            return View();
        }
        [HttpGet]
        public ActionResult Order(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        [HttpPost]
        public string Order(Project project)
        {
            project.ProjectData = DateTime.Now;
            equipmentContext.Projects.Add(project);

            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            ViewBag.Equipments = equipments;

            equipmentContext.SaveChanges();
            string outstr = "Заказ прошел успешно!" + "\n" + "С Вами скоро свяжутся!";
            return outstr;
        }
        string adminPassword = "0000";
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        private ActionResult Admin(string password)
        {
            ViewBag.password = password;
            return View();
        }

        public ActionResult Password_Result(string password = null)
        {
            {
                if (password == adminPassword) ViewBag.wrongpas = adminPassword;
                else if (password != null) ViewBag.wrongpas = "Неверный пароль";
                else ViewBag.wrongpas = "Введите пароль администратора";
                return View("PasswordResult");
            }
        }

        public ActionResult Articles()
        {
            ViewBag.Message = "Тут будут статьи";
            IEnumerable<Category> categories = equipmentContext.Categories;
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;

            ViewBag.Categories = categories;
            ViewBag.Equipments = equipments;


            return View();
        }

        [HttpGet]
        public ActionResult CaregoryRedaction(string password)
        {
            ViewBag.Password = password;
            IEnumerable<Category> categories = equipmentContext.Categories;
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            ViewBag.Categories = categories; //дин свойтсво
            ViewBag.Equipments = equipments;
            return View();
        }

        public ActionResult Search()
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            ViewBag.Equipments = equipments;           
            return View();
        }
        public ActionResult AddToChat(int roomId)
        {
            IEnumerable<Room> rooms = equipmentContext.Rooms;
            IEnumerable<User> users = equipmentContext.Users;
            IEnumerable<UserInRoom> usersInRooms = equipmentContext.UsersInRooms;

            ViewBag.Rooms = rooms;
            ViewBag.Users = users;
            ViewBag.UsersInRooms = usersInRooms;
            ViewBag.RoomId = roomId;

            return View();
        }

        [HttpPost]
        public ActionResult Search(string filter)
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            ViewBag.Equipments = equipments;
            ViewBag.filter = filter;
            return View();
        }
        public ActionResult DoSearch(string filter)
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            List<Equipment> searchEquipment = new List<Equipment>();
            if (filter != null)
            {
                foreach (var eq in equipments)
                {
                    if ((eq.Name.ToLower().Contains(filter.ToLower()))) searchEquipment.Add(eq);
                }
            }
            ViewBag.searchEquipment = searchEquipment;
            return View("Display_Search", searchEquipment);
        }
        public ActionResult Project()
        {
            IEnumerable<Project> projects = equipmentContext.Projects;
            ViewBag.Projects = projects;
            eqIds.Add(1);
            ViewBag.Ids = eqIds;
            return View();
        }

        [HttpGet]
        public ActionResult MakeProject()
        {
            ViewBag.Category = equipmentContext.Categories;
            return View();
        }

        [HttpPost]
        public ActionResult MakeProject(string projectName, int budget, int speed, Dictionary<string, int> categories)
        {
            var project = new Project
            {
                ProjectName = projectName,
                ProjectId = new Random().Next(),
                Budget = budget,
                ProjectData = DateTime.Now,
            };

            equipmentContext.Projects.Add(project);
            equipmentContext.SaveChanges();

            categoriesCache[project.ProjectId] = new Dictionary<int, int>();

            foreach (var category in categories)
                categoriesCache[project.ProjectId][int.Parse(category.Key)] = category.Value;
            //ViewBag.Speed = speed;
            return Redirect($"~/Home/AddEquipment?projectId={project.ProjectId}&speed={speed}");
        }

        public ActionResult AddEquipment(int projectId, int speed)
        {

            IEnumerable<Project> projects = equipmentContext.Projects;
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;

            Project currentProject = projects
                .Where(x => x.ProjectId == projectId).Single();

            Dictionary<int, int> amountOfEquipment = categoriesCache[projectId];
            var firstFilter = equipments.Where(x => x.SignalRate >= speed);
            int summaryBudget = 0;
            Dictionary<int, int> BudgetSet = new Dictionary<int, int>();
            foreach (var i in amountOfEquipment)
            {
                Equipment cheapestEquipment = equipments.First();
                cheapestEquipment.Price = 10000000;
                foreach (var equipment in firstFilter.Where(x => x.CategoryId == i.Key))
                {
                    if (equipment.Price < cheapestEquipment.Price)
                    {
                        cheapestEquipment = equipment;
                    }
                }
                BudgetSet.Add(cheapestEquipment.Id, i.Value);
                summaryBudget += cheapestEquipment.Price * i.Value;
            }

            ViewBag.SummaryBudget = summaryBudget;
            bool mistake;
            if (summaryBudget > currentProject.Budget)
            {
                mistake = true;
            }
            else
            {
                mistake = false;
                ViewBag.BudgetSet = BudgetSet;
            }

            var secondFilter = firstFilter;
            var expensiveSet = BudgetSet;
            int currentBudget = summaryBudget;
            // while (currentBudget < currentProject.Budget*0.9)
            {

            }
            //тут должен быть алгоритм
            //var recomendedEquipments = equipmentContext.Equipments.ToArray();
            //ViewBag.RecomendedEquipments = recomendedEquipments;
            ViewBag.Equipments = equipments;
            ViewBag.Mistake = mistake;

            ViewBag.BudgetSet = BudgetSet;
            ViewBag.ProjectId = projectId;

            var categories = categoriesCache[projectId];

            var bestEquipments = GetBestEquipments(currentProject.Budget, currentProject.ProjectId, speed);

            if (bestEquipments != null)
            {
                var bestEquipmentsDic = new Dictionary<int, int>();
                foreach (var equipment in bestEquipments)
                {
                    var eqContarct = equipments.Single(x => x.Id == equipment);
                    bestEquipmentsDic[equipment] = categories[eqContarct.CategoryId];
                }
                ViewBag.BestEquipment = bestEquipmentsDic;
            }

            return View();
        }

        private List<int> GetBestEquipments(int budget, int projectId, int speed)
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            IEnumerable<Compability> compability = equipmentContext.Compability;
            var estimation = new int[equipments.Count() + 1, equipments.Count() + 1];

            foreach (var equipment in equipments)
            {
                foreach (var equipToestimate in equipments)
                {
                    if (equipment.Id != equipToestimate.Id)
                    {
                        var comp = compability.Where(x => x.EquipmentId1 == equipment.Id & x.EquipmentId2 == equipToestimate.Id).FirstOrDefault();
                        estimation[equipment.Id, equipToestimate.Id] = comp == null ? 5 : comp.IsCompatible;
                    }
                    else
                    {
                        estimation[equipment.Id, equipToestimate.Id] = 5;
                    }
                }
            }

            var categories = categoriesCache[projectId];

            var currentCategories = new Stack<EquipmentCategory>();

            foreach (var cat in categories)
                currentCategories.Push(new EquipmentCategory { CategoryId = cat.Key, Count = cat.Value });

            return GetEquipments(budget, currentCategories, speed)
                .Select(x => new { Equipments = x, Compability = GetCompability(x, estimation) })
                .OrderBy(x => x.Compability)
                .LastOrDefault()?.Equipments;
        }

        private int GetCompability(List<int> equipments, int[,] compabilityMatrix)
        {
            var currentCompability = 0;
            foreach (var eq1 in equipments)
                foreach (var eq2 in equipments)
                    currentCompability += compabilityMatrix[eq1, eq2];

            return currentCompability;
        }

        private IEnumerable<List<int>> GetEquipments(int budget, Stack<EquipmentCategory> currentCategories, int speed)
        {
            var category = currentCategories.Pop();
            var equipments = equipmentContext.Equipments.Where(x => x.CategoryId == category.CategoryId && x.SignalRate >= speed);
            foreach (var equipment in equipments)
            {
                if (budget - equipment.Price * category.Count < 0)
                    continue;

                if (currentCategories.Count == 0)
                {
                    var list = new List<int>();
                    list.Add(equipment.Id);
                    yield return list;
                }
                else
                {
                    foreach (var list in GetEquipments(budget - equipment.Price * category.Count, currentCategories, speed))
                    {
                        list.Add(equipment.Id);
                        yield return list;
                    }
                }
            }
            currentCategories.Push(category);
        }

        private class EquipmentCategory
        {
            public int CategoryId { get; set; }
            public int Count { get; set; }
        }

        [HttpPost]
        //как передавать?
        public ActionResult AddEquipment(int projectId, Dictionary<string, int> equipments)
        {
            //validatePrice

            foreach (var equipment in equipments)
            {
                var projectPart = new ProjectPart
                {
                    ProjectPartId = new Random().Next(),
                    ProjectId = projectId,
                    ProjectPartAmount = equipment.Value,
                    EquipmentId = int.Parse(equipment.Key),
                };

                equipmentContext.ProjectParts.Add(projectPart);
            }

            equipmentContext.SaveChanges();

            return View("SuccessfulProject")/*"Проект успешно добавлен!"*/;
        }

        [HttpGet]
        public ActionResult AddItem (int id)
        {
            ViewBag.Id = id;
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            List<Equipment> searchEquipment = new List<Equipment>();            
            {
                eqIds.Add(id);
            }
            ViewBag.Equipments = equipments;
            ViewBag.Ids = eqIds;
            return View("Display_Search", searchEquipment);

        }
        //[HttpGet]
        //public ActionResult MyProject(int id)
        //{
        //    ViewBag.Id = id;
        //    IEnumerable<Project> projects = equipmentContext.Projects;
        //    IEnumerable<Equipment> equipments = equipmentContext.Equipments;
        //    IEnumerable<ProjectPart> projectparts = equipmentContext.ProjectParts;
        //    ViewBag.Projects = projects;
        //    ViewBag.ProjectParts = projectparts;
        //    ViewBag.Equipment = equipments;
        //    return View();
        //}


        public class AmountOfEquipment
        {
            public Equipment equipment;
            public int amount;
        }

        [HttpGet]
        public ActionResult MyProject(int id)
        {
            IEnumerable<Project> projects = equipmentContext.Projects;
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            IEnumerable<ProjectPart> projectparts = equipmentContext.ProjectParts;
            List<AmountOfEquipment> searchEquipment = new List<AmountOfEquipment>();

            Equipment myequip = new Equipment();
            int amount = 0;

            foreach (ProjectPart projectpart in projectparts)
            {
                if (projectpart.ProjectId == id)
                {
                    amount = 0;
                    foreach (var equipment in equipments)
                    {
                        if (projectpart.EquipmentId == equipment.Id)
                        {
                            amount = amount + projectpart.ProjectPartAmount;
                            AmountOfEquipment amountOfEquipment = new AmountOfEquipment();
                            amountOfEquipment.equipment = equipment;
                            amountOfEquipment.amount = amount;
                            searchEquipment.Add(amountOfEquipment);
                        }
                    }
                }
            }
            ViewBag.searchEquipment = searchEquipment;

            //ViewBag.searchEquipment=
            ViewBag.projectId = id;
            return View("MyProject", searchEquipment);
        }

        public ActionResult InfOffice()
        {
            IEnumerable<User> users = equipmentContext.Users;
            IEnumerable<UsersRanks> usersRanks = equipmentContext.UsersRanks;
            IEnumerable<Rank> ranks = equipmentContext.Ranks;
            ViewBag.Users = users;
            ViewBag.UsersRanks = usersRanks;
            ViewBag.Ranks = ranks;
            return View();
        }


        [HttpPost]
        public ActionResult InfOffice(string filter)
        {
            IEnumerable<User> users = equipmentContext.Users;
            IEnumerable<UsersRanks> usersRanks = equipmentContext.UsersRanks;
            IEnumerable<Rank> ranks = equipmentContext.Ranks;
            ViewBag.Users = users;
            ViewBag.UsersRanks = usersRanks;
            ViewBag.Ranks = ranks;
            return View();
        }

        public ActionResult DoInfOffice(string filter)
        {
            IEnumerable<User> users = equipmentContext.Users;
            IEnumerable<UsersRanks> usersRanks = equipmentContext.UsersRanks;
            IEnumerable<Rank> ranks = equipmentContext.Ranks;
            List<User> searchUser = new List<User>();
            if (filter != null)
            {
                foreach (var user in users)
                {
                    if ((user.Name.ToLower().Contains(filter.ToLower())) || (user.LastName.ToLower().Contains(filter.ToLower()))) searchUser.Add(user);
                }
                foreach (var rank in ranks)
                {
                    if (rank.RankName.ToLower().Contains(filter.ToLower()))
                    {
                        foreach (var rankUser in usersRanks)
                        {
                            if (rankUser.RankId == rank.RankId)
                            {
                                foreach (var user in users)
                                {
                                    if (user.UserId==rankUser.UserId && !searchUser.Contains(user)) searchUser.Add(user);
                                }
                            }
                        }
                    }
                }
            }
            ViewBag.Users = users;
            ViewBag.UsersRanks = usersRanks;
            ViewBag.Ranks = ranks;
            ViewBag.searchUser = searchUser;
            return View("InfOfficeResult", searchUser);
        }




        public Cart GetCart()
        {

            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        List<int> eqIds = new List<int>();
        
        public ActionResult AddToCart(int eqId)
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            Equipment equipment = equipments
                .FirstOrDefault(x => x.Id == eqId);
            if (equipment != null)
            {
                GetCart().AddItem(equipment, 1);
                eqIds.Add(equipment.Id);
            }
            return RedirectToAction("CartIndex");
        }
        public RedirectToRouteResult RemoveFromCart(int eqId, string returnUrl)
        {
            IEnumerable<Equipment> equipments = equipmentContext.Equipments;
            Equipment equipment = equipments
                .FirstOrDefault(x => x.Id == eqId);
            if (equipment != null)
            {
                GetCart().RemoveLine(equipment);
            }
            return RedirectToAction("CartIndex", new { returnUrl });
        }
        public ViewResult CartIndex(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });

        }
    }
}