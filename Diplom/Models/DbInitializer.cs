using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Diplom.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<EquipmentContext>
    {
        protected override void Seed(EquipmentContext context)
        {
            context.Categories.Add(new Category() { Name = "Маршрутизаторы", Id = 1, Image = "~/Content/Images/Categories/router.jpg" });
            context.Categories.Add(new Category() { Name = "Сетевые адаптеры", Id = 2, Image = "~/Content/Images/Categories/adapter.jpg" });
            context.Categories.Add(new Category() { Name = "Кабели", Id = 3, Image = "~/Content/Images/Categories/cabel.jpg" });
            context.Categories.Add(new Category() { Name = "Wi-fi контроллеры", Id = 4, Image = "~/Content/Images/Categories/wifi-control.jpeg" });

            context.Equipments.Add(new Equipment() { Name = "Wi-Fi роутер Cisco 1841", Price = 6400, CategoryId = 1, SignalRate = 500, Image = "~/Content/Images/Equipment/router/archer-20.jpg", Description = "Недорогой  роутер", Text = "Cisco 1841 — маршрутизаторы, ориентированные прежде всего на компании с небольшими и средними офисами. Гибкость в настройке сделали данные модели популярным решением для реализации подключения к корпоративным сетям и Интернету." });
            context.Equipments.Add(new Equipment() { Name = "Wi-Fi роутер Cisco 2911/K9", Price = 21000, CategoryId = 1, SignalRate = 1000, Image = "~/Content/Images/Equipment/router/asus-rt.jpg", Description = "Среднебюджетный маршрутизатор", Text = "Cisco 1841 — маршрутизаторы, ориентированные прежде всего на компании с небольшими и средними офисами. Гибкость в настройке сделали данные модели популярным решением для реализации подключения к корпоративным сетям и Интернету." });
            context.Equipments.Add(new Equipment() { Name = "Wi-Fi роутер Mikrotik Cloud Core Router", Price = 92000, SignalRate = 1000, CategoryId = 1, Image = "~/Content/Images/Equipment/router/giga.jpg", Description = "Премиальный маршрутизатор для любого назначения", Text = "Mikrotik RouterBOARD Cloud Core Router 1036-8G-2S+ является маршрутизатором операторского класса с мощным 36-ти ядерным процессором Tilera CPU!" });

            context.Equipments.Add(new Equipment() { Name = "Приемник Wi-Fi TP-Link TL-WN823N", Price = 640, CategoryId = 2, SignalRate = 500, Image = "~/Content/Images/Equipment/adapter/adapter.jpg", Description = "Недорогой  wi-fi приемник" });
            context.Equipments.Add(new Equipment() { Name = "Приемник Wi-Fi HUAWEI E8372", Price = 3400, CategoryId = 2, SignalRate = 1000, Image = "~/Content/Images/Equipment/adapter/huaw.jpg", Description = "Среднебюджетный модем" });

            context.Equipments.Add(new Equipment() { Name = "Cisco SFP-H10GB", Price = 1500, CategoryId = 3, SignalRate = 500, Image = "~/Content/Images/Equipment/cabel/cisco.jpg", Description = "Кабель 10Gbps" });
            context.Equipments.Add(new Equipment() { Name = "Cablexpert Cat.6", Price = 190, CategoryId = 3, SignalRate = 1000, Image = "~/Content/Images/Equipment/cabel/cablexpert.jpg", Description = "Кабель 500Mbps" });

            context.Equipments.Add(new Equipment() { Name = "Cisco Aironet 2500,", Price = 65000, CategoryId = 4, SignalRate = 500, Image = "~/Content/Images/Equipment/controller/air.jpeg", Description = "Премиальный контроллер wi-fi" });
            context.Equipments.Add(new Equipment() { Name = "ZoneDirector 1100", Price = 35000, CategoryId = 4, SignalRate = 1000, Image = "~/Content/Images/Equipment/controller/zone.jpeg", Description = "Бюджетный контроллер wi-fi" });

            context.Compability.Add(new Compability() { EquipmentId1 = 2, EquipmentId2 = 4, IsCompatible = 3 });
            context.Compability.Add(new Compability() { EquipmentId1 = 3, EquipmentId2 = 4, IsCompatible = 9 });
            context.Compability.Add(new Compability() { EquipmentId1 = 1, EquipmentId2 = 3, IsCompatible = 7 });
            context.Compability.Add(new Compability() { EquipmentId1 = 3, EquipmentId2 = 7, IsCompatible = 9 });
            context.Compability.Add(new Compability() { EquipmentId1 = 2, EquipmentId2 = 5, IsCompatible = 10 });
            context.Compability.Add(new Compability() { EquipmentId1 = 3, EquipmentId2 = 5, IsCompatible = 1 });
            context.Compability.Add(new Compability() { EquipmentId1 = 5, EquipmentId2 = 2, IsCompatible = 10 });
            context.Compability.Add(new Compability() { EquipmentId1 = 5, EquipmentId2 = 3, IsCompatible = 1 });

            context.Projects.Add(new Project() { ProjectId = 1, ProjectData = new DateTime(2020, 5, 1, 8, 30, 52), ProjectName = "Аудитория 21.21", Budget = 150000 });
            context.Projects.Add(new Project() { ProjectId = 2, ProjectData = new DateTime(2020, 12, 2, 2, 30, 52), ProjectName = "Аудитория 22", Budget = 350000 });

            context.ProjectParts.Add(new ProjectPart() { ProjectPartId = 1, ProjectId = 1, EquipmentId = 1, ProjectPartAmount = 3 });
            context.ProjectParts.Add(new ProjectPart() { ProjectPartId = 2, ProjectId = 1, EquipmentId = 3, ProjectPartAmount = 2 });
            context.ProjectParts.Add(new ProjectPart() { ProjectPartId = 3, ProjectId = 1, EquipmentId = 5, ProjectPartAmount = 7 });
            context.ProjectParts.Add(new ProjectPart() { ProjectPartId = 4, ProjectId = 1, EquipmentId = 9, ProjectPartAmount = 2 });

            context.ProjectParts.Add(new ProjectPart() { ProjectPartId = 5, ProjectId = 2, EquipmentId = 2, ProjectPartAmount = 3 });
            context.ProjectParts.Add(new ProjectPart() { ProjectPartId = 6, ProjectId = 2, EquipmentId = 3, ProjectPartAmount = 2 });
            context.ProjectParts.Add(new ProjectPart() { ProjectPartId = 7, ProjectId = 2, EquipmentId = 5, ProjectPartAmount = 3 });
            context.ProjectParts.Add(new ProjectPart() { ProjectPartId = 8, ProjectId = 2, EquipmentId = 8, ProjectPartAmount = 5 });

            context.Users.Add(new User() { Name = "1", UserPassword= "1", IsAdmin = true, UserEmail="1@1", LastName="Petrov", Phone="+721321312", FirstName="Petr", UserImage= "~/Content/Images/User/11.jpg" });
            context.Users.Add(new User() { Name = "2", UserPassword = "2", IsAdmin = false, UserEmail = "2@2", LastName = "Ivanov", Phone = "+72132112", FirstName = "Ivan" });

            context.Sections.Add(new Section() { SectionId = 1, SectionName = "Подбор оборудования", SectionText = "  Этот раздел посвящен подбору оборудования с помощью данного корпоративного портала. Портал позволяет просматривать позиции медицинского оборудования, основную информацию о них, и т.д. ", SectionData = new DateTime(2021, 4, 10) });
            context.Tests.Add(new Test() { TestId = 1, TestName = "Подбор оборудования", TestText = "Данный тест предназначен для оценки усвоения материала из раздела 'Подбор оборудования'", TestData = new DateTime(2021, 4, 10) });
            context.TestsInSections.Add(new TestInSection() { SectionId = 1, TestId = 1, TestInSectionId = 1 });
            context.DoneTests.Add(new DoneTest() { DoneTestId = 1, TestId = 1, UserId = 1 });
            context.Quastions.Add(new Quastion() { QuastionId = 1, QuastionText = "Что не позволяет делать корпоративный портал?", TestId=1});
            context.Quastions.Add(new Quastion() { QuastionId = 2, QuastionText = "Кому доступен раздел подбора оборудования?", TestId = 1 });
            context.Answers.Add(new Answer() { AnswerId = 1, AnswerText = "Отправлять заказ клиенту", IsCorrect = true, QuastionId = 1 });
            context.Answers.Add(new Answer() { AnswerId = 2, AnswerText = "Просматривать позиции оборудования", IsCorrect = false, QuastionId = 1 });
            context.Answers.Add(new Answer() { AnswerId = 3, AnswerText = "Составлять подборку оборудования", IsCorrect = false, QuastionId = 1 });
            context.Answers.Add(new Answer() { AnswerId = 4, AnswerText = "Использовать автоматический алгоритм подбора", IsCorrect = false, QuastionId = 1 });
            context.Answers.Add(new Answer() { AnswerId = 5, AnswerText = "Менеджерам", IsCorrect = false, QuastionId = 2 });
            context.Answers.Add(new Answer() { AnswerId = 6, AnswerText = "Всем сотрудникам", IsCorrect = true, QuastionId = 2 });
            context.Ranks.Add(new Rank() { RankId = 1, RankName="Head"});
            context.Ranks.Add(new Rank() { RankId = 2, RankName = "Manager" });
            context.UsersRanks.Add(new UsersRanks() { UsersRanksId = 1, UserId=1, RankId=1});
            context.UsersRanks.Add(new UsersRanks() { UsersRanksId = 2, UserId = 1, RankId = 2 });
            context.UsersRanks.Add(new UsersRanks() { UsersRanksId = 3, UserId = 2, RankId = 2 });

            context.Rooms.Add(new Room() { RoomId = 1, RoomName = "First room" });
            context.UsersInRooms.Add(new UserInRoom() { UserId = 1, RoomId = 1, UserInRoomId = 1 });
            context.Rooms.Add(new Room() { RoomId = 2, RoomName = "Second room" });
            context.UsersInRooms.Add(new UserInRoom() { UserId = 1, RoomId = 2, UserInRoomId = 2 });
            context.UsersInRooms.Add(new UserInRoom() { UserId = 2, RoomId = 2, UserInRoomId = 3 });
            context.Messages.Add(new Message() { MessageId = 1, RoomId = 1, UserId = 1, Text = "Slava ukraine" });


            base.Seed(context);
        }
    }
}