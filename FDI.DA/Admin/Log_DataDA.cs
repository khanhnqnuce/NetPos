using System;
using FDI.Base;

namespace FDI.DA.Admin
{
    public partial class Log_DataDA : BaseDA
    {
        private readonly System_CountryDA _systemCountryDA;
        private readonly System_CityDA _systemCityDA;
        private readonly System_DistrictDA _systemDistrictDA;
        private readonly RankNowDA _rankNowDA;
      

        public Log_DataDA(string pathPaging)
        {
            PathPaging = pathPaging;
            _systemCountryDA = new System_CountryDA("#");
            _systemCityDA = new System_CityDA("#");
            _systemDistrictDA = new System_DistrictDA("#");
            _rankNowDA = new RankNowDA("#");
           
        }

        public void Add(Log_Data logData)
        {
            FDIDB.Log_Data.Add(logData);
        }

        public void Save()
        {

			FDIDB.SaveChanges();
        }
    }
}
