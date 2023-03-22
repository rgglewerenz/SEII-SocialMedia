CREATE TABLE [dbo].[userAuth]
(
	user_id int not null Identity(1,1) Primary Key,
	email VARCHAR(255) not null unique,
	password VARCHAR(255) not null
)
