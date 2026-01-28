namespace DesafioToLife.Domain.Entities
{
    public class Aparelho
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private List<Plano> _planos = new List<Plano>();

        public IReadOnlyCollection<Plano> Planos
        {
            get { return _planos; }
        }


        public Aparelho() {}

        public Aparelho(string name)
        {
            Name = name;
        }

        public void AdicionarPlano(Plano plano) { 
            _planos.Add(plano);
        
        }

        public void AdicionarPlano(List<Plano> planos)
        {
            _planos = planos;
        }
    }
}
