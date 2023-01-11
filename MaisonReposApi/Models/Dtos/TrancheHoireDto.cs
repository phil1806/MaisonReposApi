namespace MaisonReposApi.Models.Dtos
{
    public class TrancheHoireDto
    { 
        public int Id { get; set; }
        public DateTime Horaire { get; set; }
        public int personnelId { get; set; } //Foreign Key 

    }
}
