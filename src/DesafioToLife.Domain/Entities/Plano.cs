using DesafioToLife.Domain.Enums;
using DesafioToLife.Domain.ValueObjects;

namespace DesafioToLife.Domain.Entities
{
    public class Plano
    {
        public int Id { get; private set; }
        public TipoPlanoEnum Type { get; private set; }
        public string Name { get; private set; }
        public decimal PhonePrice { get; private set; }
        public decimal PhonePriceOnPlan { get; private set; }
        public int Installments { get; private set; }
        public decimal MonthlyFee { get; private set; }
        public Schedule Schedule { get; private set; }
        public Localidade Localidade { get; private set; }

        public int AparelhoId { get; private set; }

        public Plano() {}
        public Plano(int id, string name, TipoPlanoEnum type, decimal phonePrice, decimal phonePriceOnPlan,
                     int installments, decimal monthlyFee, Schedule schedule, Localidade localidade)
        {
            Id = id;
            Name = name;
            Type = type;
            PhonePrice = phonePrice;
            PhonePriceOnPlan = phonePriceOnPlan;
            Installments = installments;
            MonthlyFee = monthlyFee;
            Schedule = schedule;
            Localidade = localidade;
        }
    }
}
