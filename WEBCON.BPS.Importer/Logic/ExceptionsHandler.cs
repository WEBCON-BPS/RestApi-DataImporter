using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WEBCON.BPS.Importer.Model;

namespace WEBCON.BPS.Importer.Logic
{
    public class ExceptionsHandler
    {
        public async Task WrapExceptions(Func<Task> action)
        {
            try
            {
                await action.Invoke();
            }
            catch(ApiException aex)
            {
                var message = $@"{aex.Message}. 
Error guid: {aex.Guid}";
                MessageBox.Show(message, "Api exception");
                SaveErrorLogs($"{message}{Environment.NewLine}{aex}");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                SaveErrorLogs($"{ex.Message}{Environment.NewLine}{ex}");
            }
        }

        public void SaveErrorLogs(string log)
        {
            try
            {
                if (!Directory.Exists("logs"))
                    Directory.CreateDirectory("logs");

                var path = $"logs\\ErrorLog_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt";
                File.WriteAllText(path, log);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while saving logs");
            }
        }
    }
}
