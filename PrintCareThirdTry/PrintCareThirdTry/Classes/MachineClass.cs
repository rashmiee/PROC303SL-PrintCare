using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrintCareThirdTry.Database;
using System.Windows;
using System.Data;


namespace PrintCareThirdTry.Classes
{
    class MachineClass
    {
        //Class ID : CLZ01

        PrintCareDataContext db = DatabaseImplimentor.getDataContext();
        public int inserMachineDetails(Machine machine)
        {
            //Methode ID : MTH01

            //Methode Description : This methode will save machine details and return saved machine id

            try
            {
                db.Machines.InsertOnSubmit(machine);
                db.SubmitChanges();

                var machineIDs = (from x in db.Machines
                                  orderby x.MachineID descending
                                  select x.MachineID).Take(1);

                int machineID = 0;

                foreach (var x in machineIDs)
                {
                    machineID = Convert.ToInt32(x);
                }

                return machineID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occuered while processing. CLZ01MTH01 Error Code : "+ex.Message,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }

        public DataTable getMachineIDs()
        {
            //Methode ID : MTH02

            //Methode Description : This methode will return mechine ids from the database

            try
            {
                var machineIds = from x in db.Machines
                                 select x.MachineID;

                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(int));
                dt.Columns.Add("Value", typeof(int));

                foreach (var x in machineIds)
                {
                    dt.Rows.Add(x, x);
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occuered while processing. CLZ01MTH02 Error Code : " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
