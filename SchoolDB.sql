CREATE DATABASE SchoolDB;
GO
USE SchoolDB;
GO
CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Age INT,
    Major NVARCHAR(50)
);
GO
INSERT INTO Students (FullName, Age, Major)
VALUES 
('Nguyen Van A', 20, 'Computer Science'),
('Le Thi B', 22, 'Business Administration'),
('Tran Van C', 19, 'Mechanical Engineering');
GO
SELECT * FROM Students;
GO
