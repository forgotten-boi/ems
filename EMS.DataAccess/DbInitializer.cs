using System;
using System.Linq;

namespace EMS.DataAccess
{
    public static class DbInitializer
    {
        private static ProjectDbContext _context;
        public static void Initialize(ProjectDbContext appContext)
        {
            appContext.Database.EnsureCreated();
            _context = appContext;
            if (_context.Employee.Count() == 0)
            {
                _context.Employee.AddRange(
               new Entity.Entities.EmployeeInfo
               {
                   FirstName = "Shova",
                   LastName = "Gupta",
                   PrimaryMobileNo = "9823029023",
                   Location = "New Baneshwor",
                   Email = "info@hotmail.com",
                   Sex = "F",
                   JoiningDate = DateTime.Now.AddYears(-2)
               },
                 new Entity.Entities.EmployeeInfo
                 {
                      //ID = 2,
                      FirstName = "Ram",
                     LastName = "Sharan Gupta",
                     PrimaryMobileNo = "9823029023",
                     Location = "New Baneshwor",
                     Email = "info@gmail.com",
                     Sex = "M",

                     JoiningDate = DateTime.Now.AddYears(-2)
                 },
                   new Entity.Entities.EmployeeInfo
                   {
                        //ID = 3,
                        FirstName = "Hari",
                       LastName = "Sharan Gupta",
                       PrimaryMobileNo = "9823029023",
                       Location = "New Baneshwor",
                       Email = "info@email.com",
                       Sex = "M",

                       JoiningDate = DateTime.Now.AddYears(-2)
                   }
               );
                _context.SaveChanges();
            }
        }
    }
}
