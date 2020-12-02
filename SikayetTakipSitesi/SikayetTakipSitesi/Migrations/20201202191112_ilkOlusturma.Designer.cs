﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SikayetTakipSitesi.Data;

namespace SikayetTakipSitesi.Migrations
{
    [DbContext(typeof(SikayetDbContext))]
    [Migration("20201202191112_ilkOlusturma")]
    partial class ilkOlusturma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BrandCategory", b =>
                {
                    b.Property<int>("BrandsPK_BRAND_ID")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesPK_CATEGORY_ID")
                        .HasColumnType("int");

                    b.HasKey("BrandsPK_BRAND_ID", "CategoriesPK_CATEGORY_ID");

                    b.HasIndex("CategoriesPK_CATEGORY_ID");

                    b.ToTable("BrandCategory");
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Brand", b =>
                {
                    b.Property<int>("PK_BRAND_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BrandStatus")
                        .HasColumnType("bit");

                    b.HasKey("PK_BRAND_ID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Category", b =>
                {
                    b.Property<int>("PK_CATEGORY_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("bit");

                    b.HasKey("PK_CATEGORY_ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Comment", b =>
                {
                    b.Property<int>("PK_COMMENT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CommentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CommentStatus")
                        .HasColumnType("bit");

                    b.Property<bool>("CommentSwitchActive")
                        .HasColumnType("bit");

                    b.Property<int?>("FK_COMPLAINT_IDPK_COMPLAINT_ID")
                        .HasColumnType("int");

                    b.Property<int?>("MemberPK_MEMBER_ID")
                        .HasColumnType("int");

                    b.HasKey("PK_COMMENT_ID");

                    b.HasIndex("FK_COMPLAINT_IDPK_COMPLAINT_ID");

                    b.HasIndex("MemberPK_MEMBER_ID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Complaint", b =>
                {
                    b.Property<int>("PK_COMPLAINT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ComplaintContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ComplaintStatus")
                        .HasColumnType("bit");

                    b.Property<bool>("ComplaintSwitchActive")
                        .HasColumnType("bit");

                    b.Property<string>("ComplaintTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FK_BRAND_IDPK_BRAND_ID")
                        .HasColumnType("int");

                    b.Property<int?>("FK_MEMBER_IDPK_MEMBER_ID")
                        .HasColumnType("int");

                    b.HasKey("PK_COMPLAINT_ID");

                    b.HasIndex("FK_BRAND_IDPK_BRAND_ID");

                    b.HasIndex("FK_MEMBER_IDPK_MEMBER_ID");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Member", b =>
                {
                    b.Property<int>("PK_MEMBER_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MemberLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MemberStatus")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("PK_MEMBER_ID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("BrandCategory", b =>
                {
                    b.HasOne("SikayetTakipSitesi.Models.Brand", null)
                        .WithMany()
                        .HasForeignKey("BrandsPK_BRAND_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SikayetTakipSitesi.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesPK_CATEGORY_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Comment", b =>
                {
                    b.HasOne("SikayetTakipSitesi.Models.Complaint", "FK_COMPLAINT_ID")
                        .WithMany("Comments")
                        .HasForeignKey("FK_COMPLAINT_IDPK_COMPLAINT_ID");

                    b.HasOne("SikayetTakipSitesi.Models.Member", null)
                        .WithMany("Comments")
                        .HasForeignKey("MemberPK_MEMBER_ID");

                    b.Navigation("FK_COMPLAINT_ID");
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Complaint", b =>
                {
                    b.HasOne("SikayetTakipSitesi.Models.Brand", "FK_BRAND_ID")
                        .WithMany("Complaints")
                        .HasForeignKey("FK_BRAND_IDPK_BRAND_ID");

                    b.HasOne("SikayetTakipSitesi.Models.Member", "FK_MEMBER_ID")
                        .WithMany("Complaints")
                        .HasForeignKey("FK_MEMBER_IDPK_MEMBER_ID");

                    b.Navigation("FK_BRAND_ID");

                    b.Navigation("FK_MEMBER_ID");
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Brand", b =>
                {
                    b.Navigation("Complaints");
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Complaint", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("SikayetTakipSitesi.Models.Member", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Complaints");
                });
#pragma warning restore 612, 618
        }
    }
}
