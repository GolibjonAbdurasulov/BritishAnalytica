using System;
using System.Collections.Generic;
using Entity.Models.Common;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseBroker.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "about_business",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    body = table.Column<string>(type: "text", nullable: true),
                    futures = table.Column<List<string>>(type: "text[]", nullable: true),
                    imageId = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_about_business", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    email_address = table.Column<string>(type: "text", nullable: true),
                    web = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "faq_questions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    body = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faq_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "file_model",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: true),
                    content_type = table.Column<string>(type: "text", nullable: true),
                    path = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "home_model",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    text = table.Column<string>(type: "text", nullable: true),
                    body = table.Column<string>(type: "text", nullable: true),
                    image_id = table.Column<List<Guid>>(type: "uuid[]", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_home_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    region = table.Column<string>(type: "text", nullable: true),
                    district = table.Column<string>(type: "text", nullable: true),
                    street = table.Column<string>(type: "text", nullable: true),
                    home = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sender_name = table.Column<string>(type: "text", nullable: true),
                    sender_email = table.Column<string>(type: "text", nullable: true),
                    subject = table.Column<string>(type: "text", nullable: true),
                    message_text = table.Column<string>(type: "text", nullable: true),
                    is_read = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "motto",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    author = table.Column<string>(type: "text", nullable: true),
                    text = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    category = table.Column<string>(type: "text", nullable: true),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    post_title = table.Column<string>(type: "text", nullable: true),
                    post_body = table.Column<string>(type: "text", nullable: true),
                    posted_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "our_services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    service_name = table.Column<string>(type: "text", nullable: true),
                    about_service = table.Column<string>(type: "text", nullable: true),
                    service_icon_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_our_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "phone_number",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    number = table.Column<string>(type: "text", nullable: true),
                    working_time_start = table.Column<string>(type: "text", nullable: true),
                    working_time_stop = table.Column<string>(type: "text", nullable: true),
                    working_day_start = table.Column<string>(type: "text", nullable: true),
                    working_day_stop = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone_number", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "planing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    body = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planing", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    body = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "service_percent",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    service_name = table.Column<string>(type: "text", nullable: true),
                    service_percent_name = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_percent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "success",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    body = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_success", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "team_members",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<string>(type: "text", nullable: true),
                    image_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_members", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "translations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: true),
                    uz = table.Column<string>(type: "text", nullable: true),
                    en = table.Column<string>(type: "text", nullable: true),
                    ru = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_translations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    PhoneNumberId = table.Column<long>(type: "bigint", nullable: true),
                    EmailId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.id);
                    table.ForeignKey(
                        name: "FK_contact_email_EmailId",
                        column: x => x.EmailId,
                        principalTable: "email",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_contact_location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "location",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_contact_phone_number_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "phone_number",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pps_model",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<MultiLanguageField>(type: "jsonb", nullable: true),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    PlaningId = table.Column<long>(type: "bigint", nullable: true),
                    SuccessId = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pps_model", x => x.id);
                    table.ForeignKey(
                        name: "FK_pps_model_planing_PlaningId",
                        column: x => x.PlaningId,
                        principalTable: "planing",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pps_model_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "project",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pps_model_success_SuccessId",
                        column: x => x.SuccessId,
                        principalTable: "success",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_contact_EmailId",
                table: "contact",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_contact_LocationId",
                table: "contact",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_contact_PhoneNumberId",
                table: "contact",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_pps_model_PlaningId",
                table: "pps_model",
                column: "PlaningId");

            migrationBuilder.CreateIndex(
                name: "IX_pps_model_ProjectId",
                table: "pps_model",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_pps_model_SuccessId",
                table: "pps_model",
                column: "SuccessId");

            migrationBuilder.CreateIndex(
                name: "IX_translations_code",
                table: "translations",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "about_business");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "faq_questions");

            migrationBuilder.DropTable(
                name: "file_model");

            migrationBuilder.DropTable(
                name: "home_model");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "motto");

            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "our_services");

            migrationBuilder.DropTable(
                name: "pps_model");

            migrationBuilder.DropTable(
                name: "service_percent");

            migrationBuilder.DropTable(
                name: "team_members");

            migrationBuilder.DropTable(
                name: "translations");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "phone_number");

            migrationBuilder.DropTable(
                name: "planing");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "success");
        }
    }
}
