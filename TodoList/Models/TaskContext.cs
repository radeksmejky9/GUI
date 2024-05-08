using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoList.Models;

public class TaskContext : DbContext
{
    public DbSet<TaskItem> TaskItems { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite(@"Data Source=..\Demo.db");
}