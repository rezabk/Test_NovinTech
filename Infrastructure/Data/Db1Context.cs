using System;
using System.Collections.Generic;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Test_NovinTech;

public partial class Db1Context : DbContext
{
    private readonly IMediator _mediator;
    public DbSet<Item> Items { get; set; }

    public Db1Context()
    {
    }

    public Db1Context(DbContextOptions<Db1Context> options,IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=db1;uid=webapi;pwd=12345678", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.4.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
