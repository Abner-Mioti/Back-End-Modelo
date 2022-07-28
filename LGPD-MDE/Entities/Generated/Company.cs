﻿namespace LGPD_MDE.Entities.Generated
{
    public class Company
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int FieldId { get; set; }
        public int StepId { get; set; }
        public int CompanyCategoryId { get; set; }
        public int ReportPeriodId { get; set; }
        public int WorkshopId { get; set; }
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Site { get; set; }
        public float Progress { get; set; }
        public bool ProgrectionStatus { get; set; }
        public DateTime ProgrectionStartDate { get; set; }
        public float Maturity { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime MaturityDate { get; set; }
        public Workshop Workshop { get; set; }
        public virtual Field Field { get; set; }
        public virtual Step Step { get; set; }
        public virtual CompanyCategory EnterpriseCategory { get; set; }
        public virtual ReportPeriod ReportPeriod { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
