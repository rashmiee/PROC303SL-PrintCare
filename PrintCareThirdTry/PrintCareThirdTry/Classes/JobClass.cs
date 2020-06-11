using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrintCareThirdTry.Database;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using System.Data;

namespace PrintCareThirdTry.Classes
{
    class JobClass
    {
        //Class ID : CLZ02

        PrintCareDataContext db = DatabaseImplimentor.getDataContext();
        public int insertJobDetails(Printing_Job Job)
        { 
            //Method ID : MTH01

            //Methode Description : This method will Save job details & return job Id.

            try
            {
                db.Printing_Jobs.InsertOnSubmit(Job);
                db.SubmitChanges();

                var jobIds = (from x in db.Printing_Jobs
                              orderby x.JobID descending
                              select x.JobID).Take(1);
                int jobId = 0;

                foreach (var x in jobIds)
                {
                    jobId = Convert.ToInt32(x);
                }

                return jobId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occuered while processing. CLZ02MTH01 Error Code : " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0; 
            }
        }

        public BitmapImage getSampleImage(int jobId)
        {
            //Method ID : MTH02

            //Methode Description : This method will return sample image for given jobId.

            try
            {
                var itemImage = (from x in db.Printing_Jobs
                                 where x.JobID == jobId
                                 select x.Sample).Single();

                BitmapImage bmp = new BitmapImage(new Uri(itemImage));
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occuered while processing. CLZ02MTH02 Error Code : " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null; 
            }
        }

        public DataTable getJobIDs()
        {

            //Methode ID : MTH03

            //Methode Description : This methode will return job ids from the database

            try
            {
                var jobIds = from x in db.Printing_Jobs
                             select x.JobID;
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(int));
                dt.Columns.Add("Value", typeof(int));

                foreach (var x in jobIds)
                {
                    dt.Rows.Add(x, x);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occuered while processing. CLZ02MTH03 Error Code : " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

        }

        public Printing_Job getPrintingJobDetails(int jobID)
        {
            //Methode ID : MTH04

            //Methode Description : This methode will return Printing job details for given jobID

            try
            {
                var printingJob = (from x in db.Printing_Jobs
                                   where x.JobID == jobID
                                   select x).Single();

                return printingJob;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occuered while processing. CLZ02MTH04 Error Code : " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public string getSampleImagePath(int jobID)
        {
            //Method ID : MTH05

            //Methode Description : This method will return sample image memory stream for given jobId.

            try
            {
                var itemImage = (from x in db.Printing_Jobs
                                 where x.JobID == jobID
                                 select x.Sample).Single();

                return itemImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occuered while processing. CLZ02MTH05 Error Code : " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

    }
}
