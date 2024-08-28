using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1
{
    public class StartUp
    {
        public void UpdateDatabase()
        {
            using (var context = new DBContext())
            {
                Console.WriteLine("Updating database...");
                context.Database.Migrate();
            }
        }
    }
}
