namespace examApi.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string serialNumber { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        
        /** si ipotizza il caso in cui lo studente possa prenotare solo un'esame alla volta */
        public long? examReferenceId { get; set; }
    }
}