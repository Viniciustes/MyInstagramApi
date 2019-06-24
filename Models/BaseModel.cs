using System;
using System.Collections.Generic;

namespace MyInstagramApi.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var entity = obj as BaseModel;

            return entity != null && Id.Equals(entity.Id);
        }

        public static bool operator ==(BaseModel entity1, BaseModel entity2)
        {
            return EqualityComparer<BaseModel>.Default.Equals(entity1, entity2);
        }

        public static bool operator !=(BaseModel entity1, BaseModel entity2)
        {
            return !(entity1 == entity2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}
