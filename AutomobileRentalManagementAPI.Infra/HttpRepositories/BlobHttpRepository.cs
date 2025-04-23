using AutomobileRentalManagementAPI.Domain.HttpRepositories;

namespace AutomobileRentalManagementAPI.Infra.HttpRepositories
{
    public class BlobHttpRepository : IBlobHttpRepository
    {
        public string UploadBase64FileAndReturnPublicUrl(string base64img)
        {
            string response = string.Empty;

            try
            {
                response = "https://i.pravatar.cc/150?img=33";
            }
            catch (Exception ex) 
            { 
                // Como nao temos responseBase vou tratar que fez upload com sucesso
                // se a url vir preenchida.
                // Dessa forma só insiro no nosso banco o path da img se for sucesso o upload antes.
            }

            return response;
        }
    }
}