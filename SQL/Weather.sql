BEGIN TRANSACTION;
CREATE TABLE [Weather] (
[AreaId] INTEGER,
[DataDate] DATETIME,
[Condition] INTEGER NOT NULL,
[Temperature] REAL NOT NULL,
PRIMARY KEY([AreaId],[DataDate])
);

INSERT INTO [Weather] ([AreaId],[DataDate],[Condition],[Temperature]) VALUES ('1','2018-08-10','1','31.2345');
INSERT INTO [Weather] ([AreaId],[DataDate],[Condition],[Temperature]) VALUES ('1','2018-08-11','2','30.2345');
INSERT INTO [Weather] ([AreaId],[DataDate],[Condition],[Temperature]) VALUES ('2','2018-08-11','3','24.332');
INSERT INTO [Weather] ([AreaId],[DataDate],[Condition],[Temperature]) VALUES ('1','2018-08-12','3','24.3');
INSERT INTO [Weather] ([AreaId],[DataDate],[Condition],[Temperature]) VALUES ('2','2025-07-30','1','12.3000001907349');
INSERT INTO [Weather] ([AreaId],[DataDate],[Condition],[Temperature]) VALUES ('1','2025-07-30','3','1');
INSERT INTO [Weather] ([AreaId],[DataDate],[Condition],[Temperature]) VALUES ('1','2025-07-30','1','12');
INSERT INTO [Weather] ([AreaId],[DataDate],[Condition],[Temperature]) VALUES ('1','2025-07-30','1','12');
COMMIT;
