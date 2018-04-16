using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MichaelBrandonMorris.AllianceReservationsTest
{
    public class Entity<TEntity>
        : IEquatable<TEntity>, IEquatable<Entity<TEntity>>
        where TEntity : Entity<TEntity>
    {
        public Guid? Id { get; set; }

        private static string PathRoot => Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "MichaelBrandonMorris.AllianceReservationsTest");

        public bool Equals(Entity<TEntity> other)
        {
            if (other is null)
            {
                return false;
            }

            return ReferenceEquals(this, other) || Id.Equals(other.Id);
        }

        public bool Equals(TEntity other)
        {
            if (other is null)
            {
                return false;
            }

            return ReferenceEquals(this, other) || Id.Equals(other.Id);
        }

        public static TEntity Find(Guid? id)
        {
            var entities = ReadEntities();
            return entities.SingleOrDefault(x => x.Id == id);
        }

        public void Delete()
        {
            Id = null;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Entity<TEntity>) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void Save()
        {
            Id = Guid.NewGuid();
            var entities = ReadEntities();
            entities.Add((TEntity) this);
            WriteEntities(entities);
        }

        private static IList<TEntity> ReadEntities()
        {
            var name = typeof(TEntity).FullName;
            var path = Path.Combine(PathRoot, name + ".json");

            if (!File.Exists(path))
            {
                return new List<TEntity>();
            }

            var json = File.ReadAllText(path);

            return JsonConvert
                       .DeserializeObject<IList<TEntity>>(json) ??
                   new List<TEntity>();
        }

        private static void WriteEntities(IList<TEntity> entities)
        {
            var name = typeof(TEntity).FullName;

            if (!Directory.Exists(PathRoot))
            {
                Directory.CreateDirectory(PathRoot);
            }

            var path = Path.Combine(PathRoot, name + ".json");
            var json = JsonConvert.SerializeObject(entities);
            File.WriteAllText(path, json);
        }
    }
}