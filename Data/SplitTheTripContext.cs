using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SplitTheTrip.Models;

namespace SplitTheTrip.Data
{
    public class SplitTheTripContext : DbContext
    {
        public SplitTheTripContext(DbContextOptions<SplitTheTripContext> options)
            : base(options)
        {
        }

        public DbSet<SplitTheTrip.Models.TotalExpense> TotalExpenses { get; set; } = default!;
        public DbSet<SplitTheTrip.Models.Group> Groups { get; set; } = default!;
        public DbSet<SplitTheTrip.Models.GroupMember> GroupMembers { get; set; } = default!;
        public DbSet<SplitTheTrip.Models.IndividualExpense> IndividualExpenses { get; set; } = default!;
        public DbSet<SplitTheTrip.Models.User> Users { get; set; } = default!;
    }
}
