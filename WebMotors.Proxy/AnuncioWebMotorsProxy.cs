using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;
using WebMotors.Proxy.Interface;

namespace WebMotors.Proxy
{
    public class AnuncioWebMotorsProxy : Proxy<AnuncioWebMotors>, IAnuncioWebMotorsProxy
    {
    }
}
