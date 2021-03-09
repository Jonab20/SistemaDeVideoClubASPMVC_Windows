using AutoMapper;
using SistemaDeVideoClubASPMVC.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Windows.Mapeador
{
    class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });
            Mapper = config.CreateMapper();
        }
    }
}
