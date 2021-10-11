using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Japax_Courier_DB.DBModels.Auth;

namespace Japax_Courier_DB.Repositories.Auth
{
    public class JpxErrorLogRepo
    {
        JpxAuthContext _Context = new JpxAuthContext();

        public async Task<string> AddLog(JpxErrorLog _ErrorLog)
        {
            try
            {
                await _Context.JpxErrorLog.AddAsync(_ErrorLog);
                await _Context.SaveChangesAsync();
                return await Task.FromResult("Success");
            } catch(Exception ex)
            {
                return await Task.FromResult(ex.Message.ToString());
            }
        }
    }
}
