using System;
using System.Collections.Generic;
using System.Text;

namespace X.Domain.Models
{
    /*
        CREATE TABLE [dbo].[User]
        (
            UserId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
            UserName NVARCHAR(250) NOT NULL,
            EmailAddress NVARCHAR(250) NOT NULL
        )
        INSERT INTO [dbo].[User] VALUES (NEWID(), 'Vala', 'vala@gmail.com')
    */
    public class User
    {
        public Guid UserId {get; set;}

        public string UserName {get; set;}

        public string EmailAddress {get; set;}
    }
}
