using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Data;

namespace Core
{
    public class SoftwareRepository : IRepository<Software>
    {
        public Task<IQueryable<Software>> AllAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new[]
                {
                    new Software
                    {
                        Name = "MS Word",
                        Version = "13.2.1"
                    },
                    new Software
                    {
                        Name = "AngularJS",
                        Version = "1.7.1"
                    },
                    new Software
                    {
                        Name = "Angular",
                        Version = "8.1.13"
                    },
                    new Software
                    {
                        Name = "React",
                        Version = "0.0.5"
                    },
                    new Software
                    {
                        Name = "Vue.js",
                        Version = "2.6"
                    },
                    new Software
                    {
                        Name = "Visual Studio",
                        Version = "2017.0.1"
                    },
                    new Software
                    {
                        Name = "Visual Studio",
                        Version = "2019.1"
                    },
                    new Software
                    {
                        Name = "Visual Studio Code",
                        Version = "1.35"
                    },
                    new Software
                    {
                        Name = "Blazor",
                        Version = "0.7"
                    }
                }.AsQueryable()
            );
        }

        public async Task<IQueryable<Software>> FilterAsync(
            Expression<Func<Software, bool>> filterExpression,
            CancellationToken cancellationToken)
        {
            return (await AllAsync(cancellationToken)).Where(filterExpression);
        }
    }
}