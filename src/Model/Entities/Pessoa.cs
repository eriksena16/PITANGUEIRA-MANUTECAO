using System;
using System.Collections.Generic;
using System.Text;

namespace Pitangueira.Model.Entities
{
    public abstract class Pessoa : GenericEntity
    {
        public string Name { get; set; }
        public long Telefone { get; set; }
    }
}
