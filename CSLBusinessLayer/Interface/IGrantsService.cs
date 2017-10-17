using CSLBusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLBusinessLayer.Interface
{
    public interface IGrantsService
    {
        DataTable GetAllGrants(string grantNum, string year, string library, string project, string category, int award);
    }
}
