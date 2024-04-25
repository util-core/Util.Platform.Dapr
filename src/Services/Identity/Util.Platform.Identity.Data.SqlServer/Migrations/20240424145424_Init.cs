using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Util.Platform.Identity.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Permissions");

            migrationBuilder.CreateTable(
                name: "Application",
                schema: "Permissions",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "应用程序标识"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "扩展属性"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "应用程序编码"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "应用程序名称"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用"),
                    AllowedCorsOrigins = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "允许跨域来源"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "备注"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "创建人标识"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "最后修改时间"),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "最后修改人标识"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "是否删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId)
                        .Annotation("SqlServer:Clustered", false);
                },
                comment: "应用程序");

            migrationBuilder.CreateTable(
                name: "Claim",
                schema: "Permissions",
                columns: table => new
                {
                    ClaimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "声明标识"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "声明名称"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用"),
                    SortId = table.Column<int>(type: "int", nullable: true, comment: "排序号"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "备注"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "创建人标识"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "最后修改时间"),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "最后修改人标识"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "是否删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.ClaimId)
                        .Annotation("SqlServer:Clustered", false);
                },
                comment: "声明");

            migrationBuilder.CreateTable(
                name: "CommonOperation",
                schema: "Permissions",
                columns: table => new
                {
                    OperationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "操作标识"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "操作名称"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用"),
                    SortId = table.Column<int>(type: "int", nullable: true, comment: "排序号"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "备注"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "创建人标识"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "最后修改时间"),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "最后修改人标识"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "是否删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonOperation", x => x.OperationId)
                        .Annotation("SqlServer:Clustered", false);
                },
                comment: "常用操作资源");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Permissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "角色标识"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "扩展属性"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "父标识"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "路径"),
                    Level = table.Column<int>(type: "int", nullable: false, comment: "层级"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用"),
                    SortId = table.Column<int>(type: "int", nullable: true, comment: "排序号"),
                    Code = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "角色编码"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "角色名称"),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "标准化角色名称"),
                    Type = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "角色类型"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false, comment: "管理员"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "备注"),
                    PinYin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "拼音简码"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "创建人标识"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "最后修改时间"),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "最后修改人标识"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "是否删除"),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "租户标识")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId)
                        .Annotation("SqlServer:Clustered", false);
                },
                comment: "角色");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Permissions",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "用户标识"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "扩展属性"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "用户名"),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "标准化用户名"),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "安全邮箱"),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "标准化邮箱"),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false, comment: "邮箱是否已确认"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "安全手机号"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false, comment: "手机号是否已确认"),
                    PasswordHash = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true, comment: "密码散列"),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用双因素认证"),
                    Enabled = table.Column<bool>(type: "bit", nullable: true, comment: "是否启用"),
                    DisabledTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "冻结时间"),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false, comment: "是否启用锁定"),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "锁定截止"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: true, comment: "登录失败次数"),
                    LoginCount = table.Column<int>(type: "int", nullable: true, comment: "登录次数"),
                    RegisterIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "注册Ip"),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "上次登陆时间"),
                    LastLoginIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "上次登陆Ip"),
                    CurrentLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "本次登陆时间"),
                    CurrentLoginIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "本次登陆Ip"),
                    SecurityStamp = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true, comment: "安全戳"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "备注"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "创建人标识"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "最后修改时间"),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "最后修改人标识"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "是否删除"),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "租户标识")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId)
                        .Annotation("SqlServer:Clustered", false);
                },
                comment: "用户");

            migrationBuilder.CreateTable(
                name: "Resource",
                schema: "Permissions",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "资源标识"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "扩展属性"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "父标识"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "路径"),
                    Level = table.Column<int>(type: "int", nullable: false, comment: "层级"),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, comment: "启用"),
                    SortId = table.Column<int>(type: "int", nullable: true, comment: "排序号"),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "应用程序标识"),
                    Uri = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "资源标识符"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "资源名称"),
                    Type = table.Column<int>(type: "int", nullable: false, comment: "资源类型"),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "备注"),
                    PinYin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "拼音简码"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "创建人标识"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "最后修改时间"),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "最后修改人标识"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "是否删除")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Resource_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "Permissions",
                        principalTable: "Application",
                        principalColumn: "ApplicationId");
                    table.ForeignKey(
                        name: "FK_Resource_Resource_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Permissions",
                        principalTable: "Resource",
                        principalColumn: "ResourceId");
                },
                comment: "资源");

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Permissions",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "用户标识"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "角色标识")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Permissions",
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Permissions",
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户角色");

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "权限标识"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "角色标识"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "资源标识"),
                    IsDeny = table.Column<bool>(type: "bit", nullable: false, comment: "拒绝"),
                    IsTemporary = table.Column<bool>(type: "bit", nullable: false, comment: "临时"),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "到期时间"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "创建人标识"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "最后修改时间"),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "最后修改人标识"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "是否删除"),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "租户标识")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Permission_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "Permissions",
                        principalTable: "Resource",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "权限");

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "Application",
                columns: new[] { "ApplicationId", "AllowedCorsOrigins", "Code", "CreationTime", "CreatorId", "Enabled", "ExtraProperties", "IsDeleted", "LastModificationTime", "LastModifierId", "Name", "Remark" },
                values: new object[] { new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), "", "admin", new DateTime(2024, 4, 24, 14, 54, 23, 682, DateTimeKind.Utc).AddTicks(2646), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"IsClient\":true,\"AccessTokenLifetime\":3600,\"AllowedGrantType\":2,\"AllowOfflineAccess\":true,\"RedirectUri\":\"https://localhost:16001/,https://localhost:16003/,http://localhost:16100/,http://localhost:30101/swagger/oauth2-redirect.html,http://localhost:30102/swagger/oauth2-redirect.html\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 682, DateTimeKind.Utc).AddTicks(2649), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "管理系统", "这是第一个默认的管理后台系统" });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "Claim",
                columns: new[] { "ClaimId", "CreationTime", "CreatorId", "Enabled", "IsDeleted", "LastModificationTime", "LastModifierId", "Name", "Remark", "SortId" },
                values: new object[,]
                {
                    { new Guid("19af94f7-80a2-5d42-d432-278a23b10492"), new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5950), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5950), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "application_id", "应用程序标识", 7 },
                    { new Guid("1a331188-3318-a029-c8c8-71258c7041b2"), new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5927), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5927), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "name", "用户名", 3 },
                    { new Guid("27d23b13-0cb5-20aa-c65a-81bd90c35212"), new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5931), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5931), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "nickname", "昵称", 4 },
                    { new Guid("5b422322-b7f5-4081-e10a-fa96a85c5b86"), new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5913), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5914), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "sub", "用户标识", 1 },
                    { new Guid("70a9173d-2216-7bf6-2cbe-f0b2d38c524d"), new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5922), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5923), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "profile", "用户个人信息", 2 },
                    { new Guid("88a7eae0-3187-ac06-3766-8edf13d06776"), new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5939), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5940), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "phone_number", "手机号", 6 },
                    { new Guid("c38280ce-92f9-77be-1e17-87cd58c3fff1"), new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5935), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 683, DateTimeKind.Utc).AddTicks(5936), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "email", "电子邮件", 5 }
                });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "CommonOperation",
                columns: new[] { "OperationId", "CreationTime", "CreatorId", "Enabled", "IsDeleted", "LastModificationTime", "LastModifierId", "Name", "Remark", "SortId" },
                values: new object[,]
                {
                    { new Guid("1f2a241b-cd39-a8f6-3f0b-8ba1429ee7d8"), new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8952), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8953), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "保存", null, 6 },
                    { new Guid("50621bb8-47e5-c255-f144-7d8fe125f9c5"), new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8937), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8937), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "创建", null, 2 },
                    { new Guid("5938e49c-a434-6fd8-f826-ca53914eb639"), new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8944), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8945), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "删除", null, 4 },
                    { new Guid("67c2e873-bd4c-8bf4-278d-1a47071c18ba"), new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8963), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8963), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "审核", null, 9 },
                    { new Guid("71bf64bc-d530-d5d9-fe18-a425c622e81b"), new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8960), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8960), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "禁用", null, 8 },
                    { new Guid("7de225c2-97f0-599f-392f-8c3c4f20424a"), new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8929), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8931), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "查看", null, 1 },
                    { new Guid("9fcddc9b-9c9f-9ef6-b9cc-dac52bdfce6d"), new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8948), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8949), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "管理", null, 5 },
                    { new Guid("a4f60b2a-69ed-47f3-42a8-488d87d7b3b8"), new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8956), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8956), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "启用", null, 7 },
                    { new Guid("be5e151c-750d-6c84-3f63-fb6b6e4d9c60"), new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8941), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, false, new DateTime(2024, 4, 24, 14, 54, 23, 684, DateTimeKind.Utc).AddTicks(8941), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), "更新", null, 3 }
                });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "Resource",
                columns: new[] { "ResourceId", "ApplicationId", "CreationTime", "CreatorId", "Enabled", "ExtraProperties", "IsDeleted", "LastModificationTime", "LastModifierId", "Level", "Name", "ParentId", "Path", "PinYin", "Remark", "SortId", "Type", "Uri" },
                values: new object[,]
                {
                    { new Guid("3493f51d-ac81-4f39-80ea-0acb02c9fee2"), null, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3484), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[\"sub\"]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3484), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 1, "openid", null, "3493f51d-ac81-4f39-80ea-0acb02c9fee2,", null, "用户标识", 1, 5, "openid" },
                    { new Guid("cda87744-449d-4060-8f99-88c4223d103f"), null, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3494), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[\"profile\",\"name\"]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3494), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 1, "profile", null, "cda87744-449d-4060-8f99-88c4223d103f,", null, "用户信息", 1, 5, "profile" }
                });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "Role",
                columns: new[] { "RoleId", "Code", "CreationTime", "CreatorId", "Enabled", "ExtraProperties", "IsAdmin", "IsDeleted", "LastModificationTime", "LastModifierId", "Level", "Name", "NormalizedName", "ParentId", "Path", "PinYin", "Remark", "SortId", "TenantId", "Type" },
                values: new object[,]
                {
                    { new Guid("3465bc8f-dc86-46da-bb97-1721e257143c"), "test", new DateTime(2024, 4, 24, 14, 54, 23, 707, DateTimeKind.Utc).AddTicks(6898), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{}", false, false, new DateTime(2024, 4, 24, 14, 54, 23, 707, DateTimeKind.Utc).AddTicks(6898), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 1, "测试人员", "测试人员", null, "3465bc8f-dc86-46da-bb97-1721e257143c,", "csry", "测试人员", 1, null, "Role" },
                    { new Guid("d5c3cbde-f2be-47ac-bc85-a329f79588f8"), "admin", new DateTime(2024, 4, 24, 14, 54, 23, 707, DateTimeKind.Utc).AddTicks(6881), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{}", true, false, new DateTime(2024, 4, 24, 14, 54, 23, 707, DateTimeKind.Utc).AddTicks(6884), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 1, "管理员", "管理员", null, "d5c3cbde-f2be-47ac-bc85-a329f79588f8,", "gly", "管理员", 1, null, "Role" }
                });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "User",
                columns: new[] { "UserId", "AccessFailedCount", "CreationTime", "CreatorId", "CurrentLoginIp", "CurrentLoginTime", "DisabledTime", "Email", "EmailConfirmed", "Enabled", "ExtraProperties", "IsDeleted", "LastLoginIp", "LastLoginTime", "LastModificationTime", "LastModifierId", "LockoutEnabled", "LockoutEnd", "LoginCount", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterIp", "Remark", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), null, new DateTime(2024, 4, 24, 14, 54, 23, 709, DateTimeKind.Utc).AddTicks(8405), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), null, null, null, null, false, true, "{}", false, null, null, new DateTime(2024, 4, 24, 14, 54, 23, 709, DateTimeKind.Utc).AddTicks(8407), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, null, null, null, "ADMIN", "AQAAAAEAACcQAAAAEP+Co27jHqc5JQ0LPfqcMbUtsrCHkZhK/oRC/xPysrV9FTT+siiMEOELuOL+LeN7Jw==", null, false, null, "管理员", "E3LEMZVTQRBJD2GDJXDNNJ7BF3GEEUBF", null, false, "admin" },
                    { new Guid("c7cc9ba2-74e2-43f2-8250-7b01e849b03a"), null, new DateTime(2024, 4, 24, 14, 54, 23, 709, DateTimeKind.Utc).AddTicks(8415), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), null, null, null, null, false, true, "{}", false, null, null, new DateTime(2024, 4, 24, 14, 54, 23, 709, DateTimeKind.Utc).AddTicks(8417), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, null, null, null, "TEST", "AQAAAAIAAYagAAAAEL/2eO55+SdIu+k/R3xYVem14slhnggeUGSakH3eaPKwlUBZ/E1r5f5xZVLTTdO9Bw==", null, false, null, "测试人员", "A7NSFR322R5LQXDUKQCLOWED7VW6QUA2", null, false, "test" }
                });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "Resource",
                columns: new[] { "ResourceId", "ApplicationId", "CreationTime", "CreatorId", "Enabled", "ExtraProperties", "IsDeleted", "LastModificationTime", "LastModifierId", "Level", "Name", "ParentId", "Path", "PinYin", "Remark", "SortId", "Type", "Uri" },
                values: new object[] { new Guid("3a36abfa-ec83-4f40-a2ad-a0a49c811d6a"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3317), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"Group\":false,\"HideInBreadcrumb\":true,\"I18n\":\"menu.main\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3319), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 1, "主导航", null, "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,", "zdh", null, 1, 1, null });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d5c3cbde-f2be-47ac-bc85-a329f79588f8"), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896") },
                    { new Guid("3465bc8f-dc86-46da-bb97-1721e257143c"), new Guid("c7cc9ba2-74e2-43f2-8250-7b01e849b03a") }
                });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "Resource",
                columns: new[] { "ResourceId", "ApplicationId", "CreationTime", "CreatorId", "Enabled", "ExtraProperties", "IsDeleted", "LastModificationTime", "LastModifierId", "Level", "Name", "ParentId", "Path", "PinYin", "Remark", "SortId", "Type", "Uri" },
                values: new object[,]
                {
                    { new Guid("d861923e-ec0a-4347-a121-c8d1d7e6b489"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3331), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"I18n\":\"menu.dashboard\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3332), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 2, "仪表盘", new Guid("3a36abfa-ec83-4f40-a2ad-a0a49c811d6a"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,d861923e-ec0a-4347-a121-c8d1d7e6b489,", "ybp", null, 1, 1, null },
                    { new Guid("ec9c35b4-3dfd-4cee-be70-9d83993b40e5"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3350), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"I18n\":\"menu.system\",\"Icon\":\"safety-certificate\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3350), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 2, "系统管理", new Guid("3a36abfa-ec83-4f40-a2ad-a0a49c811d6a"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,", "xtgl", null, 2, 1, null },
                    { new Guid("1a01a8c3-1e6f-47d8-be75-b66da7f7a746"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3457), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"I18n\":\"identity.role\",\"Icon\":\"team\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3458), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 3, "角色", new Guid("ec9c35b4-3dfd-4cee-be70-9d83993b40e5"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,1a01a8c3-1e6f-47d8-be75-b66da7f7a746,", "js", null, 5, 1, "/identity/role" },
                    { new Guid("316ca95f-c920-47cb-b93b-12e13e26f9f8"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3340), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"I18n\":\"menu.dashboard.monitor\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3340), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 3, "监控页", new Guid("d861923e-ec0a-4347-a121-c8d1d7e6b489"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,d861923e-ec0a-4347-a121-c8d1d7e6b489,316ca95f-c920-47cb-b93b-12e13e26f9f8,", "ybp", null, 1, 1, "/dashboard/monitor" },
                    { new Guid("9412c649-2353-4f37-a178-21a66a7ad3bf"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3362), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"I18n\":\"identity.application\",\"Icon\":\"laptop\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3363), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 3, "应用程序", new Guid("ec9c35b4-3dfd-4cee-be70-9d83993b40e5"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,9412c649-2353-4f37-a178-21a66a7ad3bf,", "yycx", null, 1, 1, "/identity/application" },
                    { new Guid("a4c32fa8-f8eb-4ce9-a517-d96d431fcb04"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3447), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"I18n\":\"identity.user\",\"Icon\":\"user\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3448), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 3, "用户", new Guid("ec9c35b4-3dfd-4cee-be70-9d83993b40e5"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,a4c32fa8-f8eb-4ce9-a517-d96d431fcb04,", "yh", null, 4, 1, "/identity/user" },
                    { new Guid("a7c0376a-b558-482d-998e-15ee1f1ac45f"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3466), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsHide\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3466), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 3, "权限", new Guid("ec9c35b4-3dfd-4cee-be70-9d83993b40e5"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,a7c0376a-b558-482d-998e-15ee1f1ac45f,", "qx", null, 5, 1, null },
                    { new Guid("ccb74938-7e59-4532-a1ec-850ca75dd7b9"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3372), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"I18n\":\"identity.claim\",\"Icon\":\"idcard\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3372), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 3, "声明", new Guid("ec9c35b4-3dfd-4cee-be70-9d83993b40e5"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,ccb74938-7e59-4532-a1ec-850ca75dd7b9,", "sm", null, 2, 1, "/identity/claim" },
                    { new Guid("f85e2381-f85f-4978-aeaa-dd0a3106d1ab"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3380), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"I18n\":\"identity.resource\",\"Icon\":\"apartment\"}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3381), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 3, "资源", new Guid("ec9c35b4-3dfd-4cee-be70-9d83993b40e5"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,f85e2381-f85f-4978-aeaa-dd0a3106d1ab,", "zy", null, 3, 1, "/identity/resource" },
                    { new Guid("0088b0bd-6210-4e65-ae75-a642a5417809"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3549), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3550), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "删除", new Guid("ccb74938-7e59-4532-a1ec-850ca75dd7b9"), null, null, "删除声明", 4, 2, "claim.delete" },
                    { new Guid("1fc74685-c1d4-4ba9-8b81-04cf4b5ae8d0"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3407), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsHide\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3408), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 4, "操作资源", new Guid("f85e2381-f85f-4978-aeaa-dd0a3106d1ab"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,f85e2381-f85f-4978-aeaa-dd0a3106d1ab,1fc74685-c1d4-4ba9-8b81-04cf4b5ae8d0,", "czzy", null, 2, 1, null },
                    { new Guid("24afa389-0230-40b0-9795-cf38db05ad18"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3537), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3537), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "创建", new Guid("ccb74938-7e59-4532-a1ec-850ca75dd7b9"), null, null, "创建声明", 2, 2, "claim.create" },
                    { new Guid("2f60a136-5e31-43d9-81e7-104993080280"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3724), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3725), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "查看", new Guid("a4c32fa8-f8eb-4ce9-a517-d96d431fcb04"), null, null, "查看用户", 1, 2, "user.view" },
                    { new Guid("414d9bb9-aca4-4496-9ffc-15f917e2d3d5"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3779), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3779), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "授予操作权限", new Guid("a7c0376a-b558-482d-998e-15ee1f1ac45f"), null, null, "授予操作权限", 2, 2, "permission.grantOperation" },
                    { new Guid("4ebf8aeb-130a-40de-a098-16d138e6638d"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3801), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3801), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "拒绝Api权限", new Guid("a7c0376a-b558-482d-998e-15ee1f1ac45f"), null, null, "拒绝Api权限", 5, 2, "permission.denyApi" },
                    { new Guid("545db6bb-d65a-4ca1-9bed-1174f40f4271"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3749), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3749), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "创建", new Guid("1a01a8c3-1e6f-47d8-be75-b66da7f7a746"), null, null, "创建角色", 2, 2, "role.create" },
                    { new Guid("575a2e6e-6b3d-40ef-abd0-a820be29cc8f"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3516), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3517), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "更新", new Guid("9412c649-2353-4f37-a178-21a66a7ad3bf"), null, null, "更新应用程序", 3, 2, "application.update" },
                    { new Guid("5b47784d-ae87-44fe-a5b5-113003324bbf"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3743), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3743), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "查看", new Guid("1a01a8c3-1e6f-47d8-be75-b66da7f7a746"), null, null, "查看角色", 1, 2, "role.view" },
                    { new Guid("637534d1-0b4f-4dde-8b8f-16766bddc7f7"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3796), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3796), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "授予Api权限", new Guid("a7c0376a-b558-482d-998e-15ee1f1ac45f"), null, null, "授予Api权限", 4, 2, "permission.grantApi" },
                    { new Guid("73443ecd-fb73-4987-9a9d-cd69fc0881c0"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3501), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3501), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "查看", new Guid("9412c649-2353-4f37-a178-21a66a7ad3bf"), null, null, "查看应用程序", 1, 2, "application.view" },
                    { new Guid("8917e9e0-9e85-460e-88ba-704a697f6e3e"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3531), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3532), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "查看", new Guid("ccb74938-7e59-4532-a1ec-850ca75dd7b9"), null, null, "查看声明", 1, 2, "claim.view" },
                    { new Guid("8f979359-a998-4c8e-83b7-b22815dab9a8"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3524), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3524), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "删除", new Guid("9412c649-2353-4f37-a178-21a66a7ad3bf"), null, null, "删除应用程序", 4, 2, "application.delete" },
                    { new Guid("914dc6fd-0c75-4ac0-821f-b7846ba15a0d"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3543), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3544), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "保存", new Guid("ccb74938-7e59-4532-a1ec-850ca75dd7b9"), null, null, "保存声明", 3, 2, "claim.save" },
                    { new Guid("9c73ca2b-0412-4f8d-935f-047d6e264334"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3417), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsHide\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3417), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 4, "Api资源", new Guid("f85e2381-f85f-4978-aeaa-dd0a3106d1ab"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,f85e2381-f85f-4978-aeaa-dd0a3106d1ab,9c73ca2b-0412-4f8d-935f-047d6e264334,", "apizy", null, 3, 1, null },
                    { new Guid("a6769fb3-1e3b-4fc4-b04c-f0338495dbed"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3397), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsHide\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3398), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 4, "模块资源", new Guid("f85e2381-f85f-4978-aeaa-dd0a3106d1ab"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,f85e2381-f85f-4978-aeaa-dd0a3106d1ab,a6769fb3-1e3b-4fc4-b04c-f0338495dbed,", "mkzy", null, 1, 1, null },
                    { new Guid("a7c889b7-4f7e-416c-a4e7-6694e61c4abd"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3510), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3510), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "创建", new Guid("9412c649-2353-4f37-a178-21a66a7ad3bf"), null, null, "创建应用程序", 2, 2, "application.create" },
                    { new Guid("b3434421-1ac6-4f4b-8bed-04acccd8c91c"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3426), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsHide\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3426), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 4, "身份资源", new Guid("f85e2381-f85f-4978-aeaa-dd0a3106d1ab"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,f85e2381-f85f-4978-aeaa-dd0a3106d1ab,b3434421-1ac6-4f4b-8bed-04acccd8c91c,", "sfzy", null, 4, 1, null },
                    { new Guid("b84e8744-8a93-45a6-9dc4-16438631e1b1"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3790), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3790), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "拒绝操作权限", new Guid("a7c0376a-b558-482d-998e-15ee1f1ac45f"), null, null, "拒绝操作权限", 3, 2, "permission.denyOperation" },
                    { new Guid("bffbfcdb-b805-4bca-add3-7a99e584d3a8"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3436), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsHide\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3436), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 4, "常用操作管理", new Guid("f85e2381-f85f-4978-aeaa-dd0a3106d1ab"), "3a36abfa-ec83-4f40-a2ad-a0a49c811d6a,ec9c35b4-3dfd-4cee-be70-9d83993b40e5,f85e2381-f85f-4978-aeaa-dd0a3106d1ab,bffbfcdb-b805-4bca-add3-7a99e584d3a8,", "cyczgl", null, 9, 1, null },
                    { new Guid("c003a8ea-fc54-446f-b6bd-106e50ad0470"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3736), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3737), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "删除", new Guid("a4c32fa8-f8eb-4ce9-a517-d96d431fcb04"), null, null, "删除用户", 3, 2, "user.delete" },
                    { new Guid("c25a16b1-cece-46b3-8414-12a8491afb06"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3766), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3767), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "用户设置", new Guid("1a01a8c3-1e6f-47d8-be75-b66da7f7a746"), null, null, "角色用户设置", 5, 2, "role.userSettings" },
                    { new Guid("dc125bea-29d8-448d-bbd1-119928d02bc5"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3755), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3755), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "更新", new Guid("1a01a8c3-1e6f-47d8-be75-b66da7f7a746"), null, null, "更新角色", 3, 2, "role.update" },
                    { new Guid("de8b4989-5568-47a1-bc3b-12b7c0b54784"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3773), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3774), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "权限设置", new Guid("a7c0376a-b558-482d-998e-15ee1f1ac45f"), null, null, "权限设置", 1, 2, "permission.view" },
                    { new Guid("f9431293-3758-4737-9030-11ea5f8eec35"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3761), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3761), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "删除", new Guid("1a01a8c3-1e6f-47d8-be75-b66da7f7a746"), null, null, "删除角色", 4, 2, "role.delete" },
                    { new Guid("ffd031b3-9091-4d6a-b913-10677ee96b39"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3730), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3731), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "创建", new Guid("a4c32fa8-f8eb-4ce9-a517-d96d431fcb04"), null, null, "创建用户", 2, 2, "user.create" }
                });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "Permission",
                columns: new[] { "PermissionId", "CreationTime", "CreatorId", "ExpirationTime", "IsDeleted", "IsDeny", "IsTemporary", "LastModificationTime", "LastModifierId", "ResourceId", "RoleId", "TenantId" },
                values: new object[] { new Guid("8ba0d59a-ccc1-469c-8b15-a5867d4832b1"), new DateTime(2024, 4, 24, 14, 54, 23, 692, DateTimeKind.Utc).AddTicks(9156), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), null, false, false, false, new DateTime(2024, 4, 24, 14, 54, 23, 692, DateTimeKind.Utc).AddTicks(9161), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), new Guid("73443ecd-fb73-4987-9a9d-cd69fc0881c0"), new Guid("3465bc8f-dc86-46da-bb97-1721e257143c"), null });

            migrationBuilder.InsertData(
                schema: "Permissions",
                table: "Resource",
                columns: new[] { "ResourceId", "ApplicationId", "CreationTime", "CreatorId", "Enabled", "ExtraProperties", "IsDeleted", "LastModificationTime", "LastModifierId", "Level", "Name", "ParentId", "Path", "PinYin", "Remark", "SortId", "Type", "Uri" },
                values: new object[,]
                {
                    { new Guid("09a52bd1-997c-483a-9026-01f306e2cc84"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3630), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3630), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "查看", new Guid("bffbfcdb-b805-4bca-add3-7a99e584d3a8"), null, null, "查看常用操作", 1, 2, "commonOperation.view" },
                    { new Guid("0b782400-52c0-413a-8bbb-caffe8e902b0"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3568), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3568), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "创建", new Guid("a6769fb3-1e3b-4fc4-b04c-f0338495dbed"), null, null, "创建模块资源", 1, 2, "module.create" },
                    { new Guid("1766b64d-1926-4d3b-9da8-2dc7453df41a"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3573), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3574), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "启用", new Guid("a6769fb3-1e3b-4fc4-b04c-f0338495dbed"), null, null, "启用模块资源", 1, 2, "module.enable" },
                    { new Guid("1bb3da10-8de0-48d0-b48c-0cc5d9110575"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3665), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3666), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "创建", new Guid("9c73ca2b-0412-4f8d-935f-047d6e264334"), null, null, "创建Api资源", 2, 2, "apiResource.create" },
                    { new Guid("2033d9f9-e836-4767-a710-ad7e589f4da9"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3592), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3593), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "删除", new Guid("a6769fb3-1e3b-4fc4-b04c-f0338495dbed"), null, null, "删除模块资源", 1, 2, "module.delete" },
                    { new Guid("22029026-de32-483c-be42-0d67c8313195"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3677), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3677), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "启用", new Guid("9c73ca2b-0412-4f8d-935f-047d6e264334"), null, null, "启用Api资源", 4, 2, "apiResource.enable" },
                    { new Guid("3511c3f2-d444-4f20-8c48-023e9d1aec3a"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3652), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3653), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "删除", new Guid("bffbfcdb-b805-4bca-add3-7a99e584d3a8"), null, null, "删除常用操作", 4, 2, "commonOperation.delete" },
                    { new Guid("376f621f-bab1-4ec2-a688-01fe1877e842"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3640), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3641), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "创建", new Guid("bffbfcdb-b805-4bca-add3-7a99e584d3a8"), null, null, "创建常用操作", 2, 2, "commonOperation.create" },
                    { new Guid("4a0b65e8-7145-48c4-a400-18934a90ebf7"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3605), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3605), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "查看", new Guid("1fc74685-c1d4-4ba9-8b81-04cf4b5ae8d0"), null, null, "查看操作资源", 1, 2, "operation.view" },
                    { new Guid("4a672a64-ede1-4356-b19b-020fe1d713c6"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3647), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3647), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "保存", new Guid("bffbfcdb-b805-4bca-add3-7a99e584d3a8"), null, null, "保存常用操作", 3, 2, "commonOperation.save" },
                    { new Guid("4bb75118-6395-4db4-a031-0ce63ba1fff7"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3671), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3671), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "更新", new Guid("9c73ca2b-0412-4f8d-935f-047d6e264334"), null, null, "更新Api资源", 3, 2, "apiResource.update" },
                    { new Guid("7f15a965-387d-43ab-951e-d23b07bd1675"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3617), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3618), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "更新", new Guid("1fc74685-c1d4-4ba9-8b81-04cf4b5ae8d0"), null, null, "更新操作资源", 3, 2, "operation.update" },
                    { new Guid("8a22a16a-10d6-4886-a8f9-0de2dff88a9a"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3688), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3688), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "删除", new Guid("9c73ca2b-0412-4f8d-935f-047d6e264334"), null, null, "删除Api资源", 6, 2, "apiResource.delete" },
                    { new Guid("93742f2a-a27b-44f9-8e43-0dfae065cefa"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3695), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3696), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "查看", new Guid("b3434421-1ac6-4f4b-8bed-04acccd8c91c"), null, null, "查看身份资源", 1, 2, "identityResource.view" },
                    { new Guid("95031849-2da1-464b-948e-8218415e641f"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3611), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3612), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "创建", new Guid("1fc74685-c1d4-4ba9-8b81-04cf4b5ae8d0"), null, null, "创建操作资源", 2, 2, "operation.create" },
                    { new Guid("972b89f8-2c28-45cd-ad4d-0d7e22bcaa13"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3682), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3683), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "禁用", new Guid("9c73ca2b-0412-4f8d-935f-047d6e264334"), null, null, "禁用Api资源", 5, 2, "apiResource.disable" },
                    { new Guid("9d68775e-1ebf-48e6-b668-0ef97f054068"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3718), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3718), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "删除", new Guid("b3434421-1ac6-4f4b-8bed-04acccd8c91c"), null, null, "删除身份资源", 4, 2, "identityResource.delete" },
                    { new Guid("9d9ba908-80c7-48ad-8ee9-f43772f7c738"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3623), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3623), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "删除", new Guid("1fc74685-c1d4-4ba9-8b81-04cf4b5ae8d0"), null, null, "删除操作资源", 4, 2, "operation.delete" },
                    { new Guid("a67d5d7e-8cef-440d-8e7d-e7d2f4e3c321"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3557), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3557), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "查看", new Guid("a6769fb3-1e3b-4fc4-b04c-f0338495dbed"), null, null, "查看模块资源", 1, 2, "module.view" },
                    { new Guid("c389755d-2f53-4f79-ad4e-01841ca12bad"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3659), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[],\"IsBase\":true}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3660), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "查看", new Guid("9c73ca2b-0412-4f8d-935f-047d6e264334"), null, null, "查看Api资源", 1, 2, "apiResource.view" },
                    { new Guid("c84bde6f-ce06-400c-91d9-38b4308914c8"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3580), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3581), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "禁用", new Guid("a6769fb3-1e3b-4fc4-b04c-f0338495dbed"), null, null, "禁用模块资源", 1, 2, "module.disable" },
                    { new Guid("ccb020f6-c756-4183-a180-0e8ed9ec5170"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3707), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3707), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "更新", new Guid("b3434421-1ac6-4f4b-8bed-04acccd8c91c"), null, null, "更新身份资源", 3, 2, "identityResource.update" },
                    { new Guid("d2a61ff2-b713-41a8-a5ee-f9349b49aa21"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3586), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3586), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "更新", new Guid("a6769fb3-1e3b-4fc4-b04c-f0338495dbed"), null, null, "更新模块资源", 1, 2, "module.update" },
                    { new Guid("da5ebca9-f2e1-4cf8-93a6-0e48dcb0c461"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3701), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3701), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "创建", new Guid("b3434421-1ac6-4f4b-8bed-04acccd8c91c"), null, null, "创建身份资源", 2, 2, "identityResource.create" },
                    { new Guid("f29522ba-ef0b-488f-b4f3-49a8dfe7042e"), new Guid("e9138a35-a4ff-460e-ac55-b743d55b9691"), new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3598), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), true, "{\"Claims\":[]}", false, new DateTime(2024, 4, 24, 14, 54, 23, 693, DateTimeKind.Utc).AddTicks(3598), new Guid("55ba53a6-e482-4d9b-8d91-3fba6610b896"), 0, "资源设置", new Guid("a6769fb3-1e3b-4fc4-b04c-f0338495dbed"), null, null, "模块资源设置", 1, 2, "module.settings" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_CreationTime",
                schema: "Permissions",
                table: "Application",
                column: "CreationTime")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Claim_CreationTime",
                schema: "Permissions",
                table: "Claim",
                column: "CreationTime")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_CommonOperation_CreationTime",
                schema: "Permissions",
                table: "CommonOperation",
                column: "CreationTime")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_CreationTime",
                schema: "Permissions",
                table: "Permission",
                column: "CreationTime")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_ResourceId",
                schema: "Permissions",
                table: "Permission",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ApplicationId",
                schema: "Permissions",
                table: "Resource",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_CreationTime",
                schema: "Permissions",
                table: "Resource",
                column: "CreationTime")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ParentId",
                schema: "Permissions",
                table: "Resource",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreationTime",
                schema: "Permissions",
                table: "Role",
                column: "CreationTime")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_User_CreationTime",
                schema: "Permissions",
                table: "User",
                column: "CreationTime")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "Permissions",
                table: "UserRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim",
                schema: "Permissions");

            migrationBuilder.DropTable(
                name: "CommonOperation",
                schema: "Permissions");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Permissions");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Permissions");

            migrationBuilder.DropTable(
                name: "Resource",
                schema: "Permissions");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Permissions");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Permissions");

            migrationBuilder.DropTable(
                name: "Application",
                schema: "Permissions");
        }
    }
}
