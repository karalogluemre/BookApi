﻿// <auto-generated />
using System;
using Books.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Books.Persistence.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20211210144031_StoredProcedureCreation")]
    partial class StoredProcedureCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Books.BookContext.Domain.Authors.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author", "BookContext");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fee18763-f513-4551-8289-b61319106f52"),
                            Name = "William Shakespeare"
                        },
                        new
                        {
                            Id = new Guid("bf33feb2-c511-4963-9f05-ca8b4df45cd0"),
                            Name = "William Faulkner"
                        },
                        new
                        {
                            Id = new Guid("82a0e012-37b4-46e9-8ca0-3201267b8591"),
                            Name = "Henry James"
                        },
                        new
                        {
                            Id = new Guid("f1132362-63c6-4022-800e-69fd2286b89f"),
                            Name = "Jane Austen"
                        });
                });

            modelBuilder.Entity("Books.BookContext.Domain.Bookss.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<Guid>("SubTypeId")
                        .HasColumnType("UniqueIdentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SubTypeId");

                    b.ToTable("Book", "BookContext");
                });

            modelBuilder.Entity("Books.BookContext.Domain.Types.SubType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("UniqueIdentifier");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("SubType", "BookContext");

                    b.HasData(
                        new
                        {
                            Id = new Guid("911ff0cb-7d4a-4879-b643-ea51ac38462c"),
                            Name = "Painting",
                            TypeId = new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85")
                        },
                        new
                        {
                            Id = new Guid("317a18b2-6d20-44ec-879c-c28bcf715831"),
                            Name = "Poems",
                            TypeId = new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85")
                        },
                        new
                        {
                            Id = new Guid("55c77642-8138-4c12-8dad-aeb665cd96b0"),
                            Name = "Adventure",
                            TypeId = new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85")
                        },
                        new
                        {
                            Id = new Guid("6c15ec1e-c5d0-4688-bc81-ea026e8f2bc8"),
                            Name = "Detective and Mystery",
                            TypeId = new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce")
                        },
                        new
                        {
                            Id = new Guid("28f5f732-e5cd-424e-9061-9f078f463bbc"),
                            Name = "Fantasy",
                            TypeId = new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce")
                        },
                        new
                        {
                            Id = new Guid("24fe8f6b-4427-4503-9b21-e343f99e7312"),
                            Name = "Horror",
                            TypeId = new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce")
                        },
                        new
                        {
                            Id = new Guid("ba54ed17-1290-4538-86e0-a25488398676"),
                            Name = "Literary Fiction",
                            TypeId = new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce")
                        });
                });

            modelBuilder.Entity("Books.BookContext.Domain.Types.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Type", "BookContext");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f3a92796-e896-47d3-8311-92f6ecc97f85"),
                            Name = "Children"
                        },
                        new
                        {
                            Id = new Guid("6b27f3ee-acc9-4cda-bf3a-a7311b2c00ce"),
                            Name = "Adult"
                        });
                });

            modelBuilder.Entity("Books.BookContext.Domain.Bookss.Book", b =>
                {
                    b.HasOne("Books.BookContext.Domain.Authors.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Books.BookContext.Domain.Types.SubType", null)
                        .WithMany()
                        .HasForeignKey("SubTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Books.BookContext.Domain.Types.SubType", b =>
                {
                    b.HasOne("Books.BookContext.Domain.Types.Type", "Type")
                        .WithMany("SubTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Books.BookContext.Domain.Types.Type", b =>
                {
                    b.Navigation("SubTypes");
                });
#pragma warning restore 612, 618
        }
    }
}