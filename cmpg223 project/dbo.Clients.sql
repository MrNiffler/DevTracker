CREATE TABLE [dbo].[Clients] (
    [clientID]          INT           NOT NULL,
    [clientCompanyName] VARCHAR (30)  NULL,
    [clientEmail]       VARCHAR (100) NULL,
    [clientPhoneNumber] VARCHAR (10)  NULL,
    [clientName ] VARCHAR(30) NULL, 
    [cleintLastName] VARCHAR(30) NULL, 
    PRIMARY KEY CLUSTERED ([clientID] ASC)
);

