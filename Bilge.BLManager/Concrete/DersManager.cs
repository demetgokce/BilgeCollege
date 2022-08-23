using Bilge.BLManager.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.BLManager.Concrete
{
    public class DersManager : ManagerBase<Ders>, IDersManager
    {

       
            public bool CheckForBransName(string bransAdi)
            {
                var entities = base.db.GetAll(x => x.DersAd == bransAdi);
                if (entities.Count > 0)
                    return true;
                else
                    return false;
            }
       


    }
}
