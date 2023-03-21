

using System.ComponentModel.DataAnnotations;

namespace AgendaDeTarefas.Models

{
    public class TarefaModel
    {

        
        [Required(ErrorMessage = "O campo id é obrigatório")]

        public int id { get; set; }

        [Required (ErrorMessage= "O campo nome é obrigatório")]
        public string? nome { get; set; }

        [Required(ErrorMessage = "O campo titulo é obrigatório")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo descricao é obrigatório")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo data é obrigatório")]

        public DateTime data { get; set; }

        [Required(ErrorMessage = "O campo inicio é obrigatório")]

        public int inicio { get; set; }

        [Required(ErrorMessage = "O campo fim é obrigatório")]
        public int fim { get; set; }

        [Required(ErrorMessage = "O campo Prioridade é obrigatório")]
        public string? Prioridade { get; set; }

        [Required(ErrorMessage = "O campo Tarefa_Finalizada é obrigatório")]

        public string? Tarefa_Finalizada { get; set; }
            
        
    }
 }

