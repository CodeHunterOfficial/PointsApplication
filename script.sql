Create database pointsdb;	
Use pointsdb;
CREATE TABLE points (
    id INTEGER AUTO_INCREMENT PRIMARY KEY, 
    xCoordinate integer, 
    yCoordinate integer,
    descriptions nvarchar(25),
    dt datetime
);

INSERT INTO points (xCoordinate, yCoordinate, descriptions, dt ) 
VALUES (0,5, "Right", STR_TO_DATE('1-01-2021', '%d-%m-%Y'));

INSERT INTO points (xCoordinate, yCoordinate, descriptions, dt ) 
VALUES (8,0, "Left", STR_TO_DATE('1-01-2021', '%d-%m-%Y'));

Select *from points