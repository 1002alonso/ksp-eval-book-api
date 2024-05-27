using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KspEvalBook.Application.DTOs
{
    public class EditorialDto
    {
        public Guid? id { get; set; }
        public string nombre { get; set; }
        public DateTime? dtAlta { get; set; }
        public DateTime? dtActualiza { get; set; }
        public string? usuarioAlta { get; set; }

    }
}
