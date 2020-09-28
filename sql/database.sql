USE [master]
GO
CREATE DATABASE [gtracker-db]
GO

USE [gtracker-db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE Friend (
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(50) NOT NULL,
	phone varchar(50) NOT NULL,
	email varchar(50) NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE Game(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(50) NOT NULL,
	dt_acquisition DATETIME NOT NULL,
	kind int NOT NULL,
	observation varchar(250) NULL
	)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE SystemUser(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(50) NOT NULL,
	active bit NOT NULL,
	login varchar(50) NOT NULL,
	password nvarchar(75) NOT NULL	 
)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
USE [master]
GO
ALTER DATABASE [Equinox] SET  READ_WRITE 
GO

CREATE TABLE Loan(
	id int PRIMARY KEY IDENTITY(1,1),
	friend_id int NOT NULL,
	dt_start DATETIME NOT NULL,
	observation varchar(250) NULL,
	FOREIGN KEY (friend_id) REFERENCES Friend (id)
);

CREATE TABLE LoanGame(	
	loan_id int NOT NULL,
	game_id int NOT NULL,
	loan_status int NOT NULL,
	dt_end DATETIME NULL,
	PRIMARY KEY (loan_id, game_id),
	FOREIGN KEY (loan_id) REFERENCES Loan (id),
	FOREIGN KEY (game_id) REFERENCES Game (id)		
);

USE [master]
GO
ALTER DATABASE [gtracker-db] SET  READ_WRITE 
GO
USE [gtracker-db]
GO
SET IDENTITY_INSERT [dbo].[SystemUser] ON 
GO
INSERT [dbo].[SystemUser] ([id], [name], [active], [login], [password]) VALUES (1, N'ADMIN', 1, N'admin', N'10000.i0wt/ndvvw0/T/Kop2S99A==.Uv33Y1sHv+QO05qdqvbKEg3A9pGkQqhvTiB3BRf69BA=')
GO
SET IDENTITY_INSERT [dbo].[SystemUser] OFF
GO
