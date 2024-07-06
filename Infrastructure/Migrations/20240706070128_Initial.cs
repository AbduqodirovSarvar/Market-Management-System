using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NameUz = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameRu = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasureOfTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NameUz = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameRu = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DescriptionUz = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionRu = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureOfTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NameUz = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameRu = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DescriptionUz = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionRu = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NameUz = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameRu = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MeasureOfTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NameUz = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameRu = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DescriptionUz = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionRu = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypes_MeasureOfTypes_MeasureOfTypeId",
                        column: x => x.MeasureOfTypeId,
                        principalTable: "MeasureOfTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NameUz = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameRu = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageName = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NameUz = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameRu = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DescriptionUz = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionRu = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NameUz = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameRu = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streets_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StreetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Home = table.Column<string>(type: "text", nullable: false),
                    AddressLine = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Streets_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NameUz = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    NameRu = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DescriptionUz = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionRu = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    InComeAmount = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ExpirationAt = table.Column<DateOnly>(type: "date", nullable: false),
                    QrCodeFileName = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incomes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outcomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outcomes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outcomes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetId_Home",
                table: "Addresses",
                columns: new[] { "StreetId", "Home" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NameEn",
                table: "Countries",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NameRu",
                table: "Countries",
                column: "NameRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_NameUz",
                table: "Countries",
                column: "NameUz",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_NameEn",
                table: "Districts",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_NameEn_RegionId",
                table: "Districts",
                columns: new[] { "NameEn", "RegionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_NameRu",
                table: "Districts",
                column: "NameRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_NameRu_RegionId",
                table: "Districts",
                columns: new[] { "NameRu", "RegionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_NameUz",
                table: "Districts",
                column: "NameUz",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_NameUz_RegionId",
                table: "Districts",
                columns: new[] { "NameUz", "RegionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_RegionId",
                table: "Districts",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_OrganizationId",
                table: "Incomes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ProductId",
                table: "Incomes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasureOfTypes_NameEn",
                table: "MeasureOfTypes",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasureOfTypes_NameRu",
                table: "MeasureOfTypes",
                column: "NameRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasureOfTypes_NameUz",
                table: "MeasureOfTypes",
                column: "NameUz",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_AddressId_NameEn",
                table: "Organizations",
                columns: new[] { "AddressId", "NameEn" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_AddressId_NameRu",
                table: "Organizations",
                columns: new[] { "AddressId", "NameRu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_AddressId_NameUz",
                table: "Organizations",
                columns: new[] { "AddressId", "NameUz" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_NameEn",
                table: "Organizations",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_NameRu",
                table: "Organizations",
                column: "NameRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_NameUz",
                table: "Organizations",
                column: "NameUz",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_OrganizationId",
                table: "Outcomes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_ProductId",
                table: "Outcomes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_OrganizationId",
                table: "Prices",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_ProductId_OrganizationId",
                table: "Prices",
                columns: new[] { "ProductId", "OrganizationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameEn",
                table: "Products",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameEn_ProductTypeId",
                table: "Products",
                columns: new[] { "NameEn", "ProductTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameRu",
                table: "Products",
                column: "NameRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameRu_ProductTypeId",
                table: "Products",
                columns: new[] { "NameRu", "ProductTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameUz",
                table: "Products",
                column: "NameUz",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameUz_ProductTypeId",
                table: "Products",
                columns: new[] { "NameUz", "ProductTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_MeasureOfTypeId",
                table: "ProductTypes",
                column: "MeasureOfTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_NameEn",
                table: "ProductTypes",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_NameEn_MeasureOfTypeId",
                table: "ProductTypes",
                columns: new[] { "NameEn", "MeasureOfTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_NameRu",
                table: "ProductTypes",
                column: "NameRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_NameRu_MeasureOfTypeId",
                table: "ProductTypes",
                columns: new[] { "NameRu", "MeasureOfTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_NameUz",
                table: "ProductTypes",
                column: "NameUz",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_NameUz_MeasureOfTypeId",
                table: "ProductTypes",
                columns: new[] { "NameUz", "MeasureOfTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryId",
                table: "Regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_NameEn",
                table: "Regions",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_NameEn_CountryId",
                table: "Regions",
                columns: new[] { "NameEn", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_NameRu",
                table: "Regions",
                column: "NameRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_NameRu_CountryId",
                table: "Regions",
                columns: new[] { "NameRu", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_NameUz",
                table: "Regions",
                column: "NameUz",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_NameUz_CountryId",
                table: "Regions",
                columns: new[] { "NameUz", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_NameEn",
                table: "Roles",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_NameRu",
                table: "Roles",
                column: "NameRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_NameUz",
                table: "Roles",
                column: "NameUz",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_DistrictId",
                table: "Streets",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_NameEn",
                table: "Streets",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_NameEn_DistrictId",
                table: "Streets",
                columns: new[] { "NameEn", "DistrictId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_NameRu",
                table: "Streets",
                column: "NameRu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_NameRu_DistrictId",
                table: "Streets",
                columns: new[] { "NameRu", "DistrictId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_NameUz",
                table: "Streets",
                column: "NameUz",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streets_NameUz_DistrictId",
                table: "Streets",
                columns: new[] { "NameUz", "DistrictId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Outcomes");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "MeasureOfTypes");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
