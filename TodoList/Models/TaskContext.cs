using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoList.Models;

public class TaskContext : DbContext
{
    public DbSet<TaskItemModel> TaskItems { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite(@"Data Source=..\Demo.db");

}