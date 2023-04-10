using System.ComponentModel.DataAnnotations;

namespace Domain.Base
{
    public abstract class Entity : object
    {
        public Entity() : base()
        {
            Id = Guid.NewGuid();
            IsEdited = false;
            InsertDateTime = DateTime.Now;
            UpdateDateTime = DateTime.Now;
        }

        //**********
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        //**********

        //**********
        public bool IsEdited { get; set; }
        //**********

        //**********
        [Display(ResourceType = typeof(Resources.Tables.DataDictionary),
            Name = nameof(Resources.Tables.DataDictionary.InsertDateTime))]
        public System.DateTime InsertDateTime { get; set; }
        //**********

        //**********
        [Display(ResourceType = typeof(Resources.Tables.DataDictionary),
            Name = nameof(Resources.Tables.DataDictionary.UpdateDateTime))]
        public System.DateTime UpdateDateTime { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.DataDictionary),
            Name = nameof(Resources.Tables.DataDictionary.DeleteDateTime))]
        public System.DateTime DeleteDateTime { get; set; }
        // **********
    }
}
