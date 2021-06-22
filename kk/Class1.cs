using kk.CodeTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kk
{
    public class Class1
    {

        void kk() {
            var db = new AdventureWorksLT2017Entities();
            var rslt = db.Clientes.Where(item => item.NameStyle).Select(item => new { Id = item.CustomerID, Nombre = item.Nombre.Nombre }).ToList();
            //rslt.ForEach()
            var uno = db.Clientes.FirstOrDefault(item => item.CustomerID == 1);
            if(uno != null) {
                uno.Phone = "XXXX";
            } else {
                uno = new Cliente() { CustomerID = 1, Phone = "xxx" };
                db.Entry(uno);
            }
             db.SaveChanges();
        }
    }
}
