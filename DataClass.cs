using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcFirma
{
    internal class DataClass
    {
        private string ConnectionStrings = @"Data Source=31.128.43.172;Initial Catalog=pcFirma;User ID=ivanessco;Password=Ibedug47!;";
        
        public string ConnectionString() { return ConnectionStrings; }
    }

}
