using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain;
using WebMotors.Domain.Entities;

namespace WebMotors.Infrastructure.Data.Repositories
{
    public class WebMotorsRepository : RepositoryBase<AnuncioWebMotors>, IWebMotorsRepository
    {
    }
}
