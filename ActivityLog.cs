using System;

namespace TaskLogManager
{
    public class ActivityLog
    {
        // IDs em string pra facilitar o uso de GUID curto
        public string Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } // mudei de Timestamp para CreatedAt pra ficar mais comum
        public int MinutesSpent { get; set; } // mudei o nome do campo pra parecer mais natural

        // Construtor principal que vou usar no console
        public ActivityLog(string title, string description, int minutesSpent)
        {
            // Pegando só os primeiros 8 caracteres do GUID pro ID não ficar gigante na tela
            Id = Guid.NewGuid().ToString().Substring(0, 8); 
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now; // grava a hora atual do registro
            MinutesSpent = minutesSpent;
        }

        // Deixei esse construtor vazio aqui porque o desserializador do JSON precisa dele pra funcionar
        public ActivityLog() 
        { 
        }
    }
}
