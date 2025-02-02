
using System.ComponentModel.DataAnnotations.Schema;
using StockApp.Domain.Event;

namespace StockApp.Domain.Entities;

public  abstract class Entity  {     //<TId>  where TId : notnull
    private readonly List<DomainEvent> _domainEvents = [];
   
    [NotMapped]
    public ICollection<DomainEvent> DomainEvents => _domainEvents;

    protected void Raise(DomainEvent domainEvent) {
        _domainEvents.Add(domainEvent);
    }

    int? _requestedHashCode;
    int _Id;
    public virtual int Id
    {
        get
        {
            return _Id;
        }
        protected set
        {
            _Id = value;
        }
    }
     public bool IsTransient()
    {
        return this.Id == default;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Entity))
            return false;

        if (Object.ReferenceEquals(this, obj))
            return true;

        if (this.GetType() != obj.GetType())
            return false;

        Entity item = (Entity)obj;

        if (item.IsTransient() || this.IsTransient())
            return false;
        else
            return item.Id == this.Id;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();

    }
    public static bool operator ==(Entity left, Entity right)
    {
        if (Object.Equals(left, null))
            return (Object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }

   /*
    public TId  Id{ get;  protected set; }
    
    protected Entity(TId id){
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }
    public  bool Equals(Entity<TId>? other){
        return Equals((object?)other);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left,right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right){
        return !Equals(left,right);
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    */
}