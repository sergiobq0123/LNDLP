namespace LNDP_API.Models {
    public class ModelBase {

        public ModelBase()
        {
            CreationDate = DateTime.UtcNow;
            IsActive = true;
        }
        public int Id {get ; set ; }
        public DateTime CreationDate  {get; set; } 
        public bool IsActive {get;set; }
        
    }
}