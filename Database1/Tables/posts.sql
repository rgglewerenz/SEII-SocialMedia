CREATE TABLE [dbo].[posts]
(
	post_id int not null Identity(1,1) Primary Key,
	caption VARCHAR(255),
	image_url VARCHAR(255),
	user_id int FOREIGN KEY References userAuth(user_id),
)
