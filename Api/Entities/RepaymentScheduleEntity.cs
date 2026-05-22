namespace Api.Entities
{
    public class RepaymentScheduleEntity
    {
        public long id;
        public long loanId;
        public long userId;
        public decimal amount;
        public DateTime dueDate;
    }
}
