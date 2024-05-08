using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoList.Models;

public class ToDoContext : DbContext
{
    public DbSet<ToDoElement> ToDoElements { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite(@"Data Source=..\Demo.db");
}