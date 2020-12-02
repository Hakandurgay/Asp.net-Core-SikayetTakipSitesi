using Microsoft.EntityFrameworkCore.Migrations;

namespace SikayetTakipSitesi.Migrations
{
    public partial class ilkOlusturma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    PK_BRAND_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandStatus = table.Column<bool>(type: "bit", nullable: false),
                    BrandPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.PK_BRAND_ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    PK_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.PK_CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    PK_MEMBER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberStatus = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.PK_MEMBER_ID);
                });

            migrationBuilder.CreateTable(
                name: "BrandCategory",
                columns: table => new
                {
                    BrandsPK_BRAND_ID = table.Column<int>(type: "int", nullable: false),
                    CategoriesPK_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandCategory", x => new { x.BrandsPK_BRAND_ID, x.CategoriesPK_CATEGORY_ID });
                    table.ForeignKey(
                        name: "FK_BrandCategory_Brands_BrandsPK_BRAND_ID",
                        column: x => x.BrandsPK_BRAND_ID,
                        principalTable: "Brands",
                        principalColumn: "PK_BRAND_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandCategory_Categories_CategoriesPK_CATEGORY_ID",
                        column: x => x.CategoriesPK_CATEGORY_ID,
                        principalTable: "Categories",
                        principalColumn: "PK_CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    PK_COMPLAINT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintStatus = table.Column<bool>(type: "bit", nullable: false),
                    ComplaintTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplaintSwitchActive = table.Column<bool>(type: "bit", nullable: false),
                    FK_MEMBER_IDPK_MEMBER_ID = table.Column<int>(type: "int", nullable: true),
                    FK_BRAND_IDPK_BRAND_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.PK_COMPLAINT_ID);
                    table.ForeignKey(
                        name: "FK_Complaints_Brands_FK_BRAND_IDPK_BRAND_ID",
                        column: x => x.FK_BRAND_IDPK_BRAND_ID,
                        principalTable: "Brands",
                        principalColumn: "PK_BRAND_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaints_Members_FK_MEMBER_IDPK_MEMBER_ID",
                        column: x => x.FK_MEMBER_IDPK_MEMBER_ID,
                        principalTable: "Members",
                        principalColumn: "PK_MEMBER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    PK_COMMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentStatus = table.Column<bool>(type: "bit", nullable: false),
                    CommentSwitchActive = table.Column<bool>(type: "bit", nullable: false),
                    FK_COMPLAINT_IDPK_COMPLAINT_ID = table.Column<int>(type: "int", nullable: true),
                    MemberPK_MEMBER_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.PK_COMMENT_ID);
                    table.ForeignKey(
                        name: "FK_Comments_Complaints_FK_COMPLAINT_IDPK_COMPLAINT_ID",
                        column: x => x.FK_COMPLAINT_IDPK_COMPLAINT_ID,
                        principalTable: "Complaints",
                        principalColumn: "PK_COMPLAINT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Members_MemberPK_MEMBER_ID",
                        column: x => x.MemberPK_MEMBER_ID,
                        principalTable: "Members",
                        principalColumn: "PK_MEMBER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandCategory_CategoriesPK_CATEGORY_ID",
                table: "BrandCategory",
                column: "CategoriesPK_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FK_COMPLAINT_IDPK_COMPLAINT_ID",
                table: "Comments",
                column: "FK_COMPLAINT_IDPK_COMPLAINT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MemberPK_MEMBER_ID",
                table: "Comments",
                column: "MemberPK_MEMBER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_FK_BRAND_IDPK_BRAND_ID",
                table: "Complaints",
                column: "FK_BRAND_IDPK_BRAND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_FK_MEMBER_IDPK_MEMBER_ID",
                table: "Complaints",
                column: "FK_MEMBER_IDPK_MEMBER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandCategory");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
