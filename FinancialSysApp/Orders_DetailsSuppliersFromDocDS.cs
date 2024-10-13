using System;
using DevExpress.Xpo;

namespace FinancialSysApp
{

    public class Orders_DetailsSuppliersFromDocDS : XPObject
    {
        public Orders_DetailsSuppliersFromDocDS() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Orders_DetailsSuppliersFromDocDS(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }
    }

}