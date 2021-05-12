using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace portal_customize.dal.Model
{
    public class HrContext:DbContext
    {
        public  DbSet<Student> Student { get; set; }
        public virtual DbSet<T_Message> Messages { get; set; }
        public DbSet<T_Message_User> MessageUsers { get; set; }
        public DbSet<T_Theme> Themes { get; set; }
        public DbSet<T_Theme_User> ThemeUsers { get; set; }
        public DbSet<T_Theme_Current_User> ThemeCurrentUsers { get; set; }
        public DbSet<T_Badge> Badges { get; set; }
        public DbSet<T_Badge_User> BadgeUsers { get; set; }
        public DbSet<T_Badge_Current_User> BadgeCurrentUsers { get; set; }

        public DbSet<T_Greeting> Greetings { get; set; }
        public DbSet<T_Greeting_Type> GreetingTypes { get; set; }
        public DbSet<T_Link> Links { get; set; }
        public DbSet<T_Link_Users> LinkUsers { get; set; }
        public virtual DbSet<T_Message_Type> MessageTypes { get; set; }
        public HrContext(DbContextOptions<HrContext> options)
            : base(options)
        {
        }

    }
}
