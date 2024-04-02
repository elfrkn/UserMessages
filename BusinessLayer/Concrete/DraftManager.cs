using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DraftManager : IDraftService
    {
        IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }


        public void TDelete(int id)
        {
            _draftDal.Delete(id);
        }

        public Draft TGetById(int id)
        {
            return _draftDal.GetByID(id);
        }

        public List<Draft> TGetListAll()
        {
            return _draftDal.GetList();
        }

        public void TInsert(Draft t)
        {
            _draftDal.Insert(t);
        }

        public void TUpdate(Draft t)
        {
            _draftDal.Update(t);
        }
    }
}
