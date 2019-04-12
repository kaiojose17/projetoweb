using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Interface.Services;

namespace WebMotors.Domain.Services
{
    public class WebMotorsService : ServiceBase<AnuncioWebMotors>, IWebMotorsService
    {
        private IWebMotorsRepository _webMotorsRepository;

        public WebMotorsService(IWebMotorsRepository webMotorsRepository)
            : base(webMotorsRepository)
        {
            _webMotorsRepository = webMotorsRepository;
        }
    }
}
