using CSLDataAccessLayer;
using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CSLBusinessObjects.ViewModels;

namespace CSLBusinessLayer.Concrete
{
    class GrantsService
    {
        private IDataAccess _dataAccess;

        public GrantsService(IDataAccess DataAccess)
        {
            _dataAccess = DataAccess;
        }

        public GrantsViewModel GetAllGrants(string grantNum, string year, string library, string project, int award)
        {
            return _dataAccess.GetAllGrants(grantNum, year, library, project, award);
        }
    }
}
