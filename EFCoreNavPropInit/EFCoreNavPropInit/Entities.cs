using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCoreNavPropInit
{
    [Table("Entity")]
    class Entity
    {
        private readonly ILazyLoader _lazyLoader;
        internal List<ChildEntity> _children;

        public Entity() { }
        private Entity(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader ?? throw new ArgumentNullException(nameof(lazyLoader));
        }

        [Key]
        public int Id { get; set; }

        [InverseProperty(nameof(ChildEntity.Parent))]
        public List<ChildEntity> Children
        {
            get => _lazyLoader.Load(this, ref _children);
            set => _children = value;
        }
    }

    [Table("ChildEntity")]
    class ChildEntity
    {
        [Key]
        public int Id { get; set; }

        public int EntityId { get; set; }
        [ForeignKey(nameof(EntityId))]
        public Entity Parent { get; set; }
    }
}
