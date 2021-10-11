using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;
using Microsoft.EntityFrameworkCore;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdFeedbacksRepo
    {
        JpxCourierContext Context = new JpxCourierContext();

        public async Task<List<JcdFeedbacks>> GetFeedbackByRequest(long RequestId)
        {
            return await Context.JcdFeedbacks.Where(x => x.RequestId == RequestId).ToListAsync();
        }
    }
}
