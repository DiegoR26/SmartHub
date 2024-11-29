using System.Text.Json.Serialization;

namespace SmartHub.Core.Responses
{
    public class Response<TData>
    {
        //Código de Stat HTTP
        private int _code = 200;

        //Construtor para o Json
        [JsonConstructor]
        public Response()
        {
            _code = 200;
        }

        //Construtor genérico para garantir esses dados basicos
        public Response(TData data, int code = 200, string? message = null)
        {
            Data = data;
            _code = code;
            Message = message;
        }

        //Utilização do TData pois a utilização de object não é segura e a ideia é fazer uma classe Response genérica
        public TData? Data { get; set; }
        public string? Message {  get; set; }

        [JsonIgnore]
        public bool IsSucess => _code is >= 200 and <= 299;

    }
}
