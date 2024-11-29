using System.Text.Json.Serialization;

namespace SmartHub.Core.Responses
{
    [Serializable]
    public class Response<TData>
    {
        //Código de Stat HTTP
        public int Code = 200;

        //Construtor para o Json
        [JsonConstructor]
        public Response()
        {
            Code = 200;
        }

        //Construtor genérico para garantir esses dados basicos
        public Response(TData data, int code = 200, string? message = null)
        {
            Data = data;
            Code = code;
            Message = message;
        }

        //Utilização do TData pois a utilização de object não é segura e a ideia é fazer uma classe Response genérica
        public TData? Data { get; set; }
        public string? Message {  get; set; }

        [JsonIgnore]
        public bool IsSucess => Code is >= 200 and <= 299;

    }
}
