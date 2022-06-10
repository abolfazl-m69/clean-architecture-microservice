using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HumanResource.Framework.Core
{
    public static class SqlSequence
    {
        public static async Task<long> GetNextSequenceAsync(this DbContext dbContext, string sequence)
        {
            var result = new SqlParameter("@result", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };

            await dbContext.Database.ExecuteSqlRawAsync($"SELECT @result = (NEXT VALUE FOR {sequence})", result);

            return (long)result.Value;
        }
    }
}