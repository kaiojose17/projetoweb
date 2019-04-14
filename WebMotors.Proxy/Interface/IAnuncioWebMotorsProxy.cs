using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Entities.DTO;

namespace WebMotors.Proxy.Interface
{
    public interface IAnuncioWebMotorsProxy : IProxy<AnuncioWebMotors>
    {
        IEnumerable<MakeDTO> GetMakes();
        IEnumerable<ModelDTO> GetModels(int makeId);
        IEnumerable<VersionDTO> GetVersions(int modelId);
    }
}
