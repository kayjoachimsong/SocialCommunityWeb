using Newtonsoft.Json;

namespace CommonLib
{
    public class Base
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
