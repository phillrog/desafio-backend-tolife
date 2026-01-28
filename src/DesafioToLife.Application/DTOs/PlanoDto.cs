namespace DesafioToLife.Application.DTOs
{
     public record PlanoDto ( int Id ,
     string Type ,
     string Name ,
     decimal PhonePrice ,
     decimal PhonePriceOnPlan ,
     int Installments ,
     decimal MonthlyFee ,
     ScheduleDto Schedule,
     LocalidadeDto Localidade);
}
