﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Vinder.DAL.Configuration;

namespace Vinder.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161127050051_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vinder.DAL.Domain.Emotion", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<decimal>("Anger");

                    b.Property<decimal>("Disgust");

                    b.Property<decimal>("Fear");

                    b.Property<decimal>("Joy");

                    b.Property<decimal>("Sadness");

                    b.Property<decimal>("Surprise");

                    b.HasKey("Id");

                    b.ToTable("Emotions");
                });

            modelBuilder.Entity("Vinder.DAL.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name");

                    b.Property<string>("Sex");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Vinder.DAL.Domain.Emotion", b =>
                {
                    b.HasOne("Vinder.DAL.Domain.User", "User")
                        .WithOne("Emotion")
                        .HasForeignKey("Vinder.DAL.Domain.Emotion", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
