using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailsApp.Models
{
    public class TestData
    {
        public static void Seed(AppDbContext cctx)
        {
            cctx.Database.EnsureCreated();

            if (cctx.Users.Any())
            {
                return;
            }

            User[] users = new User[]
            {
                new User{Title="Mr",FirstName="Wole",LastName="Dele",Gender="M",DoB=new DateTime(1989,04,19,00,12,54),Username="Wols",Password="wolexy",PasswordConf="wolexy"},
                new User{Title="Miss",FirstName="Olaide",LastName="Adesopo",Gender="F",DoB=new DateTime(1992,07,25,15,22,10),Username="MzOlaide",Password="cut007",PasswordConf="cut7"},
                new User{Title="Miss",FirstName="Gbemisola",LastName="Odunsi",Gender="F",DoB=new DateTime(1991,10,08,12,59,01),Username="Lizzy",Password="oduns1",PasswordConf="odun"},
            };

            foreach (User u in users)
            {
                cctx.Users.Add(u);
            }

            cctx.SaveChanges();
        }
    }
}
