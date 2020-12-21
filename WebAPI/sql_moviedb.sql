CREATE DATABASE MovieDB
GO
USE MovieDB
GO

CREATE TABLE MsMovie(
	MovieID INT PRIMARY KEY IDENTITY(1,1),
	MovieName VARCHAR(50),
	MovieRating INT,

)

GO
CREATE PROC bn_GetMovies
AS
BEGIN
   SELECT MovieID, MovieName, MovieRating
   FROM MsMovie
END

go

create proc bn_GetMovieByID
@MovieID INT
AS
BEGIN
	SELECT MovieID, MovieName, MovieRating
   FROM MsMovie
   where MovieID = @MovieID
END
go

create proc bn_InsertMovie
@MovieName VARCHAR(50),
@MovieRating INT
AS
BEGIN
 INSERT INTO MsMovie(MovieName, MovieRating) VALUES (@MovieName, @MovieRating)
END

go
create proc bn_DeleteMovie
@MovieID int
AS

begin
 delete from MsMovie where MovieID = @MovieID
end

go

create proc bn_UpdateMovie
@MovieID int,
@MovieName VARCHAR(50),
@MovieRating int

as

begin
  update MsMovie
  set MovieName = @MovieName,
  MovieRating = @MovieRating
  where
  MovieID = @MovieID
end

go
insert into MsMovie(MovieName, MovieRating) values('movie 1', 1)
insert into MsMovie(MovieName, MovieRating) values('movie 2', 2)
insert into MsMovie(MovieName, MovieRating) values('movie 3', 3)
insert into MsMovie(MovieName, MovieRating) values('movie 4', 4)
insert into MsMovie(MovieName, MovieRating) values('movie 5', 5)
