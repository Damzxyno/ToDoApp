using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models.Response;

[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class ResponseEntity<T>
{
    public string Message { get; set; }
    public string Code { get; set; }

    public T Data { get; set; }
}
