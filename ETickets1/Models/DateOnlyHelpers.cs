namespace ETickets1.Models
{
    public static class DateOnlyHelpers
    {
        public static DateOnly Today => DateOnly.FromDateTime(DateTime.Now);
    }
}
