using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApp31.Models
{
    public class ExceptionLog
    {
        [Key] // primary identity key
        public int ExceptionLogRowId { get; set; }
        [StringLength(100)]
        public string ControllerName { get; set; }

        [StringLength(100)]
        public string ActionName { get; set; }

        public string ExceptionMesaage { get; set; }
        public DateTime Date { get; set; }
        public string StackTrace { get; set; }

    }

}
