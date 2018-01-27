using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace Hexa.Data.Test
{
    [TestClass]
    public class DeleteDatabaseTest
    {
        [TestMethod]
        public void DeleteDatabase()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<HexaDbContext>());
            using (var context = new HexaDbContext())
            {
                context.Database.Delete();
            }
        }
    }
}
