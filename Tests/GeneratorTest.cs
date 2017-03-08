using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace Ticketizer
{
    public class GenerateTest : IDisposable
    {
        public GenerateTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ticketizer_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void TEST_CreateOneArticle()
        {
            Assert.Equal(20, KAGenerator.GenerateArticle().Count);
        }

        public void Dispose()
        {
            Article.DeleteAll();
        }
    }
}