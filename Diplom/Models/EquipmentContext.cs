using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Diplom.Models
{
    public class EquipmentContext: DbContext // БД
    {
        public DbSet<Equipment> Equipments { get; set; } //Таблицы
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects{ get; set; }
        public DbSet<ProjectPart> ProjectParts { get; set; }
        public DbSet<Compability> Compability { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Quastion> Quastions { get; set; }
        public DbSet<TestInSection> TestsInSections { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<DoneTest> DoneTests{ get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<UsersRanks> UsersRanks { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserInRoom> UsersInRooms { get; set; }
        public DbSet<Message> Messages { get; set; }


        //public DbSet<Cart> Cart { get; set; }
    }
}