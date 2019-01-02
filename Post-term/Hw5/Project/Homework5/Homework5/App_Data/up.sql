CREATE TABLE [dbo].[Requests] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (20)  NOT NULL,
    [LastName]    NVARCHAR (10)  NOT NULL,
    [PhoneNumber] NVARCHAR (MAX) NOT NULL,
    [ApptName]    NVARCHAR (10)  NOT NULL,
    [UnitNumber]  INT            NOT NULL,
    [Explanation] NVARCHAR (600) NOT NULL,
    [Permission]  BIT            NOT NULL,
    [TimeStamp]   DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)
);
INSERT INTO [dbo].[Requests] (ID, FirstName, LastName, PhoneNumber, ApptName, UnitNumber, Explanation ) VALUES
	('Kathleen', 'Smith', '(503) 867-5309', 'Cedar', 304, 'Shower door is stuck.'),  
	('Alya', 'Lebowitz', '(503) 555-5432', 'Arbor', 407, 'Oven knob is broken.'),
	('Rose', 'Quartz', '(503) 235-5446', 'Spruce', 765, 'Light is broken.'),
	('Amethyst', 'Quartz', '(503) 235-5296', 'Arbuthnot', 889, 'Floorboards broke.'),
	('Yellow', 'Diamond', '(503) 555-8179, Birchwood', 809, 'Shattered some gems, shards cut up the carpet.')
GO