CREATE TABLE [dbo].[Route] (
    [id]    INT            IDENTITY (1, 1) NOT NULL,
    [from]  VARCHAR (3)    NULL,
    [to]    VARCHAR (3)    NULL,
    [price] DECIMAL (5, 2) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

