
using Entity.Model.Base;


namespace Entity.Model
{
    public class Module : BaseEntity
    {
        public int Code { get; set; }
        public required string Name { get; set; }
    }
}