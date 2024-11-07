﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArzuhalCI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AllDependencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entries",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    analyse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    prompt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entries", x => x.id);
                    table.ForeignKey(
                        name: "fk_entries_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analyses",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    entry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    mood = table.Column<string>(type: "text", nullable: false),
                    negative = table.Column<bool>(type: "boolean", nullable: false),
                    sentiment_score = table.Column<int>(type: "integer", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analyses", x => x.id);
                    table.ForeignKey(
                        name: "fk_analyses_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analyses_entries_entry_id",
                        column: x => x.entry_id,
                        principalSchema: "public",
                        principalTable: "entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "petitions",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    entry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_petitions", x => x.id);
                    table.ForeignKey(
                        name: "fk_petitions_entries_entry_id",
                        column: x => x.entry_id,
                        principalSchema: "public",
                        principalTable: "entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_analyses_customer_id",
                schema: "public",
                table: "analyses",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_analyses_entry_id",
                schema: "public",
                table: "analyses",
                column: "entry_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_entries_customer_id",
                schema: "public",
                table: "entries",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_petitions_entry_id",
                schema: "public",
                table: "petitions",
                column: "entry_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analyses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "petitions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "entries",
                schema: "public");
        }
    }
}
