using System;

namespace DataDomain
{
    public class Diagnosis
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static Diagnosis Create(string title,string description)
        {
            var diagnosis = new Diagnosis { Id = Guid.NewGuid() };
            diagnosis.Update(title,description);
            return diagnosis;
        }

        public void Update(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}