using CSLBusinessObjects.Models;
using CSLBusinessObjects.ViewModels;
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
        GrantsViewModel GetAllGrants(string grantNum, string year, string library, string project, int award);
    }
}
