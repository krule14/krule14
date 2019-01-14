CREATE TABLE [dbo].[Buyer]
(
	BID			INT IDENTITY (1,1) NOT NULL,
	Name		NVARCHAR(30) NOT NULL,
	CONSTRAINT [PK_dbo.Buyer] PRIMARY KEY CLUSTERED (BID ASC)
);



CREATE TABLE [dbo].[Seller]
(
	SID			INT IDENTITY (1,1) NOT NULL,
	Name		NVARCHAR(20) NOT NULL,
	CONSTRAINT [PK_dbo.Seller] PRIMARY KEY CLUSTERED (SID ASC),
);



CREATE TABLE [dbo].[Item]
(
	IID			INT IDENTITY (1001,1) NOT NULL,
	Name		NVARCHAR(80)	   NOT NULL,
	Description NVARCHAR(300)	   NOT NULL,
	Seller		INT				   NOT NULL,
	CONSTRAINT [PK_dbo.Item] PRIMARY KEY CLUSTERED (IID ASC),
	CONSTRAINT [FK_dbo.Item] FOREIGN KEY (Seller) REFERENCES [dbo].[Seller] (SID),

);


CREATE TABLE [dbo].[Bid]
(
	BidID INT IDENTITY (1,1) NOT NULL,
	Item INT NOT NULL,
	Buyer INT NOT NULL,
	Price INT NOT NULL,
    Timestamp DateTime NOT NULL,
	CONSTRAINT [PK_dbo.Bid] PRIMARY KEY CLUSTERED (BidID ASC),
	CONSTRAINT [FK_dbo.Bid] FOREIGN KEY (Buyer) REFERENCES [dbo].[Buyer] (BID),
	CONSTRAINT [FK2_dbo.Bid] FOREIGN KEY (Item) REFERENCES [dbo].[Item] (IID)

);

INSERT INTO dbo.Buyer (Name) VALUES
('Jane Stone'),
('Tom McMasters'),
('Otto Vanderwall');

INSERT INTO dbo.Seller(Name) VALUES
('Gayle Hardy'),
('Lyle Banks'),
('Pearl Greene');

INSERT INTO dbo.Item(Name,Description,Seller) VALUES
('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln',3),
('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927',1),
('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan',2);

INSERT INTO dbo.Bid(Item,Buyer,Price,Timestamp) VALUES
(1001,3,250000,'12/04/2017 09:04:22'),
(1003,1,95000 ,'12/04/2017 08:44:03');
