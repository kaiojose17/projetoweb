using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Commom
{
    public static class ApiConstants
    {
        public class Rotas
        {
            public class WebApi
            {
                public const string BaseUri = "api/web-motors";


                public const string Get = "";
                public const string Post = "";
                public const string Delete = "delete";
                public const string Put = "put";

                public class Recursos
                {
                    public const string GetbyId = BaseUri + "{id}";
                }
            }
        }
    }
}
