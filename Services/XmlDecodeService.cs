using System.Xml.Linq;

namespace BlazorTcpClientApp.Services
{
    public class XmlDecodeService
    {
        private readonly string success = "Success";    // Варианты ответа службы
        private readonly string error = "Error";        // Варианты ответа службы

        // Получаю имя пк от службы на компе юзера, иначе текст ошибки, ставлю флаг, что ошибка была.
        public void SetUserPcName(string xmlRaw, UserModel userModel) 
        {
            try
            {
                XDocument xDoc = XDocument.Parse(xmlRaw);

                string state = xDoc.Root?
                                   .Element("State")?.Value
                                   ??"Unknown";

                if ((!string.IsNullOrEmpty(state)) && (state == success))
                {
                    userModel.PcName = xDoc.Root?
                                           .Element("StaticData")?
                                           .Element("MachineName")?
                                           .Value ?? "anonymous";
                }   // разделить на 2 метода - потом
                else if ((!string.IsNullOrEmpty(state)) && (state == error))
                {
                    userModel.ErrorText = xDoc.Root?
                                              .Element("ErrorDescription")?
                                              .Element("ErrorText")?
                                              .Value ?? "Unknown error";
                    userModel.IsError = true;
                }
                else // windows service didn't have unit test's at all
                {
                    userModel.ErrorText = "Not known error from XmlDecodeService";
                    userModel.IsError = true;
                }
            }
            catch (Exception ex)
            {
                userModel.ErrorText = ex.Message;
                userModel.IsError = true;
            }
        }
    }
}
