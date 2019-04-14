using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Commom;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Entities.DTO;
using WebMotors.Proxy.Interface;

namespace WebMotors.Proxy
{
    public class AnuncioWebMotorsProxy : Proxy<AnuncioWebMotors>, IAnuncioWebMotorsProxy
    {
        public IEnumerable<MakeDTO> GetMakes()
        {
            var uri = $"{ApiConstants.Rotas.WebApi.Recursos.Make}";

            var response = HttpHelper.ExternalGetAsync<MakeDTO[]>(uri);

            return response;
        }

        public IEnumerable<ModelDTO> GetModels(int makeId)
        {
            var uri = $"{ApiConstants.Rotas.WebApi.Recursos.Model}?makeID={makeId}";

            var response = HttpHelper.ExternalGetAsync<ModelDTO[]>(uri);

            return response;
        }

        public IEnumerable<VersionDTO> GetVersions(int modelId)
        {
            var uri = $"{ApiConstants.Rotas.WebApi.Recursos.Version}?ModelID={modelId}";

            var response = HttpHelper.ExternalGetAsync<VersionDTO[]>(uri);

            return response;
        }
    }
}
