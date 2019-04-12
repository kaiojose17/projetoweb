using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Interface;

namespace WebMotors.Domain
{
    public interface IWebMotorsRepository : IRepositoryBase<AnuncioWebMotors>
    {
    }
}
