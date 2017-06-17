
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2017 15:35:45
-- Generated from EDMX file: D:\Project\BinaryGaming_2\BinaryGaming\BinaryGamingData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BinaryGaming];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MembershipTypesMembers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Members] DROP CONSTRAINT [FK_MembershipTypesMembers];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionTypesTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_TransactionTypesTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_MembersTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_MembersTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_CommitteePositionsCommittee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Committees] DROP CONSTRAINT [FK_CommitteePositionsCommittee];
GO
IF OBJECT_ID(N'[dbo].[FK_MembersCommittee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Committees] DROP CONSTRAINT [FK_MembersCommittee];
GO
IF OBJECT_ID(N'[dbo].[FK_MembersLoginLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoginLogs] DROP CONSTRAINT [FK_MembersLoginLog];
GO
IF OBJECT_ID(N'[dbo].[FK_MembersInvoices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT [FK_MembersInvoices];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoicesTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_InvoicesTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRole];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserMembers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Members] DROP CONSTRAINT [FK_AspNetUserMembers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Members];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO
IF OBJECT_ID(N'[dbo].[MembershipTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MembershipTypes];
GO
IF OBJECT_ID(N'[dbo].[TransactionTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionTypes];
GO
IF OBJECT_ID(N'[dbo].[CommitteePositions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommitteePositions];
GO
IF OBJECT_ID(N'[dbo].[Committees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Committees];
GO
IF OBJECT_ID(N'[dbo].[LoginLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoginLogs];
GO
IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoices];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(40)  NOT NULL,
    [FirstName] nvarchar(30)  NULL,
    [MiddleNames] nvarchar(30)  NULL,
    [Address1] nvarchar(40)  NOT NULL,
    [Address2] nvarchar(40)  NULL,
    [Suburb] nvarchar(40)  NOT NULL,
    [State] nvarchar(3)  NOT NULL,
    [Postcode] nvarchar(4)  NOT NULL,
    [Phone] nvarchar(25)  NULL,
    [Email] nvarchar(200)  NOT NULL,
    [Mobile] nvarchar(25)  NULL,
    [DateJoined] datetime  NOT NULL,
    [FinancialYN] bit  NOT NULL,
    [MembershipTypesId] int  NOT NULL,
    [MembershipExpiry] datetime  NOT NULL,
    [DiscordName] nvarchar(40)  NULL,
    [DiscordId] bigint  NULL,
    [LastLoggedIn] datetime  NOT NULL,
    [AspNetUserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [Amount] decimal(8,2)  NOT NULL,
    [TransactionTypesId] int  NOT NULL,
    [MembersId] int  NOT NULL,
    [InvoicesId] int  NOT NULL
);
GO

-- Creating table 'MembershipTypes'
CREATE TABLE [dbo].[MembershipTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MembershipType] nvarchar(30)  NULL,
    [AnnualFee] decimal(8,2)  NULL,
    [ProrataPayments] int  NULL
);
GO

-- Creating table 'TransactionTypes'
CREATE TABLE [dbo].[TransactionTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TransactionType] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'CommitteePositions'
CREATE TABLE [dbo].[CommitteePositions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PostionName] nvarchar(40)  NULL,
    [Ranking] int  NOT NULL
);
GO

-- Creating table 'Committees'
CREATE TABLE [dbo].[Committees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CommitteePositionsId] int  NOT NULL,
    [MembersId] int  NOT NULL
);
GO

-- Creating table 'LoginLogs'
CREATE TABLE [dbo].[LoginLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MembersId] int  NOT NULL,
    [LoginDate] datetime  NOT NULL,
    [SuccessfulYN] bit  NOT NULL,
    [ErrorException] nvarchar(max)  NOT NULL,
    [ClientIpAddress] nvarchar(60)  NOT NULL
);
GO

-- Creating table 'Invoices'
CREATE TABLE [dbo].[Invoices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MembersId] int  NULL,
    [Date] datetime  NOT NULL,
    [MembershipType] nvarchar(30)  NULL,
    [Amount] decimal(8,2)  NOT NULL,
    [Outstanding] decimal(8,2)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MembershipTypes'
ALTER TABLE [dbo].[MembershipTypes]
ADD CONSTRAINT [PK_MembershipTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionTypes'
ALTER TABLE [dbo].[TransactionTypes]
ADD CONSTRAINT [PK_TransactionTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CommitteePositions'
ALTER TABLE [dbo].[CommitteePositions]
ADD CONSTRAINT [PK_CommitteePositions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Committees'
ALTER TABLE [dbo].[Committees]
ADD CONSTRAINT [PK_Committees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LoginLogs'
ALTER TABLE [dbo].[LoginLogs]
ADD CONSTRAINT [PK_LoginLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [PK_Invoices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MembershipTypesId] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [FK_MembershipTypesMembers]
    FOREIGN KEY ([MembershipTypesId])
    REFERENCES [dbo].[MembershipTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembershipTypesMembers'
CREATE INDEX [IX_FK_MembershipTypesMembers]
ON [dbo].[Members]
    ([MembershipTypesId]);
GO

-- Creating foreign key on [TransactionTypesId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_TransactionTypesTransaction]
    FOREIGN KEY ([TransactionTypesId])
    REFERENCES [dbo].[TransactionTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionTypesTransaction'
CREATE INDEX [IX_FK_TransactionTypesTransaction]
ON [dbo].[Transactions]
    ([TransactionTypesId]);
GO

-- Creating foreign key on [MembersId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_MembersTransaction]
    FOREIGN KEY ([MembersId])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembersTransaction'
CREATE INDEX [IX_FK_MembersTransaction]
ON [dbo].[Transactions]
    ([MembersId]);
GO

-- Creating foreign key on [CommitteePositionsId] in table 'Committees'
ALTER TABLE [dbo].[Committees]
ADD CONSTRAINT [FK_CommitteePositionsCommittee]
    FOREIGN KEY ([CommitteePositionsId])
    REFERENCES [dbo].[CommitteePositions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CommitteePositionsCommittee'
CREATE INDEX [IX_FK_CommitteePositionsCommittee]
ON [dbo].[Committees]
    ([CommitteePositionsId]);
GO

-- Creating foreign key on [MembersId] in table 'Committees'
ALTER TABLE [dbo].[Committees]
ADD CONSTRAINT [FK_MembersCommittee]
    FOREIGN KEY ([MembersId])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembersCommittee'
CREATE INDEX [IX_FK_MembersCommittee]
ON [dbo].[Committees]
    ([MembersId]);
GO

-- Creating foreign key on [MembersId] in table 'LoginLogs'
ALTER TABLE [dbo].[LoginLogs]
ADD CONSTRAINT [FK_MembersLoginLog]
    FOREIGN KEY ([MembersId])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembersLoginLog'
CREATE INDEX [IX_FK_MembersLoginLog]
ON [dbo].[LoginLogs]
    ([MembersId]);
GO

-- Creating foreign key on [MembersId] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [FK_MembersInvoices]
    FOREIGN KEY ([MembersId])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembersInvoices'
CREATE INDEX [IX_FK_MembersInvoices]
ON [dbo].[Invoices]
    ([MembersId]);
GO

-- Creating foreign key on [InvoicesId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_InvoicesTransaction]
    FOREIGN KEY ([InvoicesId])
    REFERENCES [dbo].[Invoices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoicesTransaction'
CREATE INDEX [IX_FK_InvoicesTransaction]
ON [dbo].[Transactions]
    ([InvoicesId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUser'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUser]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [AspNetUserId] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [FK_AspNetUserMembers]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserMembers'
CREATE INDEX [IX_FK_AspNetUserMembers]
ON [dbo].[Members]
    ([AspNetUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------