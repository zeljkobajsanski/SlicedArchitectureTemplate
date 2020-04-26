namespace StarterWebApplication.Domain
{
    public class Entity<T>
    {
        public T Id { get; set; }
        public bool IsNew => Id.Equals(default(T));
    }
}