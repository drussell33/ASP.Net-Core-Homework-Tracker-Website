CREATE TABLE [Assignments]
(
    [ID]        INT PRIMARY KEY IDENTITY(1,1),
    [Priority]  INT          NOT NULL,
    [DueDate]   DATE         NOT NULL,
    [Course]    NVARCHAR(50) NOT NULL,
    [Title]     NVARCHAR(50) NOT NULL,
    [Notes]     NVARCHAR(250) NOT NULL
)
GO