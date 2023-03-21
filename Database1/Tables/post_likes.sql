CREATE TABLE [dbo].[post_likes]
(
	like_id int not null Identity(1,1) Primary Key,
	user_id int FOREIGN KEY References userAuth(user_id),
	post_id int FOREIGN KEY References posts(post_id),
)
