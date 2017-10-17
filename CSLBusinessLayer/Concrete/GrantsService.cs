using CSLDataAccessLayer;
using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessLayer.Concrete
{
    class GrantsService
    {
        private IDataAccess _dataAccess;

        public GrantsService(IDataAccess DataAccess)
        {
            _dataAccess = DataAccess;
        }

        public GrantsModel GetAllGrants(string grantNum, string year, string library, string project, string category, int award)
        {
            return _dataAccess.GetAllGrants(grantNum, year, library, project, category, award);
        }
    }
}
