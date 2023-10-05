using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping.Entities
{
    public class Passagens : DbContext
    {
        public string EMPRESA { get; set; }
        public string COMPANHIA_DE_VOO { get; set; }
        public string PRECO_TOTAL { get; set; }
        public string TAXA_DE_EMBARQUE { get; set; }
        public string TAXA_DE_SERVICO { get; set; }
        public int TEMPO_DE_VOO_IDA { get; set; }
        public int TEMPO_DE_VOO_VOLTA { get; set; }
        public DateTime DATA_HORA_DE_IDA { get; set; }
        public DateTime DATA_HORA_DE_VOLTA { get; set; }
        public int ID { get; set; }


        public DbSet<Passagens> VOOS { get; set; }
        public List<Passagens> ConsultarMelhorPassagem()
        {
            string consultaSql = "SELECT * FROM VOOS WHERE TAXA_DE_SERVICO < 100";
            return VOOS.FromSqlRaw(consultaSql).ToList();
        }

    }


    
}



