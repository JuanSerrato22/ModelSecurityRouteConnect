
using Entity.Model.Base;

namespace Entity.Model
{
    public class Form : BaseEntity
    {
        public int Code { get; set; }
        public required string Name { get; set; }
    }
}
