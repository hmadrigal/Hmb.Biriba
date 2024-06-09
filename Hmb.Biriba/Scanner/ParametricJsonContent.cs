using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Hmb.Biriba.Scanner;

public class ParametricJsonContent : ParametricContent
{
    public class JsonContentParameter : Parameter
    {
        public string? Key { get; init; }
        public string? Value { get; init; }
    }

    public override IEnumerable<Parameter> GetParameters()
    {

        if (Content is null)
        {
            yield break;
        }


        throw new NotImplementedException();

        //// Create a JsonNode DOM from a JSON string.
        //JsonNode rootNode = JsonNode.Parse(Content)!;

        //static IEnumerable<JsonContentParameter> Traverse(JsonNode node)
        //{
        //    if (node is JsonObject jsonObjectNode)
        //    {
        //        foreach (KeyValuePair<string, JsonNode?> property in jsonObjectNode)
        //        {
        //            yield return new JsonContentParameter
        //            {
        //                Key = property.Key,
        //                Value = property.Value.ToString()
        //            };
        //        }
        //    }
        //    else if (node is JsonArrayNode jsonArrayNode)
        //    {
        //        foreach (var element in jsonArrayNode.Elements)
        //        {
        //            foreach (var parameter in Traverse(element))
        //            {
        //                yield return parameter;
        //            }
        //        }
        //    }
        //}

    }

}
