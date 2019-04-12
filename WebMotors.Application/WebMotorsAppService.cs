using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Application.Interface;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Interface.Services;

namespace WebMotors.Application
{
    public class WebMotorsAppService : AppServiceBase<AnuncioWebMotors>, IWebMotorsServiceBase
    {
        private readonly IWebMotorsService _webMotorsService;

        public WebMotorsAppService(IWebMotorsService webMotorsService)
            : base(webMotorsService)
        {
            _webMotorsService = webMotorsService;
        }
    }
}
