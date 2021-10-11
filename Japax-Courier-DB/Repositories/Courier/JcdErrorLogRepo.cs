using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Courier;

namespace Japax_Courier_DB.Repositories.Courier
{
    public class JcdErrorLogRepo
    {
        JpxCourierContext _Context = new JpxCourierContext();

        public async Task<string> AddLog (JcdErrorLog _ErrorLog)
        {
            try
            {
                await _Context.JcdErrorLog.AddAsync(_ErrorLog);
                await _Context.SaveChangesAsync();
                return await Task.FromResult("Success");
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message.ToString());
            }
        }
    }
}
