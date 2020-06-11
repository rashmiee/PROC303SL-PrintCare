using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrintCareThirdTry.Database;

namespace PrintCareThirdTry.Classes
{
    class DatabaseImplimentor
    {
        private static PrintCareDataContext db;
        public static PrintCareDataContext getDataContext()
        {
            if (db == null)
            {
                db = new PrintCareDataContext();
            }
            return db;
        }
    }
}
