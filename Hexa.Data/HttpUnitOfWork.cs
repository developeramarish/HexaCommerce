namespace Hexa.Data
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(HexaDbContext context) : base (context)
        {

        }
    }
}
