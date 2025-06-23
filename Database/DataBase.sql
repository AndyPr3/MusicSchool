-- 0 Database
CREATE DATABASE music_school;
GO
USE music_school;
GO
-- 1 Escuelas
CREATE TABLE dbo.Schools
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Code NVARCHAR(50) NOT NULL UNIQUE,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)    NULL
);
GO

-- 2 Profesores
CREATE TABLE dbo.Teachers
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdentificationNumber NVARCHAR(20) NOT NULL UNIQUE,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    SchoolId INT NOT NULL,
    CONSTRAINT FK_Teachers_Schools FOREIGN KEY (SchoolId) REFERENCES dbo.Schools(Id)        
);
GO

-- 3 Alumnos
CREATE TABLE dbo.Students
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdentificationNumber NVARCHAR(20) NOT NULL UNIQUE,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    BirthDate DATE NOT NULL
);
GO

-- 4 Incripciones
CREATE TABLE dbo.Inscriptions
(
	Id INT IDENTITY(1,1)  NOT NULL PRIMARY KEY,
	StudentId INT NOT NULL,
    TeacherId INT NOT NULL,    
    AssignedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),    
	CONSTRAINT FK_Ins_Student FOREIGN KEY (StudentId) REFERENCES dbo.Students(Id),
    CONSTRAINT FK_Ins_Teacher FOREIGN KEY (TeacherId) REFERENCES dbo.Teachers(Id),    
	CONSTRAINT UQ_Ins_Teacher_Student UNIQUE(TeacherId, StudentId)
);

GO

-- Crear Escuela
CREATE PROCEDURE dbo.sp_CreateSchool    
    @Code         NVARCHAR(50),
    @Name         NVARCHAR(100),
    @Description  NVARCHAR(255) = NULL
AS
BEGIN
    INSERT INTO dbo.Schools (Code, Name, Description)
    VALUES (@Code, @Name, @Description);
END
GO

-- Obtener Escuela por Id
CREATE PROCEDURE dbo.sp_GetSchoolById
    @Id INT
AS
BEGIN
    SELECT Id, Code, Name, Description
      FROM dbo.Schools
     WHERE Id = @Id;
END
GO

-- Obtener todas las Escuelas
CREATE PROCEDURE dbo.sp_GetAllSchools
AS
BEGIN
    SELECT Id, Code, Name, Description
      FROM dbo.Schools;
END
GO

-- Actualizar Escuela
CREATE PROCEDURE dbo.sp_UpdateSchool
    @Id           INT,
    @Code         NVARCHAR(50),
    @Name         NVARCHAR(100),
    @Description  NVARCHAR(255) = NULL
AS
BEGIN
    UPDATE dbo.Schools
       SET Code        = @Code,
           Name        = @Name,
           Description = @Description
     WHERE Id = @Id;
END
GO

-- Eliminar Escuela
CREATE PROCEDURE dbo.sp_DeleteSchool
    @Id INT
AS
BEGIN
    DELETE FROM dbo.Schools
     WHERE Id = @Id;
END
GO

-- Crear Alumno
CREATE PROCEDURE dbo.sp_CreateStudent    
    @IdentificationNumber NVARCHAR(20),
    @FirstName            NVARCHAR(50),
    @LastName             NVARCHAR(50),
    @BirthDate            DATE
AS
BEGIN
    INSERT INTO dbo.Students (IdentificationNumber, FirstName, LastName, BirthDate)
    VALUES (@IdentificationNumber, @FirstName, @LastName, @BirthDate);
END
GO

-- Obtener Alumno por Id
CREATE PROCEDURE dbo.sp_GetStudentById
    @Id INT
AS
BEGIN
    SELECT Id, IdentificationNumber, FirstName, LastName, BirthDate
      FROM dbo.Students
     WHERE Id = @Id;
END
GO

-- Obtener todos los Alumnos
CREATE PROCEDURE dbo.sp_GetAllStudents
AS
BEGIN
    SELECT Id, IdentificationNumber, FirstName, LastName, BirthDate
      FROM dbo.Students;
END
GO

-- Actualizar Alumno
CREATE PROCEDURE dbo.sp_UpdateStudent
    @Id                   INT,
    @IdentificationNumber NVARCHAR(20),
    @FirstName            NVARCHAR(50),
    @LastName             NVARCHAR(50),
    @BirthDate            DATE
AS
BEGIN
    UPDATE dbo.Students
       SET IdentificationNumber = @IdentificationNumber,
           FirstName            = @FirstName,
           LastName             = @LastName,
           BirthDate            = @BirthDate
     WHERE Id = @Id;
END
GO

-- Eliminar Alumno
CREATE PROCEDURE dbo.sp_DeleteStudent
    @Id INT
AS
BEGIN
    DELETE FROM dbo.Students
     WHERE Id = @Id;
END
GO

-- Crear Profesor
CREATE PROCEDURE dbo.sp_CreateTeacher    
    @IdentificationNumber NVARCHAR(20),
    @FirstName            NVARCHAR(50),
    @LastName             NVARCHAR(50),
    @SchoolId             INT
AS
BEGIN
    INSERT INTO dbo.Teachers (IdentificationNumber, FirstName, LastName, SchoolId)
    VALUES (@IdentificationNumber, @FirstName, @LastName, @SchoolId);
END
GO

-- Obtener Profesor por Id
CREATE PROCEDURE dbo.sp_GetTeacherById
    @Id INT
AS
BEGIN
    SELECT Id, IdentificationNumber, FirstName, LastName, SchoolId
      FROM dbo.Teachers
     WHERE Id = @Id;
END
GO

-- Obtener todos los Profesores
CREATE PROCEDURE dbo.sp_GetAllTeachers
AS
BEGIN
    SELECT Id, IdentificationNumber, FirstName, LastName, SchoolId
      FROM dbo.Teachers;
END
GO

-- Actualizar Profesor
CREATE PROCEDURE dbo.sp_UpdateTeacher
    @Id                   INT,
    @IdentificationNumber NVARCHAR(20),
    @FirstName            NVARCHAR(50),
    @LastName             NVARCHAR(50),
    @SchoolId             INT
AS
BEGIN
    UPDATE dbo.Teachers
       SET IdentificationNumber = @IdentificationNumber,
           FirstName            = @FirstName,
           LastName             = @LastName,
           SchoolId             = @SchoolId
     WHERE Id = @Id;
END
GO

-- Eliminar Profesor
CREATE PROCEDURE dbo.sp_DeleteTeacher
    @Id INT
AS
BEGIN
    DELETE FROM dbo.Teachers
     WHERE Id = @Id;
END
GO
-- Crear una inscripción
CREATE PROCEDURE dbo.sp_CreateInscription
    @StudentId INT,
    @TeacherId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
          FROM dbo.Inscriptions
         WHERE StudentId = @StudentId
           AND TeacherId = @TeacherId
    )
    BEGIN
        THROW 51000, 'El alumno ya está inscrito con este profesor.', 1;
    END

    INSERT INTO dbo.Inscriptions (StudentId, TeacherId)
    VALUES (@StudentId, @TeacherId);

    SELECT SCOPE_IDENTITY() AS InscriptionId;
END
GO

-- Obtener todos los registros de inscripción
CREATE PROCEDURE dbo.sp_GetAllInscriptions
AS
BEGIN
    SET NOCOUNT ON;

	SELECT 
        I.Id,        
        ST.Id         AS StudentId,
        ST.FirstName  AS FirstName,
        ST.LastName   AS LastName,
		ST.IdentificationNumber AS IdentificationNumber,
        T.Id          AS TeacherId,
        T.FirstName   AS FirstName,
        T.LastName    AS LastName,
		T.IdentificationNumber AS IdentificationNumber,
        I.AssignedAt
    FROM dbo.Inscriptions I
    INNER JOIN dbo.Students ST  ON ST.Id  = I.StudentId
    INNER JOIN dbo.Teachers T   ON T.Id   = I.TeacherId
    ORDER BY I.AssignedAt DESC;    
END
GO

-- Obtener una inscripción por su Id
CREATE PROCEDURE dbo.sp_GetInscriptionById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        I.Id,        
        ST.Id         AS StudentId,
		ST.IdentificationNumber AS IdentificationNumber,
        ST.FirstName  AS FirstName,
        ST.LastName   AS LastName,        
        T.Id          AS TeacherId,
		T.IdentificationNumber AS IdentificationNumber,
        T.FirstName   AS FirstName,
        T.LastName    AS LastName,
        I.AssignedAt
    FROM dbo.Inscriptions I
    INNER JOIN dbo.Students ST  ON ST.Id  = I.StudentId
    INNER JOIN dbo.Teachers T   ON T.Id   = I.TeacherId
    WHERE I.Id = @Id;
END
GO

-- Eliminar una inscripción por su Id
CREATE PROCEDURE dbo.sp_DeleteInscription
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Inscriptions
     WHERE Id = @Id;
END

GO
-- Estudiantes por Profesor
CREATE PROCEDURE dbo.sp_GetStudentsByTeacher
    @TeacherId INT
AS
BEGIN
    SELECT 
        S.Id AS StudentId,
        S.FirstName,
        S.LastName,
        SC.Id AS SchoolId,
        SC.Name AS SchoolName
    FROM dbo.Inscriptions I
    INNER JOIN dbo.Students S ON S.Id = I.StudentId
    INNER JOIN dbo.Teachers T ON T.Id = I.TeacherId
    INNER JOIN dbo.Schools SC ON SC.Id = T.SchoolId
    WHERE I.TeacherId = @TeacherId;
END
