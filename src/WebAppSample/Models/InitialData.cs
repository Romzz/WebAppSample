using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebAppSample.Models
{
    public static class InitilData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Institution.Any())
            {
                var romzz = context.Applicant.Add(
                    new Applicant { LastName = "Jaravata Jr", FirstMidName = "Romulo" }).Entity;
                var ralph = context.Applicant.Add(
                    new Applicant { LastName = "Llaguno", FirstMidName = "Ralph" }).Entity;
                var jm = context.Applicant.Add(
                    new Applicant { LastName = "Manio", FirstMidName = "Jose Mari" }).Entity;

                context.Institution.AddRange(
                    new Institution()
                    {
                        Name = "Polytechnic University of the Philippines",
                        Applicant = romzz
                    },
                    new Institution()
                    {
                        Name = "National University",
                        Applicant = ralph
                    },
                    new Institution()
                    {
                        Name = "University of the Philippines",
                        Applicant = jm
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
