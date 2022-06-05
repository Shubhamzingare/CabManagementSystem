using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabManagementSystem.Domain.Abstract;
using CabManagementSystem.Domain.Entities;

namespace CabManagementSystem.Domain.Concrete
{
    public class EFBatchDetailRepository : IBatchDetailRepository
    {
        CabDbContext context = new CabDbContext();

        public IEnumerable<BatchDetail> BatchDetails => context.BatchDetails;

        public void SaveBatch(BatchDetail batchDetail)
        {
            if (batchDetail.batchId == 0)
            {
                context.BatchDetails.Add(batchDetail);
            }
            else
            {
                BatchDetail dbEntry = context.BatchDetails.Find(batchDetail.batchId);
                if (dbEntry != null)
                {
                    dbEntry.batchId = batchDetail.batchId;
                    dbEntry.totalEmp = batchDetail.batchId;
                    dbEntry.shiftId = batchDetail.shiftId;
                }
            }
            context.SaveChanges();
        }
    }
}
