using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interfce.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Supplier supplier = new Supplier();

        public bool Delete(int? Id)
        {
            var result = 0;
            var supplierid = Get(Id);
            supplierid.IsDelete = true;
            supplierid.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }



        public List<Supplier> Get()
        {
            return myContext.Suppliers.Where(x => x.IsDelete == false).ToList();
        }
        public Supplier Get(int? Id)
        {
            return myContext.Suppliers.Where(x => x.Id == Id && x.IsDelete == false).SingleOrDefault();
        }

        public bool Insert(SupplierParam supplierParam)
        {
            var result = 0;
            supplier.Name = supplierParam.Name;
            supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
            supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Suppliers.Add(supplier);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, SupplierParam supplierParam)
        {
            var result = 0;
            Supplier supplier = Get(Id);
            supplier.Name = supplierParam.Name;
            supplier.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        
    }
}
