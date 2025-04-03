using jurnal_poseshenia.Data;
using jurnal_poseshenia.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace jurnal_poseshenia.Migration
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("jurnal_poseshenia.Model.Student", b =>
            {
                b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                b.Property<string>("Partomymic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                b.HasKey("Id");

                b.ToTable("Student");

            });

            modelBuilder.Entity("jurnal_poseshenia.Model.Specialti", b =>
            {
                b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                b.Property<int>("TermОfStudy")
                       .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Specialti");

            });

            modelBuilder.Entity("jurnal_poseshenia.Model.Jurnal", b =>
            {
                b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                b.Property<int>("StudentId")
                        .HasColumnType("int");

                b.Property<int>("SpecialtiId")
                        .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("SpecialtiIdId");

               b.HasIndex("StudentId");

                b.ToTable("Jurnal");

            });

            modelBuilder.Entity("StudentLibrary.Model.Jurnal", b =>
            {
                b.HasOne("StudentLibrary.Model.Specialti", "Specialti")
                    .WithMany()
                    .HasForeignKey("SpecialtiId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("StudentLibrary.Model.Student", "Student")
                    .WithMany()
                    .HasForeignKey("StudentId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Specialti");

                b.Navigation("Student");
            });

#pragma warning restore 612, 618
        }
    }   }
