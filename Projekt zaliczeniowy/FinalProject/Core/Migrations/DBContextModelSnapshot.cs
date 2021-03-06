// <auto-generated />
using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Migrations
{
    [DbContext(typeof(Core.Entities.AppContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Authors", b =>
                {
                    b.Property<int>("AId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AGID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ALastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AMiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BooksBId")
                        .HasColumnType("int");

                    b.HasKey("AId");

                    b.HasIndex("BooksBId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Core.Entities.Books", b =>
                {
                    b.Property<int>("BId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BPublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomersCId")
                        .HasColumnType("int");

                    b.HasKey("BId");

                    b.HasIndex("CustomersCId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Core.Entities.Customers", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CCardCode")
                        .HasColumnType("int");

                    b.Property<string>("CFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Core.Entities.Librarians", b =>
                {
                    b.Property<int>("LId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LId");

                    b.ToTable("Librarians");
                });

            modelBuilder.Entity("Core.Entities.Role", b =>
                {
                    b.Property<int>("RID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ULastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ULogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UID");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Authors", b =>
                {
                    b.HasOne("Core.Entities.Books", null)
                        .WithMany("BAuthors")
                        .HasForeignKey("BooksBId");
                });

            modelBuilder.Entity("Core.Entities.Books", b =>
                {
                    b.HasOne("Core.Entities.Customers", null)
                        .WithMany("CBooks")
                        .HasForeignKey("CustomersCId");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasOne("Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Entities.Books", b =>
                {
                    b.Navigation("BAuthors");
                });

            modelBuilder.Entity("Core.Entities.Customers", b =>
                {
                    b.Navigation("CBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
