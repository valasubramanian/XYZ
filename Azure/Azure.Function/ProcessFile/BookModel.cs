using System;

namespace Azure.Functions
{
    // CREATE TABLE [dbo].[tblBooks](
    //     [Index] [BIGINT] NULL,
    //     [Title] [NVARCHAR](500) NULL
    // );
    public class BookModel
    {
        public int Index { get; set; }
        public string Title { get; set; }
    }
}
