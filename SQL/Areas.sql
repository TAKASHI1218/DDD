BEGIN TRANSACTION;
CREATE TABLE [Areas] (
[AreaId] INTEGER,
[AreaName] TEXT NOT NULL,
PRIMARY KEY([AreaId])
);

INSERT INTO [Areas] ([AreaId],[AreaName]) VALUES ('1','東京');
INSERT INTO [Areas] ([AreaId],[AreaName]) VALUES ('2','静岡');
INSERT INTO [Areas] ([AreaId],[AreaName]) VALUES ('3','神戸');
COMMIT;
